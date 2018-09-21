using System;
using System.Windows.Forms;

namespace SCI.View
{
    public partial class Login : Form
    {
        private string guid;
        private SCI.Idioma.IRKO.Service wrIdioma = new SCI.Idioma.IRKO.Service();
        private Acesso.IRKO.Service wrAcesso = new Acesso.IRKO.Service();

        public Login()
        {
            guid = Guid.NewGuid().ToString("N");
            InitializeComponent();
            PopularIdioma();
        }

        private void TraduzirLabel()
        {
            try
            {
                SCI.Idioma.IRKO.ResultadoCampo _resultado;

                _resultado = wrIdioma.Campo(guid, "IDIOMA", ((SCI.Idioma.IRKO.Idioma)cbbIdioma.SelectedItem).Codigo);
                if (_resultado.Sucesso)
                    gpbIdioma.Text = _resultado.RetornoCampo;
                else
                    MessageBox.Show(_resultado.Mensagem);

                _resultado = wrIdioma.Campo(guid, "USUARIO", ((SCI.Idioma.IRKO.Idioma)cbbIdioma.SelectedItem).Codigo);
                if (_resultado.Sucesso)
                    gpbUsuario.Text = _resultado.RetornoCampo;
                else
                    MessageBox.Show(_resultado.Mensagem);

                _resultado = wrIdioma.Campo(guid, "SENHA", ((SCI.Idioma.IRKO.Idioma)cbbIdioma.SelectedItem).Codigo);
                if (_resultado.Sucesso)
                    gpbSenha.Text = _resultado.RetornoCampo;
                else
                    MessageBox.Show(_resultado.Mensagem);
            }
            catch(Exception _ex)
            {
                MessageBox.Show(_ex.Message);
                Environment.FailFast(_ex.Message);
            }
        }

        private void PopularIdioma()
        {
            SCI.Idioma.IRKO.ResultadoListarIdioma resultadoListarIdioma = wrIdioma.ListarIdiomasHabilitados(guid);
            if (resultadoListarIdioma.Sucesso)
            {
                cbbIdioma.Items.AddRange(resultadoListarIdioma.RetornoListarIdioma);
            }
            else
            {
                MessageBox.Show(resultadoListarIdioma.Mensagem);
            }
            cbbIdioma.SelectedIndex = 0;
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            Acesso.IRKO.ResultadoLogin resuladoLogin = wrAcesso.Login(txtUsuario.Text,txtSenha.Text, ((SCI.Idioma.IRKO.Idioma)cbbIdioma.SelectedItem).Codigo, guid);
            if (resuladoLogin.Sucesso)
            {
                this.Hide();
                Model.Acesso.Usuario _usuario = new Model.Acesso.Usuario(resuladoLogin.RetornoResultadoLogin);

                Model.Linguagem.Idioma _idioma = new Model.Linguagem.Idioma((SCI.Idioma.IRKO.Idioma)cbbIdioma.SelectedItem);

                if (cbbSistema.Text == "Painel Sistema")
                {
                    new Painel(_usuario, guid, _idioma, "SISTEMA").ShowDialog();
                }
                else
                {
                    new Desktop(_usuario, guid, _idioma, cbbSistema.Text).ShowDialog();
                }
           

                this.Close();
            }
            else
            {
                MessageBox.Show(resuladoLogin.Mensagem);
            }
        }

        private void CbbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraduzirLabel();
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnEnviar_Click(sender, e);
            }
        }

        private void TxtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnEnviar_Click(sender, e);
            }
        }
    }
}
