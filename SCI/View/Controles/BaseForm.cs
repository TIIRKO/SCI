using System;
using System.ComponentModel;
using System.Windows.Forms;
using SCI.Aspect;
using System.Linq;

namespace SCI.View.Controles
{
    public partial class BaseForm : CustomControl
    {
        [Bindable(true)]
        [Description("Titulo do Formulário.")]
        [Category("Custom")]
        public string Titulo {
            set
            {
                lblTitulo.Text = value;
            }
            get
            {
                return lblTitulo.Text;
            }
        }
        [Bindable(true)]
        [Description("Exibir o Título do Formulário.")]
        [Category("Custom")]
        public bool ExibirTitulo
        {
            set
            {
                pnlTitulo.Visible = value;
            }
            get
            {
                return pnlTitulo.Visible;
            }
        }
        private bool _exibirbotoes { set; get; }
        [Bindable(true)]
        [Description("Exibir os botoões no topo do formulário.")]
        [Category("Custom")]
        public bool ExibirBotoes
        {
            set
            {
                _exibirbotoes = value;
                btnCancelar.Visible = value;
                btnExcluir.Visible = value;
                btnNovo.Visible = value;
                btnSalvar.Visible = value;
            }
            get
            {
                return _exibirbotoes;
            }
        }
        [Bindable(true)]
        [Description("Habilita botão Excluir.")]
        [Category("Custom")]
        public bool Excluir
        {
            set
            {
                btnExcluir.Enabled = value;
            }
            get
            {
                return btnExcluir.Enabled;
            }
        }
        [Bindable(true)]
        [Description("Habilita botão Salvar.")]
        [Category("Custom")]
        public bool Salvar
        {
            set
            {
                btnSalvar.Enabled = value;
            }
            get
            {
                return btnSalvar.Enabled;
            }
        }
        [Bindable(true)]
        [Description("Habilita botão Novo.")]
        [Category("Custom")]
        public bool Cancelar
        {
            set
            {
                btnCancelar.Enabled = value;
            }
            get
            {
                return btnCancelar.Enabled;
            }
        }
        [Bindable(true)]
        [Description("Habilita botão Novo.")]
        [Category("Custom")]
        public bool Novo
        {
            set
            {
                btnNovo.Enabled = value;
            }
            get
            {
                return btnNovo.Enabled;
            }
        }
        [Bindable(true)]
        [Description("Habilita botão Cusom.")]
        [Category("Custom")]
        public bool Custom
        {
            set
            {
                btnCustom.Enabled = value;
            }
            get
            {
                return btnCustom.Enabled;
            }
        }
        [Bindable(true)]
        [Description("Exibe botão Custom.")]
        [Category("Custom")]
        public bool ShowCustom
        {
            set
            {
                btnCustom.Visible = value;
            }
            get
            {
                return btnCustom.Visible;
            }
        }
        [Bindable(true)]
        [Description("Texto do botão Custom.")]
        [Category("Custom")]
        public string TextoCustom
        {
            set
            {
                btnCustom.Text = value;
            }
            get
            {
                return btnCustom.Text;
            }
        }
        [Bindable(true)]
        [Description("Evento disparado ao Fechar o Formulário.")]
        [Category("Custom")]
        public event EventHandler FecharFormulario;
        [Bindable(true)]
        [Description("Evento disparado ao Fechar o Formulário.")]
        [Category("Custom")]
        public event EventHandler RemoverFormulario;
        [Bindable(true)]
        [Description("Evento disparado ao Carregar o Formulário.")]
        [Category("Custom")]
        public event EventHandler AfterLoad;
        [Bindable(true)]
        [Description("Evento disparado pelo botão Excluir.")]
        [Category("Custom")]
        public event EventHandler ExclurClick;
        [Bindable(true)]
        [Description("Evento disparado pelo botão Salvar.")]
        [Category("Custom")]
        public event EventHandler SalvarClick;
        [Bindable(true)]
        [Description("Evento disparado pelo botão Novo.")]
        [Category("Custom")]
        public event EventHandler CancelarClick;
        [Bindable(true)]
        [Description("Evento disparado pelo botão Novo.")]
        [Category("Custom")]
        public event EventHandler NovoClick;
        [Bindable(true)]
        [Description("Evento disparado pelo botão Custom.")]
        [Category("Custom")]
        public event EventHandler BtnCustomClick;
        


        public string Display
        {
            get
            {
                return _Titulo;
            }
        }

        protected Desktop Desktop { set; get; }
        private bool Permiteeditar { set; get; } = true;
        public void SetDesktop(Desktop _desktop)
        {
            Desktop = _desktop;
        }
        public Desktop GetDesktop()
        {
            return Desktop;
        }
        protected string Guid
        {
            get
            {
                return Desktop?.GetGuid();
            }
        }
        protected Acesso.IRKO.Menu Menu { set; get; }
        public void SetMenu(Acesso.IRKO.Menu _menu)
        {
            Menu = _menu;
        }
        public Acesso.IRKO.Menu GetMenu()
        {
            return Menu;
        }
        protected string _Titulo
        {
            get
            {
                if (!String.IsNullOrEmpty(Titulo))
                {
                    return Titulo;
                }
                else if (Menu != null)
                {
                    if (!String.IsNullOrEmpty(Menu.Descricao))
                    {
                        return Menu.Descricao;
                    }
                    else
                    {
                        return Menu.Menu1;
                    }
                }
                return null;
            }
        }

