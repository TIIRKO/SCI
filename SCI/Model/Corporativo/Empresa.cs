namespace SCI.Model.Corporativo
{
    public class Empresa
    {
        public long Codigo { set; get; }
        public string RazaoSocial { set; get; }
        public string CNPJCPF { set; get; }
        public string Display
        {
        get
            {
                return Codigo.ToString() + " - " + RazaoSocial;
            }
        }
        public StatusDefinition Status { set; get; }

        public enum StatusDefinition
        {
             Bloqueado
            ,Liberado
        }

        public Empresa() { }
        public Empresa(long _codigo, string _razaoSocial, string _cnpjCpf, StatusDefinition _status)
        {
            Codigo = _codigo;
            RazaoSocial = _razaoSocial;
            CNPJCPF = _cnpjCpf;
            Status = _status;
        }
    }
}
