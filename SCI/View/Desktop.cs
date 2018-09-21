using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using SCI.Lib;
using SCI.Aspect;

namespace SCI.View
{
    public partial class Desktop : Form
    {
        private Acesso.IRKO.Service wrAcesso = new Acesso.IRKO.Service();
        private Acesso.IRKOMPACTA.Service wrAcessoKPT = new Acesso.IRKOMPACTA.Service();
        private Model.Acesso.Usuario usuario;
        private string guid;
        private Model.Linguagem.Idioma idioma;
        private string cooperado;
        private Model.Corporativo.Empresa Empresa
        {
            get
            {
                return seletorEmpresa.GetEmpresa();
            }
        }

        public Desktop() { }
        public Desktop(Model.Acesso.Usuario _usuario,string _guid, Model.Linguagem.Idioma _idioma, string _cooperado)
        {
            usuario = _usuario;
            guid = _guid;
            idioma = _idioma;
            cooperado = _cooperado;
            InitializeComponent();
            seletorEmpresa.Desktop = this;
        }

        public Model.Corporativo.Empresa GetEmpresa()
        {
            return Empresa;
        }
        public Model.Acesso.Usuario GetUsuario()
        {
            return usuario;
        }
        public string GetGuid()
        {
            return guid;
        }
        public Model.Linguagem.Idioma GetIdioma()
        {
            return idioma;
        }

        public String GetCooperado()
        {
            return cooperado;
        }

        [FormLoad]
        private void Desktop_Load(object sender, EventArgs e)
        {
            PopularTrvMenu();
            Desktop_Resize(new object(), new EventArgs());
        }

        private void Desktop_Resize(object sender, EventArgs e)
        {
            lblHideShow.Height = spcDesktop.Height;
        }
        private void SpcDesktop_Panel1_Resize(object sender, EventArgs e)
        {
            int _logoWidth = spcDesktop.Panel1.Width - 10;
            int _logoHeight = Convert.ToInt32(_logoWidth / 3.278688524590163934);

            ptbLogo.Height = _logoHeight;
            ptbLogo.Width = _logoWidth;
            pnlLogo.Width = _logoWidth;
            pnlLogo.Height = _logoHeight + 2;

            txtFiltroMenu.Width = _logoWidth;
            txtFiltroMenu.Top = pnlLogo.Height + 5;

            trvMenu.Width = _logoWidth;
            trvMenu.Top = txtFiltroMenu.Top + txtFiltroMenu.Height;
            trvMenu.Height = spcDesktop.Panel1.Height - pnlLogo.Height;
        }
        private void SpcDesktop_Panel2_Resize(object sender, EventArgs e)
        {
            pnlSuperior.Width = spcDesktop.Panel2.Width - lblHideShow.Width;
            pnlSuperior.Left = lblHideShow.Width;

            cbbFormulario.Items.Cast<Controles.BaseForm>().ToList()
                .FindAll(_form => _form != null)
                .ForEach(_form =>
            {
                _form.Width = spcDesktop.Panel2.Width - lblHideShow.Width;
                _form.Height = spcDesktop.Panel2.Height - pnlSuperior.Height;
                _form.Left = lblHideShow.Width;
                _form.Top = pnlSuperior.Height;
            });
        }

        private void LblHideShow_Click(object sender, EventArgs e)
        {
            spcDesktop.Panel1Collapsed = !spcDesktop.Panel1Collapsed;
        }
        private void LblHideShow_MouseEnter(object sender, EventArgs e)
        {
            lblHideShow.BackColor = Color.LightBlue;
        }
        private void LblHideShow_MouseLeave(object sender, EventArgs e)
        {
            lblHideShow.BackColor = Color.Gray;
        }
        private void SpcDesktop_SplitterMoved(object sender, SplitterEventArgs e)
        {
            trvMenu.Focus();
        }
        private void SpcDesktop_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            trvMenu.Focus();
        }
        private void TxtFiltroMenu_TextChanged(object sender, EventArgs e)
        {
            PopularTrvMenu();
        }