        public BaseForm()
        {
            InitializeComponent();
            //pnlLoading.Visible = false;
        }
        public BaseForm(Desktop _desktop)
        {
            Desktop = _desktop;
            InitializeComponent();
        }

        [FormLoad]
        private void BaseForm_Load(object sender, EventArgs e)
        {
            ResizeForm();
            ResetTitulo();
            ChecaPermissao();
            AfterLoad?.Invoke(this, e);
        }

        private void ChecaPermissao()
        {
            if (_exibirbotoes)
            {
                btnCancelar.Visible = Permiteeditar;
                btnExcluir.Visible = Permiteeditar;
                btnNovo.Visible = Permiteeditar;
                btnSalvar.Visible = Permiteeditar;
                btnCustom.Visible = Permiteeditar;
            }
            else
            {
                btnCancelar.Visible = _exibirbotoes;
                btnExcluir.Visible = _exibirbotoes;
                btnNovo.Visible = _exibirbotoes;
                btnSalvar.Visible = _exibirbotoes;
                btnCustom.Visible = _exibirbotoes;
            }
        }

        private void BaseForm_Resize(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void ResetTitulo()
        {
            Titulo = _Titulo;
        }

        private void ResizeForm()
        {
            int _scrollw = 0;
            if (VerticalScroll.Visible)
                _scrollw = SystemInformation.VerticalScrollBarWidth;

            pnlTitulo.Top = 5;
            pnlTitulo.Left = 5;
            pnlTitulo.Width = Width - (pnlTitulo.Left * 2) - _scrollw;


            if (Controls.Count > 2)
            {
                int _lastComponentPosition = Controls.Cast<Control>().Where(_control => _control.Name != "pnlTitulo" && _control.Name != "pnlLoading")
                    .Max(_control => _control.Left + _control.Width);
                if (pnlTitulo.Width < _lastComponentPosition)
                   pnlTitulo.Width = _lastComponentPosition;
            }

            lblTitulo.Top = 3;
            lblTitulo.Left = 10;
            lblTitulo.Height = pnlTitulo.Height - (lblTitulo.Top * 2);
            lblTitulo.Width = pnlTitulo.Width - (lblTitulo.Left * 2) - pcbFechar.Width - (75 * 5) - 36;

            /*
            pnlLoading.Top = pnlTitulo.Top + pnlTitulo.Height + 3;
            pnlLoading.Left = 5;
            pnlLoading.Width = Width - (pnlLoading.Left * 2);
            pnlLoading.Height = Height - (pnlTitulo.Top + pnlTitulo.Height + 6);

            int _loadingWidth = Width - (pcbLoading.Left * 2);
            if (_loadingWidth < 400)
            {
                pcbLoading.Width = _loadingWidth;
            }
            else
            {
                pcbLoading.Width = 400;
            }
            
            int _loadingHeight = Height - ((pcbLoading.Top - pnlTitulo.Top - pnlTitulo.Height) * 2);
            if (_loadingHeight < 300)
            {
                pcbLoading.Height = _loadingHeight;
            }
            else
            {
                pcbLoading.Height = 300;
            }

            pcbLoading.Top = pnlTitulo.Top + pnlTitulo.Height + 20;
            pcbLoading.Left = (Width / 2) - (pcbLoading.Width / 2);
            */
        }

        /*
        public void ShowLoading()
        {
            pnlLoading.BringToFront();
            pcbLoading.BringToFront();
            pnlLoading.Show();
        }
        public void HideLoading()
        {
            pcbLoading.SendToBack();
            pnlLoading.SendToBack();
            pnlLoading.Hide();
        }
        */

        /*private void BaseForm_Layout(object sender, LayoutEventArgs e)
        {
            pnlLoading.BringToFront();
            pcbLoading.BringToFront();
        }*/

        private void PcbFechar_Click(object sender, EventArgs e)
        {
            Fechar(sender,e);
        }

        public void Fechar(object sender, EventArgs e)
        {
            Desktop.CustomForm_Close(this);
            FecharFormulario?.Invoke(this, e);
        }

        private void BaseForm_ControlRemoved(object sender, ControlEventArgs e)
        {
            RemoverFormulario?.Invoke(this, e);
        }

        // Método para ser implementados nas Telas criadas a partir dessa Base.
        public virtual void TrocarEmpresa() { }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            NovoClick?.Invoke(this, e);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            SalvarClick?.Invoke(this, e);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            ExclurClick?.Invoke(this, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            CancelarClick?.Invoke(this, e);
        }

        private void BtnCustom_Click(object sender, EventArgs e)
        {
            BtnCustomClick?.Invoke(this, e);
        }
    }
}
