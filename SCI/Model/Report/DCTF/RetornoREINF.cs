using System.Collections.Generic;

namespace SCI.Model.Report.DCTF
{
    public class RetornoREINF
    {
        public string Descricao;
        public List<RetornoEvento> Eventos { set; get; } = new List<RetornoEvento>();

        public class RetornoEvento
        {
            public string Descricao { set; get; }
            public List<RetornoArquivo> Arquivos { set; get; } = new List<RetornoArquivo>();
        }

        public class RetornoArquivo
        {
            public string CodigoStatus { set; get; }
            public string DescStatus { set; get; }
            public List<RetornoOcorrencia> Ocorrencias { set; get; } = new List<RetornoOcorrencia>();
            public List<RetornoID> Ids { set; get; } = new List<RetornoID>();
        }
        
        public class RetornoID
        {
            public string ID { set; get; }
            public string CodigoStatus { set; get; }
            public string DescStatus { set; get; }
            public string Recibo { set; get; }
            public List<RetornoOcorrencia> Ocorrencias { set; get; } = new List<RetornoOcorrencia>();
        }

        public class RetornoOcorrencia
        {
            public string Tipo { set; get; }
            public string Localizacao { set; get; }
            public string Codigo { set; get; }
            public string Descricao { set; get; }
        }
    }
}
