using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Model.Trabalhista
{
    public class Registro
    {
        public Funcionario Funcionario { set; get; }
        public string Competencia { set; get; }
        public TipoRegistro Tipo { set; get; }
        public FixaRegistro Fixa { set; get; }
        public string TipoProvento { set; get; }
        public Verba Verba { set; get; }
        public decimal Quantidade { set; get; }
        public decimal Valor { set; get; }

        public Registro() { }
        public Registro(SCI.Trabalhista.Registro _registro)
        {
            if (_registro.Funcionario != null)
                Funcionario = new Funcionario(_registro.Funcionario);

            Competencia = _registro.Competencia;
            Tipo = (TipoRegistro)(int)_registro.Tipo;
            Fixa = (FixaRegistro)(int)_registro.Fixa;
            TipoProvento = _registro.TipoProvento;
            if (_registro.Verba != null)
                Verba = new Verba(_registro.Verba);

            Quantidade = _registro.Quantidade;
            Valor = _registro.Valor;
        }

        public long? CodFuncionario { get { return Funcionario?.Codigo; } }
        public string NomeFuncionario { get { return Funcionario?.Nome; } }
        public DateTime? DataAdmissaoFuncionario { get { return Funcionario?.DataAdmissao; } }
        /// <summary>
        /// ToDo
        /// Trocar o Departamento pelo Cargo, está sendo enviado errado.
        /// </summary>
        public string CargoFuncionario { get { return Funcionario?.Departamento.Descricao; } }
        public string CodCentroCusto { get { return Funcionario?.CentroCusto?.Codigo; } }
        public string DescCentroCusto { get { return Funcionario?.CentroCusto?.Descricao; } }
        public string DescTipoProvento { get { return TipoProvento == "R" ? "Proventos" : TipoProvento == "D" ? "Descontos" : "Outros"; } }
        public int OrderTipoProvento { get { return TipoProvento == "R" ? 1: TipoProvento == "D" ? 2 : 3; } }
        public long? CodVerba { get { return Verba?.Codigo; } }
        public string DescVerba { get { return Verba?.Descricao; } }


        public enum FixaRegistro
        {
            OPCAO0, OPCAO1, OPCAO2
        }
        public enum TipoRegistro
        {
            OPCAO300, OPCAO550, OPCAO450, OPCAO620, OPCAO650, OPCAO680
        }

    }
}
