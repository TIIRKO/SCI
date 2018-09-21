using SCI.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SCI.View.Controles
{
    public partial class SeletorEmpresa : CustomControl
    {
        public Desktop Desktop;
        [Bindable(true)]
        [Description("Empresa padrão na criação do Seletor.")]
        public long? EmpresaPadrao { set; get; }
        [Bindable(true)]
        [Description("Empresa padrão na criação do Seletor.")]
        public bool PermiteTrocarEmpresa { set; get; } = true;
        [Bindable(true)]
        [Description("Empresa padrão na criação do Seletor.")]
        public bool PermiteGravarEmpresa { set; get; } = true;
        [Bindable(true)]
        [Description("Evento disparado quando ativar o campo para trocar empresa.")]
        public event EventHandler TrocarEmpresa;
        [Bindable(true)]
        [Description("Evento disparado após a seleção da nova empresa.")]
        public event EventHandler GravarEmpresa;
        [Bindable(true)]
        [Description("Evento para definir se é permitido trocar a empresa ou não.")]
        public event EventHandler ChecaTrocaEmpresa;
        [Bindable(true)]
        [Description("Evento para definir se é permitido gravar a nova empresa ou não.")]
        public event EventHandler ChecaGravaEmpresa;

        private SCI.Corporativo.IRKO.Service wrCorporativo { set; get; } = new SCI.Corporativo.IRKO.Service();
        private Acesso.IRKO.Service wrAcesso { set; get; } = new Acesso.IRKO.Service();
        private Acesso.IRKOMPACTA.Service wrAcessoKPT { set; get; } = new Acesso.IRKOMPACTA.Service();
        private Model.Acesso.Usuario usuario
        {
            get
            {
                if (Desktop != null)
                    return Desktop.GetUsuario();
                else
                    return null;
            }
        }
        private string guid
        {
            get
            {
                if (Desktop != null)
                    return Desktop.GetGuid();
                else
                    return null;
            }
        }
        private Model.Linguagem.Idioma idioma
        {
            get
            {
                if (Desktop != null)
                    return Desktop.GetIdioma();
                else
                    return null;
            }
        }
        private Model.Corporativo.Empresa empresa { set; get; }
        private long codigoEmpresa
        {
            set
            {
                Model.Corporativo.Empresa _empresa = empresas.Find(__empresa => __empresa.Codigo == value);
                if (_empresa != null)
                {
                    if ((cbbEmpresa.SelectedItem == null) || (!_empresa.Codigo.Equals(((Model.Corporativo.Empresa)cbbEmpresa.SelectedItem).Codigo)))
                    {
                        cbbEmpresa.SelectedItem = _empresa;
                        empresa = _empresa;
                        Acesso.IRKO.Resultado resultado = wrAcesso.SelecionarEmpresa(guid, ((Model.Corporativo.Empresa)cbbEmpresa.SelectedItem).Codigo.ToString());
                        if (!resultado.Sucesso)
                        {
                            MessageBox.Show(resultado.Mensagem);
                        }
                    }
                    else if (cbbEmpresa.SelectedItem == null)
                    {
                        cbbEmpresa.SelectedItem = _empresa;
                        empresa = _empresa;
                        Acesso.IRKO.Resultado resultado = wrAcesso.SelecionarEmpresa(guid, ((Model.Corporativo.Empresa)cbbEmpresa.SelectedItem).Codigo.ToString());
                        if (!resultado.Sucesso)
                        {
                            MessageBox.Show(resultado.Mensagem);
                        }
                    }
                }
            }
            get
            {
                return empresa?.Codigo??0;
            }
        }
        private bool empresaSelected { set; get; }
        private List<Model.Corporativo.Empresa> empresas = new List<Model.Corporativo.Empresa>();

        public SeletorEmpresa()
        {
            InitializeComponent();
        }

        public long GetCodigoEmpresa()
        {
            return codigoEmpresa;
        }
        public void SetCodigoEmpresa(long _codigoEmpresa)
        {
            codigoEmpresa = _codigoEmpresa;
        }

        public Model.Corporativo.Empresa GetEmpresa()
        {
            return empresa;
        }
        public void SetEmpresa(Model.Corporativo.Empresa _empresa)
        {
            empresa = _empresa;
        }

        private void AtualizaValorEmpresa()
        {
            //cbbEmpresa.SelectedItem = cbbEmpresa.Items.Cast<Model.Corporativo.Empresa>().ToList()
            //    .Find(_empresa => _empresa.Codigo == codigoEmpresa);
        }

        public void Trocar()
        {
            if (btnAcao.Text == btnAcaoText.Trocar.ToString())
                btnAcao.PerformClick();
        }


        private void SeletorEmpresa_Resize(object sender, EventArgs e)
        {
            RealinhaCampos();
        }
        private void RealinhaCampos()
        {
            gpbEmpresa.Width = Width;
            gpbEmpresa.Height = Height;

            btnAcao.Text = "Trocar";
            btnAcao.Left = gpbEmpresa.Width - btnAcao.Width - 3;

            cbbEmpresa.Left = 3;
            cbbEmpresa.Width = (-3) + gpbEmpresa.Width - 3 - btnAcao.Width - 3;
        }

        private void SeletorEmpresa_Load(object sender, EventArgs e)
        {
            RealinhaCampos();
            PopularCbbEmpresa();
            if (EmpresaPadrao != null)
            {
                codigoEmpresa = EmpresaPadrao??999;
            }
        }

        private void PopularCbbEmpresa()
        {
            if (Desktop != null)
            {
                SCI.Corporativo.IRKO.ResultadoListarEmpresa resultadoListarEmpresa = wrCorporativo.ListarEmpresa(guid);
                if (resultadoListarEmpresa.Sucesso)
                {
                    if (resultadoListarEmpresa.RetornoListarEmpresa != null)
                    {
                        empresas = resultadoListarEmpresa.RetornoListarEmpresa.ToList()
                            .ConvertAll<Model.Corporativo.Empresa>(_empresa =>
                                new Model.Corporativo.Empresa(_empresa.Codigo, _empresa.RazaoSocial, _empresa.CNPJCPF,
                                    (Model.Corporativo.Empresa.StatusDefinition)_empresa.Status));
                        cbbEmpresa.Items.AddRange(empresas.ToArray());
                    }
                }
                else
                {
                    MessageBox.Show(resultadoListarEmpresa.Mensagem);
                }
            }
        }

        private void cbbEmpresa_TextUpdate(object sender, EventArgs e)
        {
            empresaSelected = false;
            if (empresas.Where(_empresa => _empresa.Display.Normalizar().Contains(cbbEmpresa.Text.Normalizar())).Count() > 0)
            {
                cbbEmpresa.Items.Clear();
                if (!cbbEmpresa.DroppedDown)
                    cbbEmpresa.DroppedDown = true;
                cbbEmpresa.Items.AddRange(empresas
                    .Where(_empresa => _empresa.Display.Normalizar().Contains(cbbEmpresa.Text.Normalizar())).ToArray());
            }
            else if (cbbEmpresa.Enabled && cbbEmpresa.DroppedDown)
            {
                cbbEmpresa.DroppedDown = false;
                cbbEmpresa.Items.Clear();
            }
            cbbEmpresa.Select(cbbEmpresa.Text.Length, 0);
        }
        private void cbbEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbEmpresa.SelectedItem != null)
                empresaSelected = true;
        }

        private enum btnAcaoText
        {
            Trocar
           , Gravar
        };

        private void btnAcao_Click(object sender, EventArgs e)
        {
            if (btnAcao.Text == btnAcaoText.Trocar.ToString())
            {
                ChecaTrocaEmpresa?.Invoke(this, e);
                if (PermiteTrocarEmpresa)
                {
                    empresaSelected = false;
                    btnAcao.Text = btnAcaoText.Gravar.ToString();
                    cbbEmpresa.Enabled = true;
                    TrocarEmpresa?.Invoke(this, e);
                    cbbEmpresa.Select();
                }
            }
            else if (btnAcao.Text == btnAcaoText.Gravar.ToString())
            {
                ChecaGravaEmpresa?.Invoke(this, e);
                if (PermiteGravarEmpresa)
                {
                    if (cbbEmpresa.Text.Equals("") || cbbEmpresa.SelectedItem is null)
                    {
                        empresaSelected = false;
                        cbbEmpresa.Text = "";
                        cbbEmpresa.SelectedItem = null;
                        MessageBox.Show("Campo empresa não pode ser vazio");
                        return;
                    }

                    Acesso.IRKO.Resultado resultado = wrAcesso.SelecionarEmpresa(guid, ((Model.Corporativo.Empresa)cbbEmpresa.SelectedItem).Codigo.ToString());
                    if (resultado.Sucesso)
                    {
                        empresa = (Model.Corporativo.Empresa)cbbEmpresa.SelectedItem;
                        btnAcao.Text = btnAcaoText.Trocar.ToString();
                        AtualizaValorEmpresa();
                        GravarEmpresa?.Invoke(this, e);
                        cbbEmpresa.Enabled = false;
                    }
                    else
                    {
                        cbbEmpresa.Text = "";
                        empresaSelected = false;
                        cbbEmpresa.SelectedItem = null;
                        MessageBox.Show(resultado.Mensagem);
                        return;
                    }
                }
            }
        }

        private void cbbEmpresa_Enter(object sender, EventArgs e)
        {
            cbbEmpresa.Text = String.Empty;
            empresaSelected = false;
            cbbEmpresa_TextUpdate(new object(), new EventArgs());
        }

        private void cbbEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (empresaSelected)
                {
                    if (cbbEmpresa.SelectedItem != null)
                    {
                        btnAcao.PerformClick();
                    }
                }
                else
                {
                    Model.Corporativo.Empresa _empresa = empresas.Find(__empresa => __empresa.Codigo.ToString().Normalizar().Equals(cbbEmpresa.Text.Normalizar()));
                    if (_empresa != null)
                    {
                        empresaSelected = true;
                        cbbEmpresa.SelectedItem = _empresa;
                        cbbEmpresa.Text = _empresa.Display;
                        btnAcao.PerformClick();
                    }
                }
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                empresaSelected = false;
                cbbEmpresa.Text = "";
                if (cbbEmpresa.Items.Count > 0)
                {
                    cbbEmpresa.DroppedDown = false;
                    cbbEmpresa.Items.Clear();
                }

                cbbEmpresa.Items.AddRange(empresas
                    .Where(_empresa => _empresa.Display.Normalizar().Contains(cbbEmpresa.Text.Normalizar())).ToArray());
                AtualizaValorEmpresa();
                cbbEmpresa.SelectAll();
            }
        }
    }
}
