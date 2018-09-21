using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Base
{
    public class Resultado<T>
    {
        public T Retorno { set; get; }
        public bool Sucesso { set; get; } = true;
        public string Tag { set; get; }
        public ResultadoMensagem[] Mensagens { set; get; }
        public string DivisorLinhas { set; get; } = "/n";
        public string Mensagem { get { return ConsolidarMensagem(this); } }

        public static string ConsolidarMensagem(Resultado<T> _resultado)
        {
            string _mensagem = string.Empty;
            _mensagem = string.Join(_resultado.DivisorLinhas, _resultado.Mensagens?.Select(_mens => _mens.Texto).ToArray());
            return _mensagem;
        }
    }

    public class Resultado
    {
        public bool Sucesso { set; get; } = true;
        public string Tag { set; get; }
        public ResultadoMensagem[] Mensagens { set; get; }
        public string DivisorLinhas { set; get; } = "/n";
        public string Mensagem { get { return ConsolidarMensagem(this); } }

        public static string ConsolidarMensagem(Resultado _resultado)
        {
            string _mensagem = string.Empty;
            _mensagem = string.Join(_resultado.DivisorLinhas, _resultado.Mensagens?.Select(_mens => _mens.Texto).ToArray());
            return _mensagem;
        }
    }
}
