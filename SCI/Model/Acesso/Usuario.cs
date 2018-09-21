using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Model.Acesso
{
    public class Usuario
    {
        public long Codigo { set; get; }
        public string Nome { set; get; }
        public StatusDefinition Status { set; get; }
        public DateTime DataInicio { set; get; }

        public Usuario() {}
        public Usuario(long _codigo, string _nome, StatusDefinition _status, DateTime _dataInicio)
        {
            Codigo = _codigo;
            Nome = _nome;
            Status = _status;
            DataInicio = _dataInicio;
        }
        public Usuario(SCI.Acesso.IRKO.Usuario _usuario)
        {
            Codigo = _usuario.Codigo;
            Nome = _usuario.Nome;
            Status = (StatusDefinition)_usuario.Status;
            DataInicio = _usuario.DataInicio;
        }


        public enum StatusDefinition
        {
             Bloqueado
            ,Liberado
            ,Eliminado
        }
    }
}
