using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SCI.View.Controles;
using System.Xml;
using SCI.Base;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Security.Cryptography;
using System.Deployment.Internal.CodeSigning;
using System.Security.Cryptography.Xml;
using System.Net.Security;
using Microsoft.Reporting.WinForms;
using System.Threading;
using System.ComponentModel;

namespace SCI.View.DCTF.REINF
{
    public partial class EnvioDeArquivos : BaseForm
    {
        Reinf.Irko.Service wrReinf = new Reinf.Irko.Service();

        public EnvioDeArquivos()
        {
            InitializeComponent();
        }

        public EnvioDeArquivos(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void MontarCheckBox()
        {
            try
            {
                pnlArquivo.Controls.Clear();
                SCI.Reinf.Irko.ResultadoEventopPendente _resultado = wrReinf.ListarEventoPendente(Guid);

                if (_resultado.Sucesso)
                {
                    if (_resultado.RetornoResultadoEventoPendente?.Any() ?? false)
                    {
                        _resultado.RetornoResultadoEventoPendente.ToList().ForEach(_tipoEvento =>
                        {
                            CheckBox _check = new CheckBox
                            {
                                Text = _tipoEvento.Codigo + " - " + _tipoEvento.Descricao,
                                TextAlign = ContentAlignment.MiddleLeft,
                                Left = 5,
                                Width = 641,
                                Top = ((pnlArquivo.Controls.Count) * 25) + 5,
                                Tag = _tipoEvento
                            };

                            pnlArquivo.Controls.Add(_check);
                        });
                    }
                    else
                    {
                        MessageBox.Show("Nenhum arquivo pendente de envio para esta empresa.");
                        Fechar(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show(_resultado.Mensagem);
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }

        private void ExecutarEnviaArquivo()
        {
            Custom = false;
            gpbArquivos.Visible = false;
            btnSel.Visible = false;
            btnDes.Visible = false;
            imgVoltar.Visible = true;
            imgEnviar.Visible = false;

            try
            {
                List<SCI.Model.Report.DCTF.Reinf.RetornoREINF> _listRetorno = new List<Model.Report.DCTF.Reinf.RetornoREINF>();

                pnlArquivo.Controls?.Cast<CheckBox>().Where(_check => _check.Checked)?.ToList().ForEach(_check =>
                {
                    Model.Report.DCTF.RetornoREINF.RetornoEvento _retornoEvento = new Model.Report.DCTF.RetornoREINF.RetornoEvento
                    {
                        Descricao = _check.Text
                    };

                    int _contador = 0;

                    string _url;

                    if (((SCI.Reinf.Irko.TipoEvento)_check.Tag).Codigo == "R-5011")
                    {
                        _url = "https://www.irko.com.br/csp/prgdcn/reinf/retornoXML.csp?";
                        _url += "CODEMP=" + GetDesktop().GetEmpresa().Codigo.ToString();
                        _url += "&GUID=" + Guid;
                    }
                    else
                    {
                        _url = "https://www.irko.com.br/csp/prgdcn/reinf/arquivoXML.csp?";
                        _url += "CODEMP=" + GetDesktop().GetEmpresa().Codigo.ToString();
                        _url += "&NOMREG=" + ((SCI.Reinf.Irko.TipoEvento)_check.Tag).Codigo;
                        _url += "&GUID=" + Guid;
                    }
                    XmlDocument _xml = new XmlDocument
                    {
                        PreserveWhitespace = false
                    };
                    _xml.Load(_url);

                    if (_xml.DocumentElement.Name == "Fim" || _xml.DocumentElement.Name == "Falha")
                    {
                    }
                    else
                    {

                        XmlNode _xmlReinf = _xml.DocumentElement;

                        string _cnpjTransmissao = "07074083000102";
                        string _cnpjContr = string.Empty;

                        var resultadoCNPJ = wrReinf.RecuperaCNPJCPFCertificado(Guid);
                        if (resultadoCNPJ.Sucesso)
                        {
                            _cnpjContr = resultadoCNPJ.RetornoResultadoRecuperaCNPJCPFCertificado;
                        }

                        if (String.IsNullOrEmpty(_cnpjContr))
                        {
                            _cnpjContr = _xml.DocumentElement.GetElementsByTagName("ideContri")?.Cast<XmlElement>()
                            .FirstOrDefault()?.GetElementsByTagName("nrInsc")?.Cast<XmlElement>().FirstOrDefault()?.InnerText;
                        }

                        String _tpAmb = _xml.DocumentElement.GetElementsByTagName("tpAmb")?.Cast<XmlElement>()?
                        .FirstOrDefault()?.InnerText;

                        _cnpjTransmissao = _cnpjContr;
                        var _xmlElements = _xml.GetElementsByTagName("loteEventos").Cast<XmlElement>().FirstOrDefault();

                        List<string> _listaId = _xmlElements?.Cast<XmlNode>().Where(_node => _node.Name == "evento")?
                                    .Select(_id => _id.Attributes["id"].Value)?.ToList();

                        Resultado _resultadoAssinar = new Resultado();
                        _resultadoAssinar.Sucesso = true;
                        if (((SCI.Reinf.Irko.TipoEvento)_check.Tag).Codigo != "R-5011")
                        {
                            _resultadoAssinar = AssinarXML(ref _xml, _cnpjContr);
                        }

                        if (_resultadoAssinar.Sucesso)
                        {
                            XmlNode _retorno = null;

                            SCI.Base.Resultado<System.Web.Services.Protocols.SoapHttpClientProtocol> _resultado = GetWrAssinado(_cnpjTransmissao, ((SCI.Reinf.Irko.TipoEvento)_check.Tag).Codigo, _tpAmb);
                            if (_resultado.Sucesso)
                            {
                                System.Web.Services.Protocols.SoapHttpClientProtocol _wrAssinado = _resultado.Retorno;
                                try
                                {
                                    System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate (
                                    object sender,
                                    X509Certificate cert,
                                    X509Chain chain,
                                    SslPolicyErrors sslPolicyErrors)
                                    {
                                        if (sslPolicyErrors == SslPolicyErrors.None)
                                        {
                                            return true;
                                        }

                                        return false;
                                    };
                                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                                    if (((SCI.Reinf.Irko.TipoEvento)_check.Tag).Codigo == "R-5011")
                                    {
                                        XmlNodeList xnList = _xmlReinf.SelectNodes("/ConsultaInformacoesConsolidadas");
                                        byte _tipoInscricaoContribuinte = Convert.ToByte(xnList.Item(0).ChildNodes.Item(0).InnerText);
                                        string _numeroInscricaoContribuinte = xnList.Item(0).ChildNodes.Item(1).InnerText;
                                        string _numeroProtocoloFechamento = xnList.Item(0).ChildNodes.Item(2).InnerText;
                                        if (_tpAmb == "1")
                                        {
                                            _retorno = ((Reinf.Producao.Retorno.ConsultasReinf)_wrAssinado).ConsultaInformacoesConsolidadas(_tipoInscricaoContribuinte, _numeroInscricaoContribuinte, _numeroProtocoloFechamento);
                                        }
                                        else
                                        {
                                            _retorno = ((Reinf.ProducaoRestrita.Retorno.ConsultasReinf)_wrAssinado).ConsultaInformacoesConsolidadas(_tipoInscricaoContribuinte, _numeroInscricaoContribuinte, _numeroProtocoloFechamento);
                                        }
                                    }
                                    else
                                    {
                                        if (_tpAmb == "1")
                                        {
                                            _retorno = ((Reinf.Producao.Envio.RecepcaoLoteReinf)_wrAssinado).ReceberLoteEventos(_xmlReinf);
                                        }
                                        else
                                        {
                                            _retorno = ((Reinf.ProducaoRestrita.Envio.RecepcaoLoteReinf)_wrAssinado).ReceberLoteEventos(_xmlReinf);
                                        }
                                    }

                                    XmlDocument _docRetorno = new XmlDocument();
                                    _docRetorno.LoadXml(_retorno.OuterXml);
                                    XmlElement _retornoElement = _docRetorno.DocumentElement;

                                    Reinf.Irko.ResultadoGravarRetornoEvento _retornoWR = GravarEnvio(_retorno, _listaId, _cnpjTransmissao, ((SCI.Reinf.Irko.TipoEvento)_check.Tag).Codigo);

                                    if (_retornoWR.Sucesso)
                                    {
                                        if (((SCI.Reinf.Irko.TipoEvento)_check.Tag).Codigo == "R-5011")
                                        {
                                            Reinf.Irko.evtTotalContrib _retornoLoteEventos = _retornoWR.RetornoRetornoTotEvt10300.evtTotalContrib;
                                            _contador++;

                                            _retornoLoteEventos.ideRecRetorno.ideStatus.regOcorrs?.ToList().ForEach(_ocorr =>
                                            {
                                                SCI.Model.Report.DCTF.Reinf.RetornoREINF _retReinf = new Model.Report.DCTF.Reinf.RetornoREINF();
                                                _retReinf.codEvt = ((SCI.Reinf.Irko.TipoEvento)_check.Tag).Codigo;
                                                _retReinf.dscEvt = ((SCI.Reinf.Irko.TipoEvento)_check.Tag).Descricao;
                                                _retReinf.nomArq = _contador.ToString();
                                                _retReinf.idEVT = _retornoLoteEventos.id;
                                                _retReinf.stsEvt = _retornoLoteEventos.ideRecRetorno.ideStatus.descRetorno;
                                                _retReinf.tipOco = _ocorr.tpOcorr.ToString();
                                                _retReinf.dscOco = _ocorr.codResp + " - " + _ocorr.dscResp;

                                                _listRetorno.Add(_retReinf);
                                            });
                                        }
                                        else
                                        {
                                            Reinf.Irko.retornoLoteEventos _retornoLoteEventos = _retornoWR.RetornoRetornoLote10300.retornoLoteEventos;
                                            _contador++;

                                            _retornoLoteEventos.retornoEventos.ToList().ForEach(_evento =>
                                            {
                                                _evento.Reinf.evtTotal.ideRecRetorno.ideStatus.regOcorrs?.ToList().ForEach(_ocorr =>
                                                {
                                                    SCI.Model.Report.DCTF.Reinf.RetornoREINF _retReinf = new Model.Report.DCTF.Reinf.RetornoREINF();
                                                    _retReinf.codEvt = ((SCI.Reinf.Irko.TipoEvento)_check.Tag).Codigo;
                                                    _retReinf.dscEvt = ((SCI.Reinf.Irko.TipoEvento)_check.Tag).Descricao;
                                                    _retReinf.nomArq = "Arquivo " + _contador.ToString();
                                                    _retReinf.idEVT = _retornoLoteEventos.id;
                                                    _retReinf.stsEvt = _evento.Reinf.evtTotal.ideRecRetorno.ideStatus.descRetorno;
                                                    _retReinf.tipOco = _ocorr.tpOcorr.ToString();
                                                    _retReinf.dscOco = _ocorr.codResp + " - " + _ocorr.dscResp;

                                                    _listRetorno.Add(_retReinf);

                                                });
                                            });
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(_retornoWR.Mensagem);
                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                            }

                            //_retornReinf.Eventos.Add(_retornoEvento);
                            //trvEnviado.Nodes.Add(_nodeCheck);
                        }
                        else
                        {
                            MessageBox.Show(_resultadoAssinar.Mensagem);
                        }
                    }
                });
                rptREINF.LocalReport.DataSources.Clear();

                ReportDataSource _source = new ReportDataSource("RetornoArquivoREINF", _listRetorno);
                rptREINF.LocalReport.DataSources.Add(_source);

                rptREINF.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Agora", DateTime.Now.ToString()) });
                rptREINF.RefreshReport();

                gpbEnviados.Visible = true;
                pctLoad.Visible = false;
                lblLoad.Visible = false;
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }

        private Resultado AssinarXML(ref XmlDocument _xml, string _cnpj)
        {
            Resultado _resultado = new Resultado();

            if (_xml == null)
            {
                _resultado.Sucesso = false;
                _resultado.Mensagens = new Base.ResultadoMensagem[] { new Base.ResultadoMensagem() { Texto = "Arquivo XML não pode estar vazio." } };
            }

            if (string.IsNullOrEmpty(_cnpj))
            {
                _resultado.Sucesso = false;
                _resultado.Mensagens = new Base.ResultadoMensagem[] { new Base.ResultadoMensagem() { Texto = "CNPJ para recuperar certificado não pode ser nulo" } };
            }

            Resultado<X509Certificate2> _resultadoCert = Lib.Library.recuperarCertificadoEnvio(Guid, _cnpj);
            if (_resultadoCert.Sucesso)
            {
                X509Certificate2 _cert = _resultadoCert.Retorno;

                CryptoConfig.AddAlgorithm(typeof(RSAPKCS1SHA256SignatureDescription), "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");

                string _exportedKeyMaterial = _cert.PrivateKey.ToXmlString(true);

                RSACryptoServiceProvider _key = new RSACryptoServiceProvider(new CspParameters(24))
                {
                    PersistKeyInCsp = false
                };
                _key.FromXmlString(_exportedKeyMaterial);

                KeyInfo _keyInfo = new KeyInfo();
                _keyInfo.AddClause(new KeyInfoX509Data(_cert));

                var _xmlElements = _xml.GetElementsByTagName("loteEventos").Cast<XmlElement>().FirstOrDefault()
                    .GetElementsByTagName("Reinf").Cast<XmlElement>().ToList();

                foreach (XmlElement _xmlEle in _xmlElements)
                {
                    string _id = _xmlEle.FirstChild.Attributes["id"].Value;

                    XmlDocument _newXML = new XmlDocument();
                    _newXML.LoadXml(_xmlEle.OuterXml);

                    SignedXml _assinador = new SignedXml(_newXML)
                    {
                        SigningKey = _key
                    };
                    _assinador.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";

                    Reference _reference = new Reference("");
                    _reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                    _reference.AddTransform(new XmlDsigC14NTransform());
                    _reference.Uri = "#" + _id;
                    _reference.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";

                    _assinador.AddReference(_reference);

                    _assinador.KeyInfo = _keyInfo;
                    _assinador.ComputeSignature();

                    _xmlEle.AppendChild(_xml.ImportNode(_assinador.GetXml(), true));
                }
            }
            else
            {
                _resultadoCert = Lib.Library.recuperarCertificadoEnvio(Guid, "07074083000102");
                if (_resultadoCert.Sucesso)
                {
                    X509Certificate2 _cert = _resultadoCert.Retorno;

                    CryptoConfig.AddAlgorithm(typeof(RSAPKCS1SHA256SignatureDescription), "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");

                    string _exportedKeyMaterial = _cert.PrivateKey.ToXmlString(true);

                    RSACryptoServiceProvider _key = new RSACryptoServiceProvider(new CspParameters(24))
                    {
                        PersistKeyInCsp = false
                    };
                    _key.FromXmlString(_exportedKeyMaterial);

                    KeyInfo _keyInfo = new KeyInfo();
                    _keyInfo.AddClause(new KeyInfoX509Data(_cert));

                    var _xmlElements = _xml.GetElementsByTagName("loteEventos").Cast<XmlElement>().FirstOrDefault()
                        .GetElementsByTagName("Reinf").Cast<XmlElement>().ToList();

                    foreach (XmlElement _xmlEle in _xmlElements)
                    {
                        string _id = _xmlEle.FirstChild.Attributes["id"].Value;

                        XmlDocument _newXML = new XmlDocument();
                        _newXML.LoadXml(_xmlEle.OuterXml);

                        SignedXml _assinador = new SignedXml(_newXML)
                        {
                            SigningKey = _key
                        };
                        _assinador.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";

                        Reference _reference = new Reference("");
                        _reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                        _reference.AddTransform(new XmlDsigC14NTransform());
                        _reference.Uri = "#" + _id;
                        _reference.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";

                        _assinador.AddReference(_reference);

                        _assinador.KeyInfo = _keyInfo;
                        _assinador.ComputeSignature();

                        _xmlEle.AppendChild(_xml.ImportNode(_assinador.GetXml(), true));
                    }
                }
                else
                {
                    _resultado.Sucesso = false;
                    _resultado.Mensagens = new Base.ResultadoMensagem[] { new Base.ResultadoMensagem() { Texto = _resultadoCert.Mensagem } };
                }
            }

            return _resultado;
        }

        private Resultado<System.Web.Services.Protocols.SoapHttpClientProtocol> GetWrAssinado(string _cnpj, string _tipoEvento, string _tpAmb)
        {
            Resultado<System.Web.Services.Protocols.SoapHttpClientProtocol> _resultado = new Resultado<System.Web.Services.Protocols.SoapHttpClientProtocol>();
            if (string.IsNullOrEmpty(_cnpj))
            {
                _resultado.Sucesso = false;
                _resultado.Mensagens = new Base.ResultadoMensagem[] { new Base.ResultadoMensagem() { Texto = "CNPJ do transmissor não localizado." } };
            }

            if (_resultado.Sucesso)
            {
                Resultado<X509Certificate2> _resultadoCert = Lib.Library.recuperarCertificadoEnvio(Guid, _cnpj);
                if (_resultadoCert.Sucesso)
                {
                    System.Web.Services.Protocols.SoapHttpClientProtocol _wr;

                    if (_tipoEvento == "R-5011")
                    {
                        if (_tpAmb == "1")
                        {
                            _wr = new Reinf.Producao.Retorno.ConsultasReinf
                            {
                                Credentials = CredentialCache.DefaultCredentials
                            };
                        }
                        else
                        {
                            _wr = new Reinf.ProducaoRestrita.Retorno.ConsultasReinf
                            {
                                Credentials = CredentialCache.DefaultCredentials
                            };
                        }
                    }
                    else
                    {
                        if (_tpAmb == "1")
                        {
                            _wr = new Reinf.Producao.Envio.RecepcaoLoteReinf
                            {
                                Credentials = CredentialCache.DefaultCredentials
                            };
                        }
                        else
                        {
                            _wr = new Reinf.ProducaoRestrita.Envio.RecepcaoLoteReinf
                            {
                                Credentials = CredentialCache.DefaultCredentials
                            };
                        }
                    }

                    _wr.ClientCertificates.Add(_resultadoCert.Retorno);
                    _resultado.Retorno = _wr;
                }
                else
                {
                    _resultado.Sucesso = false;
                    _resultado.Mensagens = new Base.ResultadoMensagem[] { new Base.ResultadoMensagem() { Texto = _resultadoCert.Mensagem } };
                }
            }
            return _resultado;
        }

        private Reinf.Irko.ResultadoGravarRetornoEvento GravarEnvio(XmlNode _retorno, List<string> _listaId, string _cnpj, string _tipo)
        {
            Reinf.Irko.RetornoXML _parametro = new Reinf.Irko.RetornoXML
            {
                Empresa = new Reinf.Irko.Empresa() { Codigo = GetDesktop().GetEmpresa().Codigo, StatusSpecified = false },
                Usuario = new Reinf.Irko.Usuario() { Codigo = GetDesktop().GetUsuario().Codigo, DataInicio = DateTime.Now, StatusSpecified = false },
                DataProcessamento = DateTime.Now,
                ArquivoXML = _retorno.OuterXml,
                Ids = _listaId?.ToArray()
            };

            Reinf.Irko.ResultadoGravarRetornoEvento _retornoWR = wrReinf.GravarRetornoEvento(Guid, _parametro, _tipo);
            return _retornoWR;
        }

            private void EnvioDeArquivos_AfterLoad(object sender, EventArgs e)
        {
            MontarCheckBox();
            ToolTip toolTip = new ToolTip();
            // Set up the delays for the ToolTip.
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 250;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = false;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip.SetToolTip(this.imgEnviar, "Enviar" );
            toolTip.SetToolTip(this.imgVoltar, "Voltar");
            pctLoad.Visible = false;
            lblLoad.Visible = false;
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            pnlArquivo.Controls.Cast<CheckBox>().ToList().ForEach(_check =>
            {
                _check.Checked = true;
            });
        }

        private void btnDes_Click(object sender, EventArgs e)
        {
            pnlArquivo.Controls.Cast<CheckBox>().ToList().ForEach(_check =>
            {
                _check.Checked = false;
            });
        }

        private void imgEnviar_Click(object sender, EventArgs e)
        {
            bool check = false;

            pnlArquivo.Controls.Cast<CheckBox>().Where(_check => _check.Checked)?.ToList().ForEach(_check =>
            {
                check = true;
                return;
            });

            if (check)
            {
                ExecutarEnviaArquivo();
            }
            else
            {
                pctLoad.Visible = false;
                lblLoad.Visible = false;
                MessageBox.Show("Nenhum arquivo Selecionado");
            }
        }

        private void imgVoltar_Click(object sender, EventArgs e)
        {
            Custom = false;
            gpbArquivos.Visible = true;
            btnSel.Visible = true;
            btnDes.Visible = true;

            gpbEnviados.Visible = false;
            imgVoltar.Visible = false;
            imgEnviar.Visible = true;
            rptREINF.LocalReport.DataSources.Clear();
            MontarCheckBox();
        }

        private void imgEnviar_MouseDown(object sender, MouseEventArgs e)
        {
            imgEnviar.BackgroundImage = null;
            pctLoad.Visible = true;
            lblLoad.Visible = true;

        }
    }
}
