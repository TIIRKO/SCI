using System;
using System.Linq;
using System.Windows.Forms;
using SCI.View.Controles;

namespace SCI.View.Idioma
{
    public partial class ControleIdioma : BaseForm
    {
        private SCI.Idioma.IRKO.Service wrIdioma = new SCI.Idioma.IRKO.Service();

        public ControleIdioma()
        {
            InitializeComponent();
        }
        public ControleIdioma(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
            stbIdioma.Desktop = _desktop;
        }

        private void stbIdioma_SelectedItemChange(object sender, EventArgs e)
        {
            SCI.Model.Linguagem.Idioma _idioma = (SCI.Model.Linguagem.Idioma)stbIdioma.GetSelectedItem();
            ckbHabilitado.Checked = _idioma.Habilitado;

            PopularCampo(_idioma);
            PopularMensagem(_idioma);
        }

        private void PopularCampo(SCI.Model.Linguagem.Idioma _idioma)
        {
        /*    dgvCampo.Rows.Clear();
            SCI.Idioma.ResultadoListarCampo _resultadoCampo = wrIdioma.ListarCampos(guid, _idioma.Codigo);
            if (_resultadoCampo.Sucesso)
            {
                _resultadoCampo.RetornoListarCampo?.ToList().ForEach(_campo =>
                {
                    dgvCampo.Rows.Add(new string[] { _campo.Campo1, _campo.Texto });
                });
            }
            else
            {
                MessageBox.Show(_resultadoCampo.Mensagem);
            }*/
        }

        private void PopularMensagem(SCI.Model.Linguagem.Idioma _idioma)
        {
          /*  dgvMensagem.Rows.Clear();
            SCI.Idioma.ResultadoListarMensagens _resultadoMensagem = wrIdioma.ListarMensagens(guid, _idioma.Codigo);
            if (_resultadoMensagem.Sucesso)
            {
                _resultadoMensagem.RetornoListarMensagem?.ToList().ForEach(_mensagem =>
                {
                    dgvMensagem.Rows.Add(new string[] { _mensagem.CodigoMensagem, _mensagem.Texto });
                });
            }
            else
            {
                MessageBox.Show(_resultadoMensagem.Mensagem);
            }*/
        }
    }
}