        private TreeNode MontarMenuNode(Acesso.IRKO.Menu _menu)
        {
            TreeNode node = new TreeNode(_menu.Menu1)
            {
                Tag = _menu
            };
            if (_menu.MenusInferiores != null && _menu.MenusInferiores.Count() > 0)
            {
                TreeNode[] nodes = _menu.MenusInferiores
                    .Where(__menu => __menu.Status == Acesso.IRKO.MenuStatus.Item1)
                    .Where(__menu => __menu.Tipo == Acesso.IRKO.MenuTipo.Item0 || __menu.Menu1.Normalizar().Contains(txtFiltroMenu.Text.Normalizar()))
                    .ToList().ConvertAll<TreeNode>(__menu => MontarMenuNode(__menu))
                    .Where(__menu => __menu != null)
                    .ToArray();
                if (nodes.Count() > 0)
                {
                    node.Nodes.AddRange(nodes);
                }
            }
            if (((Acesso.IRKO.Menu)node.Tag).Tipo == Acesso.IRKO.MenuTipo.Item0 && node.Nodes.Count == 0)
            {
                node = null;
            }
            else if (node.Nodes.Count == 0)
            {
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
            }
            return node;
        }

        private void PopularTrvMenu()
        {
            trvMenu.Nodes.Clear();
            Acesso.IRKO.ResultadoMontarMenu resultadoMontarMenu = wrAcesso.MontarMenu(guid);
            if (resultadoMontarMenu.Sucesso)
            {
                if (resultadoMontarMenu.RetornoResultadoMontarMenu != null)
                {
                    trvMenu.Nodes.AddRange(resultadoMontarMenu.RetornoResultadoMontarMenu.ToList()
                        .ConvertAll<TreeNode>(_menu => MontarMenuNode(_menu))
                        .Where(_menu => _menu != null)
                        .ToArray());
                }
            }
            else
            {
                MessageBox.Show(resultadoMontarMenu.Mensagem);
            }
        }

        private void AbrirRotina(Acesso.IRKO.Menu _menu)
        {
            Controles.BaseForm _form = null;

            cbbFormulario.Items.Cast<Controles.BaseForm>().ToList()
                .ForEach(_formulario =>
                {
                    if (_formulario.GetMenu().Menu1 == _menu.Menu1)
                    {
                        _form = _formulario;
                        //_form.Show();
                    }
                    else
                    {
                        _formulario.Hide();
                    }
                });

            if (_form is null)
            {
                _form = (Controles.BaseForm)Activator.CreateInstance(Type.GetType(_menu.Programa),  this);
                _form.SetMenu(_menu);
                _form.Width = spcDesktop.Panel2.Width - lblHideShow.Width;
                _form.Height = spcDesktop.Panel2.Height - pnlSuperior.Height;
                _form.Left = lblHideShow.Width;
                _form.Top = pnlSuperior.Height;
                cbbFormulario.Items.Add(_form);
                spcDesktop.Panel2.Controls.Add(_form);

                CheckSelectedCbbFormulario();
            }

            try
            {
                _form.Show();
            }
            catch { }
        }

