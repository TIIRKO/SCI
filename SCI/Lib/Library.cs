using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SCI.Lib
{
    public static class Library
    {
        public static float TamanhoText(string _texto, Font _font)
        {
            using (Graphics _g = Graphics.FromHwnd(IntPtr.Zero))
            {
                return _g.MeasureString(_texto, _font).Width;
            }
        }

        public static string Normalizar(this string _string)
        {
            return NormalizarString(_string);
        }

        public static string NormalizarString(string _string)
        {
            if (string.IsNullOrEmpty(_string))
                return String.Empty;
            return System.Text.Encoding.UTF8.GetString(System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(_string)).ToUpper();

        }

        public static SCI.Base.Resultado<X509Certificate2> recuperarCertificadoEnvio(string _guid, string _cnpj)
        {
            SCI.Corporativo.IRKO.Service _wrCorporativo = new SCI.Corporativo.IRKO.Service();
            SCI.Corporativo.IRKO.ResultadoRecuperarCertificado _resultadoWr = _wrCorporativo.RecuperarCertificado(_guid, _cnpj);

            SCI.Base.Resultado<X509Certificate2> _resultado = new Base.Resultado<X509Certificate2>();

            if (_resultadoWr.Sucesso)
            {
                SCI.Corporativo.IRKO.Certificado _certificado = _resultadoWr.RetornoRecuperarCertificado;

                X509Certificate2Collection _collection = new X509Certificate2Collection();
                _collection.Import(_certificado.PfxFile, _certificado.PrivateKeyPassword, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                X509Certificate2 _cert = _collection.Cast<X509Certificate2>().FirstOrDefault();
                /*System.IO.TextReader _textReader = new System.IO.StringReader(_certificado.PrivateKey);
                PemReader _pemReader = new PemReader(_textReader);
                AsymmetricCipherKeyPair _keyPair = (AsymmetricCipherKeyPair)_pemReader.ReadObject();
                
                RSAParameters _rsa = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)_keyPair.Private);
                RSACryptoServiceProvider _csp = new RSACryptoServiceProvider();
                _csp.ImportParameters(_rsa);
                _cert.PrivateKey = _csp;*/

                _resultado.Retorno = _cert;
            }
            else
            {
                _resultado.Sucesso = false;
                _resultado.Mensagens = new Base.ResultadoMensagem[] { new Base.ResultadoMensagem() { Texto = _resultadoWr.Mensagem } };
            }

            return _resultado;
        }

    }
}
