using SCI.View.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCI.View
{
    public partial class Painel : Form
    {
        private Model.Acesso.Usuario usuario;
        private string guid;
        private Model.Linguagem.Idioma idioma;
        private string painel;

        public Painel()
        {
            InitializeComponent();
        }
        public Painel(Model.Acesso.Usuario _usuario, string _guid, Model.Linguagem.Idioma _idioma, string _painel)
        {
            usuario = _usuario;
            guid = _guid;
            idioma = _idioma;
            painel = _painel;
            InitializeComponent();
        }

        private void Painel_Load(object sender, EventArgs e)
        {
            switch (painel)
            {
                case "SISTEMA":
                    Sistema.Monitoramento.Painel _painel = new Sistema.Monitoramento.Painel(new Desktop(usuario,guid,idioma,"IRKO"));
                    Controls.Add(_painel);
                    RealinharCampos();
                    break;
                default:
                    break;
            }
        }

        private void Painel_Resize(object sender, EventArgs e)
        {
            RealinharCampos();
        }

        private void RealinharCampos()
        {
            if (Controls.Cast<BaseForm>().Any())
            {
                BaseForm _control = Controls.Cast<BaseForm>().FirstOrDefault();
                _control.Width = Width - 15;
                _control.Height = Height - 3;
                _control.Left = 1;
                _control.Top = 1;
            }
        }
    }
}