        private void TrvMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ImageIndex == 1)
            {
                AbrirRotina((Acesso.IRKO.Menu)e.Node.Tag);
            }
        }

        private void TrvMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && ((TreeView)sender).SelectedNode?.ImageIndex == 1)
            {
                AbrirRotina((Acesso.IRKO.Menu)((TreeView)sender).SelectedNode.Tag);
            }
        }

        private void SeletorEmpresa_TrocarEmpresa(object sender, EventArgs e)
        {
            cbbFormulario.Enabled = false;
            trvMenu.Enabled = false;
            cbbFormulario.Items.Cast<Controles.BaseForm>().Where(_form => _form != null)
                .ToList()
                .ForEach(_form =>
                {
                    _form.Enabled = false;
                });
        }
        private void SeletorEmpresa_GravarEmpresa(object sender, EventArgs e)
        {
            cbbFormulario.Enabled = true;
            trvMenu.Enabled = true;
            cbbFormulario.Items.Cast<Controles.BaseForm>().Where(_form => _form != null)
                .ToList()
                .ForEach(_form =>
                {
                    _form.Enabled = true;
                    _form.TrocarEmpresa();
                });
        }


        private void CheckSelectedCbbFormulario()
        {
            if (cbbFormulario.Items.Count > 0)
            {
                if (cbbFormulario.Items.Cast<Controles.BaseForm>().Where(_formulario => _formulario.Visible).Any())
                {
                    cbbFormulario.SelectedItem = cbbFormulario.Items.Cast<Controles.BaseForm>()
                        .Where(_formulario => _formulario.Visible)
                        .First();
                }
                else
                {
                    if (cbbFormulario.SelectedItem == null)
                        cbbFormulario.SelectedItem = cbbFormulario.Items.Cast<Controles.BaseForm>().Last();

                    ((Controles.BaseForm)cbbFormulario.SelectedItem).Show();
                }
            }
            else
            {
                cbbFormulario.Text = String.Empty;
            }
        }

        private void CbbFormulario_SelectedValueChanged(object sender, EventArgs e)
        {
            ((Controles.BaseForm)cbbFormulario.SelectedItem).Show();
            cbbFormulario.Items.Cast<Controles.BaseForm>().ToList()
                .ForEach(_form =>
                {
                    _form.Hide();
                });
            ((Controles.BaseForm)cbbFormulario.SelectedItem).Show();
        }

        public void CustomForm_Close(Controles.BaseForm _form)
        {
            cbbFormulario.Items.Remove(_form);
            spcDesktop.Panel2.Controls.Remove(_form);
            CheckSelectedCbbFormulario();
        }

        public void ShowLoading()
        {

        }
        public void HideLoading()
        {
        }

        private void Desktop_Layout(object sender, LayoutEventArgs e)
        {
        }

        private void SeletorEmpresa_ChecaTrocaEmpresa(object sender, EventArgs e)
        {
            if (cbbFormulario.Items.Cast<Controles.BaseForm>().Where(_form => !_form.GetMenu().PermiteTrocaEmpresa).Any())
            {
                MessageBox.Show("Não é possível trocar a Empresa ativa com as seguintes telas abertas:\n" + String.Join("\n",
                    cbbFormulario.Items.Cast<Controles.BaseForm>().Where(_form => !_form.GetMenu().PermiteTrocaEmpresa)
                        .Select(_form => _form.Titulo).ToArray()));
                ((Controles.SeletorEmpresa)sender).PermiteTrocarEmpresa = false;
            }
            else
            {
                ((Controles.SeletorEmpresa)sender).PermiteTrocarEmpresa = true;
            }
        }

        private void Desktop_FormClosed(object sender, FormClosedEventArgs e)
        {
            Acesso.IRKO.Resultado resultado = wrAcesso.Logout(guid);
            if (!resultado.Sucesso)
            {
                MessageBox.Show(resultado.Mensagem);
            }
        }

        private void AvancarForm()
        {
            if (cbbFormulario.Items.Count > 1)
            {
                cbbFormulario.SelectedIndex = ((cbbFormulario.SelectedIndex + 1)<cbbFormulario.Items.Count)? (cbbFormulario.SelectedIndex + 1) : 0;
            }
        }

        private void VoltarForm()
        {
            if (cbbFormulario.Items.Count > 1)
            {
                cbbFormulario.SelectedIndex = ((cbbFormulario.SelectedIndex - 1) < 0) ? (cbbFormulario.Items.Count - 1) : (cbbFormulario.SelectedIndex - 1);
            }
        }

        private void FecharForm()
        {
            if (cbbFormulario.SelectedItem != null)
            {
                ((Controles.BaseForm)cbbFormulario.SelectedItem).Fechar(new object(), new EventArgs());
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ///MessageBox.Show(keyData.ToString() + "||"+(keyData.ToString() == "A, Tab, Shift, Control").ToString());
            switch (keyData)
            {
                case Keys.Control | Keys.F4:
                    FecharForm();
                    break;
                case Keys.Tab | Keys.Control:
                    AvancarForm();
                    break;
                case Keys.Tab | Keys.Shift | Keys.Control:
                    VoltarForm();
                    break;
                case Keys.Control | Keys.E:
                    seletorEmpresa.Trocar();
                    break;
                case Keys.Control | Keys.M:
                    trvMenu.Focus();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Desktop_Shown(object sender, EventArgs e)
        {
            trvMenu.Focus();
        }
    }
}