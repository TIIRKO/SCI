using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SCI.View.Controles;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using SCI.Base;
using System.Net.Security;

namespace SCI.View.DCTF.ESocial
{
    public partial class CapturarRetorno : BaseForm
    {
        private SCI.ESocial.IRKO.DCTF.Service wrESocial = new SCI.ESocial.IRKO.DCTF.Service();

        private enum tpAmb
        {
            Producão = 1
            , ProduçãoRestrita = 2
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
                        _wr = new SCI.ESocial.Producao.Retorno.ServicoConsultarLoteEventos
                        {
                            Credentials = CredentialCache.DefaultCredentials
                        };
                    }
                    else
                    {
                        _wr = new SCI.ESocial.ProducaoRestrita.Retorno.ServicoConsultarLoteEventos
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



        public CapturarRetorno()
        {
            InitializeComponent();
        }
        public CapturarRetorno(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void MontarCheckBox()
        {
            pnlArquivo.Controls.Clear();
            SCI.ESocial.IRKO.DCTF.ResultadoEventoPendente resultado = wrESocial.ListarRetornoPendente(Guid);
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


        private void CapturarRetorno_AfterLoad(object sender, EventArgs e)
        {
            ShowCustom = true;
            Custom = true;
            MontarCheckBox();
            Custom = true;
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

        private void CapturarRetorno_BtnCustomClick(object sender, EventArgs e)
        {
            ExecutarEnviaArquivo();
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
                            _contador++;
                            string _url = "https://www.irko.com.br/csp/prgdcn/esocial/retornoXML.csp?CODEMP="
                                + GetDesktop().GetEmpresa().Codigo.ToString();
                            _url += "&NOMEVT=" + ((SCI.ESocial.IRKO.DCTF.TipoEvento)_check.Tag).Codigo;
                            _url += "&GUID=" + Guid;

                            XmlDocument _xml = new XmlDocument();
                            _xml.Load(_url);

                            if (_xml.DocumentElement.Name == "Fim")
                                break;
                            if (_xml.DocumentElement.Name == "Falha")
                            {
                                MessageBox.Show(_xml.DocumentElement.InnerText);
                                break;
                            }

                            XmlElement _xmlEsocial = _xml.DocumentElement;

                            string _cnpj = _xmlEsocial.GetElementsByTagName("ideTransmissor").Cast<XmlElement>().FirstOrDefault()
                                .GetElementsByTagName("nrInsc").Cast<XmlElement>().FirstOrDefault().InnerText;

                            XmlNode _ideTransmissor = _xmlEsocial.GetElementsByTagName("ideTransmissor").Cast<XmlNode>().FirstOrDefault();
                            _xmlEsocial.RemoveChild(_ideTransmissor);

                            string _protocoEnvio = _xmlEsocial.GetElementsByTagName("protocoloEnvio").Cast<XmlElement>().FirstOrDefault().InnerText;

                            string _tpAmb = _protocoEnvio.Split('.')[1];

                            Resultado<System.Web.Services.Protocols.SoapHttpClientProtocol> _resultado = GetWrAssinado(_cnpj, (tpAmb)int.Parse(_tpAmb));

                            if (_resultado.Sucesso)
                            {
                                XmlElement _retorno = null;
                                System.Web.Services.Protocols.SoapHttpClientProtocol _wrESocialConsultar = _resultado.Retorno;
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
                                        _retorno = ((SCI.ESocial.Producao.Retorno.ServicoConsultarLoteEventos)_wrESocialConsultar).ConsultarLoteEventos(_xmlEsocial);
                                    }
                                    else
                                    {
                                        _retorno = ((SCI.ESocial.ProducaoRestrita.Retorno.ServicoConsultarLoteEventos)_wrESocialConsultar).ConsultarLoteEventos(_xmlEsocial);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    break;
                                }

                                TreeNode _node = new TreeNode("Protocolo:" + _protocoEnvio);
                                XmlElement _status = _retorno.GetElementsByTagName("status").Cast<XmlElement>().FirstOrDefault();

                                if (_status.GetElementsByTagName("cdResposta").Cast<XmlElement>().FirstOrDefault().InnerText == "201")
                                {
                                    if (GravarRetorno(_retorno))
                                    {
                                        XmlNodeList _eventos = _retorno.GetElementsByTagName("evento");
                                        _eventos.Cast<XmlElement>().ToList().ForEach(_evento =>
                                        {
                                            TreeNode _nodeId = new TreeNode(_evento.Attributes["Id"].Value);
                                            XmlElement _processamento = _evento.GetElementsByTagName("processamento").Cast<XmlElement>().FirstOrDefault();

                                            _nodeId.Nodes.AddRange(new TreeNode[]
                                                {
                                                 new TreeNode("Código: "+_processamento.GetElementsByTagName("cdResposta").Cast<XmlElement>().FirstOrDefault().InnerText)
                                                ,new TreeNode("Descrição: "+_processamento.GetElementsByTagName("descResposta").Cast<XmlElement>().FirstOrDefault().InnerText)
                                                });

                                            int _cttOcor = 0;
                                            XmlNodeList _ocorrencias = _processamento.GetElementsByTagName("ocorrencia");
                                            _ocorrencias.Cast<XmlElement>().ToList().ForEach(_ocorrencia =>
                                            {
                                                _cttOcor++;
                                                TreeNode _nodeOcor = new TreeNode("Ocorrencia " + _cttOcor);
                                                _nodeOcor.Nodes.AddRange(new TreeNode[]
                                                {
                                                 new TreeNode("Tipo: " + _ocorrencia.GetElementsByTagName("tipo").Cast<XmlElement>().FirstOrDefault().InnerText)
                                                ,new TreeNode("Código: "+_ocorrencia.GetElementsByTagName("codigo").Cast<XmlElement>().FirstOrDefault().InnerText)
                                                ,new TreeNode("Descrição: "+_ocorrencia.GetElementsByTagName("descricao").Cast<XmlElement>().FirstOrDefault().InnerText)
                                                });
                                                _nodeId.Nodes.Add(_nodeOcor);
                                            });

                                            _node.Nodes.Add(_nodeId);
                                        });
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    _node.Nodes.AddRange(new TreeNode[]
                                      {
                                         new TreeNode("Código :"+_status.GetElementsByTagName("cdResposta").Cast<XmlElement>().FirstOrDefault().InnerText)
                                      });

                                    String _textoDescricão = _status.GetElementsByTagName("descResposta").Cast<XmlElement>().FirstOrDefault().InnerText;
                                    String[] _palavras = _textoDescricão.Split(' ');
                                    if (_palavras.Length > 15)
                                    {
                                        string _NovotextoDescricão = "";
                                        for (int i = 0; i < _palavras.Length; i++)
                                        {
                                            if ((i % 15 == 0) && (i != 0))
                                            {
                                                _NovotextoDescricão = _NovotextoDescricão + " " + _palavras[i];
                                                _node.Nodes.AddRange(new TreeNode[]
                                                 {
                                                    new TreeNode(_NovotextoDescricão)
                                                });
                                                _NovotextoDescricão = "";
                                            }
                                            else
                                            {
                                                _NovotextoDescricão = _NovotextoDescricão + " " + _palavras[i];
                                            }
                                        }

                                        if (_NovotextoDescricão != "")
                                        {
                                            _node.Nodes.AddRange(new TreeNode[]
                                                {
                                                    new TreeNode(_NovotextoDescricão)
                                               });
                                        }

                                        _nodeCheck.Nodes.Add(_node);
                                        break;
                                    }
                                    else
                                    {
                                        _node.Nodes.AddRange(new TreeNode[]
                                        {
                                            new TreeNode("Descrição: " + _textoDescricão)
                                        });
                                        break;
                                    }
                                }
                                _nodeCheck.Nodes.Add(_node);

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

        private bool GravarRetorno(XmlElement _retorno)
        {
            List<SCI.ESocial.IRKO.DCTF.ParametroGravarRetorno> _parametros = new List<SCI.ESocial.IRKO.DCTF.ParametroGravarRetorno>();

            XmlNodeList _eventos = _retorno.GetElementsByTagName("evento");

            _eventos.Cast<XmlElement>().ToList().ForEach(_evento =>
            {
                SCI.ESocial.IRKO.DCTF.ParametroGravarRetorno _parametro = new SCI.ESocial.IRKO.DCTF.ParametroGravarRetorno
                {
                    Id = _evento.Attributes["Id"].Value
                };

                XmlElement _recepcao = _evento.GetElementsByTagName("recepcao").Cast<XmlElement>().FirstOrDefault();
                _parametro.Protocolo = _recepcao.GetElementsByTagName("protocoloEnvioLote").Cast<XmlElement>().FirstOrDefault().InnerText;

                XmlElement _processamento = _evento.GetElementsByTagName("processamento").Cast<XmlElement>().FirstOrDefault();

                _parametro.CdResposta = _processamento.GetElementsByTagName("cdResposta").Cast<XmlElement>().FirstOrDefault().InnerText;
                _parametro.DescResposta = _processamento.GetElementsByTagName("descResposta").Cast<XmlElement>().FirstOrDefault().InnerText;
                _parametro.DhProcessamento = _processamento.GetElementsByTagName("dhProcessamento").Cast<XmlElement>().FirstOrDefault().InnerText;
                _parametro.VersaoAplicativoProcessamento = _processamento.GetElementsByTagName("versaoAppProcessamento").Cast<XmlElement>().FirstOrDefault().InnerText;
                _parametro.NumeroRecibo= _evento.GetElementsByTagName("nrRecibo")?.Cast<XmlElement>().FirstOrDefault()?.InnerText;



                _parametro.Ocorrencias = _processamento.GetElementsByTagName("ocorrencia")?.Cast<XmlElement>().ToList()
                    .ConvertAll<SCI.ESocial.IRKO.DCTF.Ocorrencia>(_ocorrencia => new SCI.ESocial.IRKO.DCTF.Ocorrencia()
                    {
                        Tipo = _ocorrencia.GetElementsByTagName("tipo").Cast<XmlElement>().FirstOrDefault().InnerText
                        ,
                        Codigo = _ocorrencia.GetElementsByTagName("codigo").Cast<XmlElement>().FirstOrDefault().InnerText
                        ,
                        Descricao = _ocorrencia.GetElementsByTagName("descricao").Cast<XmlElement>().FirstOrDefault().InnerText
                    }).ToArray();
                _parametros.Add(_parametro);
            });

            SCI.ESocial.IRKO.DCTF.Resultado _resultado = wrESocial.GravarRetorno(Guid, _parametros.ToArray(), _retorno.OuterXml);
            if (!_resultado.Sucesso)
            {
                MessageBox.Show(_resultado.Mensagem);
            }

            return _resultado.Sucesso;
        }


    }
}
