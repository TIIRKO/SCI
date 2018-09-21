using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Model.Trabalhista
{
    public class Departamento
    {
        public long Codigo { set; get; }
        public string Descricao { set; get; }

        public Departamento() { }
        public Departamento(long _codigo, string _descricao)
        {
            Codigo = _codigo;
            Descricao = _descricao;
        }
        public Departamento(SCI.Trabalhista.Departamento _departamento)
        {
            Codigo = _departamento.Codigo;
            Descricao = _departamento.Descricao;
        }
    }
}
