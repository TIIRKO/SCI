namespace SCI.Model.Corporativo
{
    public class CentroCusto
    {
        public string Codigo { set; get; }
        public string Descricao { set; get; }
        public string Grupo { set; get; }

        public CentroCusto() { }
        public CentroCusto(string _codigo, string _descricao, string _grupo)
        {
            Codigo = _codigo;
            Descricao = _descricao;
            Grupo = _grupo;
        }
        public CentroCusto(SCI.Trabalhista.CentroCusto _centroCusto)
        {
            Codigo = _centroCusto.Codigo;
            Descricao = _centroCusto.Descricao;
            Grupo = _centroCusto.Descricao;
        }

    }
}
