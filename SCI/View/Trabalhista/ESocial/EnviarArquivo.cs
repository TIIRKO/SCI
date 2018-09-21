using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SCI.View.Controles;
using System.Xml;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Deployment.Internal.CodeSigning;
using System.Security.Cryptography.Xml;
using System.Net.Security;
using SCI.Base;

namespace SCI.View.Trabalhista.ESocial
{
    public partial class EnviarArquivo : BaseForm
    {
        private SCI.ESocial.IRKO.Service wrESocial = new SCI.ESocial.IRKO.Service();

        private enum tpAmb
        {
             Producão = 1
            ,ProduçãoRestrita = 2
        }

        private Resultado<System.Web.Services.Protocols.SoapHttpClientProtocol> GetWrAssinado(string _cnpj, tpAmb _tpAmb)
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
               
               if (_tpAmb == tpAmb.Producão)
                {
                    _wr = new SCI.ESocial.Producao.Envio.ServicoEnviarLoteEventos
                    {
                        Credentials = CredentialCache.DefaultCredentials
                    };
                }
               else
                {
                    _wr = new SCI.ESocial.ProducaoRestrita.Envio.ServicoEnviarLoteEventos
                    {
                        Credentials = CredentialCache.DefaultCredentials
                    };
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

        public EnviarArquivo()
        {
            InitializeComponent();
        }

        public EnviarArquivo(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void MontarCheckBox()
        {
            pnlArquivo.Controls.Clear();
            SCI.ESocial.IRKO.ResultadoEventoPendente resultado = wrESocial.ListarEventoPendente(Guid);
            if (resultado.Sucesso)
            {
                if (resultado.RetornoResultadoEventoPendente?.Any() ?? false)
                {
                    resultado.RetornoResultadoEventoPendente.ToList().ForEach(_tipoEvento =>
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
                MessageBox.Show(resultado.Mensagem);
            }
        }

        private void EnviarArquivo_AfterLoad(object sender, EventArgs e)
        {
            ShowCustom = true;
            Custom = true;
            MontarCheckBox();
            Custom = true;
        }

        private void BtnSel_Click(object sender, EventArgs e)
        {
            pnlArquivo.Controls.Cast<CheckBox>().ToList().ForEach(_check =>
            {
                _check.Checked = true;
            });
        }

        private void BtnDes_Click(object sender, EventArgs e)
        {
            pnlArquivo.Controls.Cast<CheckBox>().ToList().ForEach(_check =>
            {
                _check.Checked = false;
            });
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

                var _xmlElements = _xml.GetElementsByTagName("eventos").Cast<XmlElement>().FirstOrDefault()
                    .GetElementsByTagName("eSocial").Cast<XmlElement>().ToList();

                foreach (XmlElement _xmlEle in _xmlElements)
                {
                    string _id = _xmlEle.FirstChild.Attributes["Id"].Value;

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
                    _reference.Uri = "";
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
            return _resultado;
        }

        private void ExecutarEnviaArquivo()
        {
            try
            {
                if (pnlArquivo.Controls?.Cast<CheckBox>().Where(_check => _check.Checked)?.ToList().Any() ?? false)
                {
                    Custom = false;
                    gpbArquivos.Visible = false;
                    btnSel.Visible = false;
                    btnDes.Visible = false;

                    gpbEnviados.Visible = true;
                    btnVoltar.Visible = true;

                    pnlArquivo.Controls?.Cast<CheckBox>().Where(_check => _check.Checked)?.ToList().ForEach(_check =>
                    {

                        TreeNode _nodeCheck = new TreeNode(_check.Text);

                        int _contador = 0;
                        while (true)
                        {
                            string _url = "https://www.irko.com.br/csp/prgtrb/esocial/arquivoXML.csp?CODEMP="
                                + GetDesktop().GetEmpresa().Codigo.ToString();
                            _url += "&NOMEVT=" + ((SCI.ESocial.IRKO.TipoEvento)_check.Tag).Codigo;
                            _url += "&GUID=" + Guid;

                            XmlDocument _xml = new XmlDocument
                            {
                                PreserveWhitespace = false
                            };
                            _xml.Load(_url);

                            if (_xml.DocumentElement.Name == "Fim")
                                break;
                            if (_xml.DocumentElement.Name == "Falha")
                            {
                                MessageBox.Show(_xml.DocumentElement.InnerText);
                                break;
                            }

                            XmlElement _xmlEsocial = _xml.DocumentElement;

                            string _cnpjTransmissao = _xmlEsocial.GetElementsByTagName("ideTransmissor").Cast<XmlElement>().FirstOrDefault()
                                .GetElementsByTagName("nrInsc").Cast<XmlElement>().FirstOrDefault().InnerText;
                            string _cnpjEmpregador = _xmlEsocial.GetElementsByTagName("ideEmpregador").Cast<XmlElement>().FirstOrDefault()
                                .GetElementsByTagName("nrInsc").Cast<XmlElement>().FirstOrDefault().InnerText;
                            Resultado _resultadoAssinar = AssinarXML(ref _xml, _cnpjTransmissao);

                            XmlNodeList _xmlData = _xml.GetElementsByTagName("evento");
                            List<string> _listaId = _xmlData.Cast<XmlNode>().Where(_id => _id.Name == "evento")
                                .Select(_id => _id.Attributes["Id"].Value).ToList();

                            XmlElement _retorno = null;

                            string _tpAmb = _xmlEsocial.GetElementsByTagName("evento").Cast<XmlElement>().FirstOrDefault()
                                .GetElementsByTagName("ideEvento").Cast<XmlElement>().FirstOrDefault()
                                .GetElementsByTagName("tpAmb").Cast<XmlElement>().FirstOrDefault().InnerText;

                            SCI.Base.Resultado<System.Web.Services.Protocols.SoapHttpClientProtocol> _resultado = GetWrAssinado(_cnpjTransmissao,(tpAmb)int.Parse(_tpAmb));
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

                                        if (cert.GetCertHashString() == "F947B2BF566DF881A4F52CDDB436BE522CB48A3F")
                                        {
                                            return true;
                                        }

                                        return false;
                                    };
                                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                                    if ((tpAmb)int.Parse(_tpAmb) == tpAmb.Producão)
                                    {
                                        _retorno = ((SCI.ESocial.Producao.Envio.ServicoEnviarLoteEventos)_wrAssinado).EnviarLoteEventos(_xmlEsocial);
                                    }
                                    else
                                    {
                                        _retorno = ((SCI.ESocial.ProducaoRestrita.Envio.ServicoEnviarLoteEventos)_wrAssinado).EnviarLoteEventos(_xmlEsocial);
                                    }
                                }
#pragma warning disable CS0168 // A variável foi declarada, mas nunca foi usada
                                catch (Exception ex)
#pragma warning restore CS0168 // A variável foi declarada, mas nunca foi usada
                                {
                                    continue;
                                }

                                if (GravarEnvio(_retorno, _listaId, _cnpjTransmissao))
                                {
                                    _contador++;
                                    TreeNode _node = new TreeNode("Arquivo " + _contador.ToString());
                                    TreeNode _nodeId = new TreeNode("ID");
                                    _nodeId.Nodes.AddRange(_listaId.ConvertAll<TreeNode>(_id => new TreeNode(_id)).ToArray());
                                    _node.Nodes.Add(_nodeId);

                                    TreeNode _nodeRetorno = new TreeNode("Retorno");

                                    TreeNode _nodeResposta = new TreeNode(
                                        _retorno.GetElementsByTagName("descResposta").Cast<XmlElement>().FirstOrDefault().InnerText);

                                    if (_retorno.GetElementsByTagName("cdResposta").Cast<XmlElement>().FirstOrDefault().InnerText == "201")
                                    {
                                        _nodeResposta.Nodes.Add(new TreeNode("Data: " +
                                           _retorno.GetElementsByTagName("dhRecepcao").Cast<XmlElement>().FirstOrDefault().InnerText));
                                        _nodeResposta.Nodes.Add(new TreeNode("Varsão: " +
                                           _retorno.GetElementsByTagName("versaoAplicativoRecepcao").Cast<XmlElement>().FirstOrDefault().InnerText));
                                        _nodeResposta.Nodes.Add(new TreeNode("Protocolo: " +
                                          _retorno.GetElementsByTagName("protocoloEnvio").Cast<XmlElement>().FirstOrDefault().InnerText));
                                    }
                                    else
                                    {
                                        XmlNodeList _ocorrencias = _retorno.GetElementsByTagName("ocorrencia");

                                        _ocorrencias.Cast<XmlElement>().ToList().ForEach(_ocorrencia =>
                                        {
                                            TreeNode trnOcur = new TreeNode("Ocorrência");
                                            trnOcur.Nodes.AddRange(new TreeNode[]
                                            {
                                                 new TreeNode(_ocorrencia.GetElementsByTagName("codigo").Cast<XmlElement>().FirstOrDefault().InnerText)
                                                ,new TreeNode(_ocorrencia.GetElementsByTagName("descricao").Cast<XmlElement>().FirstOrDefault().InnerText)
                                                ,new TreeNode(_ocorrencia.GetElementsByTagName("tipo").Cast<XmlElement>().FirstOrDefault().InnerText)
                                            });
                                            _nodeResposta.Nodes.Add(trnOcur);
                                        }
                                         );
                                    }
                                    _nodeRetorno.Nodes.Add(_nodeResposta);

                                    _node.Nodes.Add(_nodeRetorno);
                                    _nodeCheck.Nodes.Add(_node);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show(_resultado.Mensagem);
                                break;
                            }
                        }
                        trvEnviado.Nodes.Add(_nodeCheck);
                    });
                    trvEnviado.ExpandAll();
                }
                else
                {
                    MessageBox.Show("Nenhum arquivo selecionado para envio.");
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
            GetDesktop().HideLoading();
        }


        private void EnviarArquivo_BtnCustomClick(object sender, EventArgs e)
        {
            GetDesktop().ShowLoading();
            ExecutarEnviaArquivo();
        }

        private bool GravarEnvio(XmlElement _retorno, List<string> _listaId, string _cnpj)
        {
            SCI.ESocial.IRKO.ParametroGravarEnvio _parametro = new SCI.ESocial.IRKO.ParametroGravarEnvio();

            XmlElement _status = _retorno.GetElementsByTagName("status").Cast<XmlElement>().FirstOrDefault();
            _parametro.CdResposta = _status.GetElementsByTagName("cdResposta").Cast<XmlElement>().FirstOrDefault().InnerText;
            _parametro.DescResposta = _status.GetElementsByTagName("descResposta").Cast<XmlElement>().FirstOrDefault().InnerText;
            _parametro.CNPJTR = _cnpj;
            _parametro.Ids = _listaId.ToArray();
            _parametro.ArquivoXML = _retorno.OuterXml;

            if (_parametro.CdResposta == "201")
            {
                XmlElement _dadosRecepcaoLote = _retorno.GetElementsByTagName("dadosRecepcaoLote").Cast<XmlElement>().FirstOrDefault();
                _parametro.DhRecepcao = _dadosRecepcaoLote.GetElementsByTagName("dhRecepcao").Cast<XmlElement>().FirstOrDefault().InnerText;
                _parametro.VersaoAplicativoRecepcao = _dadosRecepcaoLote.GetElementsByTagName("versaoAplicativoRecepcao").Cast<XmlElement>().FirstOrDefault().InnerText;
                _parametro.ProtocoloEnvio = _dadosRecepcaoLote.GetElementsByTagName("protocoloEnvio").Cast<XmlElement>().FirstOrDefault().InnerText;
            }
            else
            {
                XmlNodeList _ocorrencias = _retorno.GetElementsByTagName("ocorrencia");
                _parametro.Ocorrencias = _ocorrencias.Cast<XmlElement>().ToList()
                    .ConvertAll<SCI.ESocial.IRKO.Ocorrencia>(_ocorrencia => new SCI.ESocial.IRKO.Ocorrencia
                    {
                         Codigo = _ocorrencia.GetElementsByTagName("codigo").Cast<XmlElement>().FirstOrDefault().InnerText
                        ,Descricao = _ocorrencia.GetElementsByTagName("descricao").Cast<XmlElement>().FirstOrDefault().InnerText
                        ,Tipo = _ocorrencia.GetElementsByTagName("tipo").Cast<XmlElement>().FirstOrDefault().InnerText
                    }).ToArray();
            }

            SCI.ESocial.IRKO.Resultado _retornoIrko = wrESocial.GravarEnvio(Guid, _parametro);

            if (_retornoIrko.Sucesso)
            {
                return true;
            }
            else
            {
                MessageBox.Show(_retornoIrko.Mensagem);
                return false;
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Custom = true;
            gpbArquivos.Visible = true;
            btnSel.Visible = true;
            btnDes.Visible = true;

            gpbEnviados.Visible = false;
            btnVoltar.Visible = false;

            trvEnviado.Nodes.Clear();
            MontarCheckBox();
        }
    }
}
