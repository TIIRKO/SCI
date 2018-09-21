using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Model.Trabalhista
{
    public class Verba
    {
        public long Codigo { set; get; }
        public string Descricao { set; get; }
        public bool Ativa { set; get; }
        public string Display
        {
            get
            {
                return Codigo.ToString() + " - " + Descricao;
            }
        }

        public Verba() { }

        public Verba(long _codigo, string _descricao, bool _ativa)
        {
            Codigo = _codigo;
            Descricao = _descricao;
            Ativa = _ativa;
        }

        public Verba(SCI.Trabalhista.Verba _verba)
        {
            Codigo = _verba.Codigo;
            Descricao = _verba.Descricao;
            Ativa = _verba.Ativa;
        }
    }
}
