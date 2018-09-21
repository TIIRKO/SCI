using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Model.Linguagem
{
    public class Idioma
    {
        public string Codigo { set; get; }
        public string Descricao { set; get; }
        public bool Habilitado { set; get; }
        public string Display
        {
            get
            {
                return Descricao;
            }
        }
        public Idioma() { }
        public Idioma(string _codigo, string _descricao, bool _habilitado)
        {
            Codigo = _codigo;
            Descricao = _descricao;
            Habilitado = _habilitado;
        }
        public Idioma(SCI.Idioma.IRKO.Idioma _idioma)
        {
            Codigo = _idioma.Codigo;
            Descricao = _idioma.Descricao;
            Habilitado = _idioma.Habilitado;
        }
    }
}
