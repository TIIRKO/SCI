using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCI.View.Controles;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System.IO;
using Org.BouncyCastle.OpenSsl;

namespace SCI.View.Corporativo.Cadastro
{
    public partial class Certificado : BaseForm
    {
        private SCI.Corporativo.IRKO.Service wrCorporativo = new SCI.Corporativo.IRKO.Service();
        public Certificado()
        {
            InitializeComponent();
        }
        public Certificado(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            if (ofdArquivo.ShowDialog() == DialogResult.OK)
            {
                lblArquivo.Text = ofdArquivo.FileName.ToString();
            }
        }

        private void carregarCertificado()
        {
            string _caminho = lblArquivo.Text;
            string _senha = txtSenha.Text;

            X509Certificate2Collection _collection = new X509Certificate2Collection();
            _collection.Import(_caminho, _senha, X509KeyStorageFlags.PersistKeySet);

            _collection.Cast<X509Certificate2>().ToList().ForEach(_cert=>
            {
                lblResumo.Text = _cert.FriendlyName;
                lblVencimento.Text = _cert.NotAfter.ToShortDateString();
                lblSerial.Text = _cert.GetSerialNumberString();
            });
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            carregarCertificado();
        }

        private void Certificado_SalvarClick(object sender, EventArgs e)
        {
            string _caminho = lblArquivo.Text;
            string _senha = txtSenha.Text;

            X509Certificate2Collection _collection = new X509Certificate2Collection();
            _collection.Import(_caminho, _senha, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);

            _collection.Cast<X509Certificate2>().ToList().ForEach(_cert =>
            {
                string _cnpj = string.Empty;

                _cert.Extensions.Cast<X509Extension>().ToList().ForEach(_ext =>
                {
                    if (_ext.Format(true).Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Cast<string>().Where(_line => _line.Trim().StartsWith("2.16.76.1.3.3")).Any())
                    {
                        string _linha = _ext.Format(true).Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Cast<string>().Where(_line => _line.Trim().StartsWith("2.16.76.1.3.3")).FirstOrDefault();
                        string _valor = _linha.Substring(_linha.IndexOf('=') + 1);
                        string[] _elementos = _valor.Split(' ');
                        byte[] _bytes = new byte[14];
                        for (int j = 0; j < _bytes.Length; j++)
                            _bytes[j] = Convert.ToByte(_elementos[j + 2], 16);
                        _cnpj = Encoding.UTF8.GetString(_bytes);
                    }
                });

                if (string.IsNullOrEmpty(_cnpj))
                {
                    _cert.Extensions.Cast<X509Extension>().ToList().ForEach(_ext =>
                    {
                        if (_ext.Format(true).Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                            .Cast<string>().Where(_line => _line.Trim().StartsWith("2.16.76.1.3.1")).Any())
                        {
                            string _linha = _ext.Format(true).Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                            .Cast<string>().Where(_line => _line.Trim().StartsWith("2.16.76.1.3.1")).FirstOrDefault();
                            string _valor = _linha.Substring(_linha.IndexOf('=') + 1);
                            string[] _elementos = _valor.Split(' ');
                            byte[] _bytes = new byte[11];
                            for (int j = 0; j < _bytes.Length; j++)
                                _bytes[j] = Convert.ToByte(_elementos[j + 10], 16);
                            _cnpj = Encoding.UTF8.GetString(_bytes);
                        }
                    });
                }

                byte[] _subjectKey = null;
                _cert.Extensions.Cast<X509Extension>().ToList().ForEach(_ext =>
                {
                    if (_ext.Oid.Value.Equals("2.5.29.35"))
                    {
                        _subjectKey = _ext.RawData;
                    }
                });

                DateTime _vencimento = _cert.NotAfter;
                string _serial = _cert.GetSerialNumberString();
                try
                {
                    SCI.Corporativo.IRKO.Certificado _certificadoIRKO = new SCI.Corporativo.IRKO.Certificado();
                    _certificadoIRKO.CNPJCPF = _cnpj;
                    _certificadoIRKO.Certificate = _cert.RawData;

                    _certificadoIRKO.PrivateKeyPassword = _senha;
                    System.Security.Cryptography.RSACryptoServiceProvider _privateKey = (System.Security.Cryptography.RSACryptoServiceProvider)_cert.PrivateKey;
                    AsymmetricCipherKeyPair _keyPair = DotNetUtilities.GetRsaKeyPair(_privateKey);

                    TextWriter _textWriter = new StringWriter();
                    PemWriter _pemWriter = new PemWriter(_textWriter);

                    _pemWriter.WriteObject(_keyPair.Private);
                    _textWriter.Flush();
                    _certificadoIRKO.PrivateKey = _textWriter.ToString();

                    _certificadoIRKO.PfxFile = _cert.Export(X509ContentType.Pkcs12, _senha);

                    SCI.Corporativo.IRKO.Resultado _resultado = wrCorporativo.CadastrarCertificado(Guid, _certificadoIRKO);

                    if (_resultado.Sucesso)
                    {
                        lblArquivo.Text = string.Empty;
                        lblResumo.Text = string.Empty;
                        lblSerial.Text = string.Empty;
                        lblVencimento.Text = string.Empty;
                        txtSenha.Text = string.Empty;
                        MessageBox.Show("Certificado gravado com sucesso.");
                    }
                    else 
                    {
                        MessageBox.Show(_resultado.Mensagem);
                    }
                }
                catch(Exception _ex)
                {
                    MessageBox.Show(_ex.Message);
                }
            });
        }
    }
}
