using System;

namespace SCI.Model.Trabalhista
{
    public class Funcionario
    {
        public long Codigo { set; get; }
        public string Nome { set; get; }
        public bool Ativo { set; get; }
        public SCI.Model.Corporativo.CentroCusto CentroCusto { set; get; }
        public Departamento Departamento { set; get; }
        public DateTime DataAdmissao { set; get; }
        public string Display
        {
            get
            {
                return Codigo.ToString() + " - " + Nome + " ( " + (Ativo?"A":"I") + " )";
            }
        }

        public Funcionario() { }
        public Funcionario(long _codigo, string _nome, bool _ativo, DateTime _dataAdmissao , SCI.Model.Corporativo.CentroCusto _centroCusto = null, Departamento _departamento = null)
        {
            Codigo = _codigo;
            Nome = _nome;
            Ativo = _ativo;
            DataAdmissao = _dataAdmissao;
            CentroCusto = _centroCusto;
            Departamento = _departamento;
        }
        public Funcionario(SCI.Trabalhista.Funcionario _funcionario)
        {
            Codigo = _funcionario.Codigo;
            Nome = _funcionario.Nome;
            Ativo = _funcionario.Ativo;
            DataAdmissao = _funcionario.Admissao;
            if (_funcionario.CentroCusto != null)
                CentroCusto = new SCI.Model.Corporativo.CentroCusto(_funcionario.CentroCusto);

            if (_funcionario.Departamento != null)
                Departamento = new Departamento(_funcionario.Departamento);
        }
    }
}
