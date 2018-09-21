using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCI.Lib;

namespace SCI.View.Controles
{
    public partial class Funcionario : CustomControl
    {
        public Desktop Desktop;

        [Bindable(true)]
        [Description("Label do campo Funcionário")]
        public string Label
        {
            set
            {
                gpbFuncionario.Text = value;
            }
            get
            {
                return gpbFuncionario.Text;
            }
        }
        [Bindable(true)]
        [Description("Evento disparado ao entrar no campo de seleção de funcionário")]
        public event EventHandler FuncionarioEnter;
        [Bindable(true)]
        [Description("Evento disparado ao deixar o campo de seleção de funcionário")]
        public event EventHandler FuncionarioLeave;
        [Bindable(true)]
        [Description("Evento disparado ao deixar trocar o funcionário selecionado")]
        public event EventHandler SelectedItemChance;

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
        private SCI.Trabalhista.AcessoTrabalhista wrTrabalhista = new SCI.Trabalhista.AcessoTrabalhista();
        private List<Model.Trabalhista.Funcionario> funcionarios = new List<Model.Trabalhista.Funcionario>();
        private long codigoFuncionario {
            set
            {
                Model.Trabalhista.Funcionario _funcionario = funcionarios.Find(__funcionario => __funcionario.Codigo == value);
                if (_funcionario != null)
                {
                    if ((cbbFuncionario.SelectedItem == null) || (!_funcionario.Codigo.Equals(((Model.Trabalhista.Funcionario)cbbFuncionario.SelectedItem).Codigo)))
                    {
                        cbbFuncionario.SelectedItem = _funcionario;
                    }
                    else if (cbbFuncionario.SelectedItem == null)
                    {
                        cbbFuncionario.SelectedItem = _funcionario;
                    }
                }
            }
            get
            {
                return ((Model.Trabalhista.Funcionario)cbbFuncionario.SelectedItem)?.Codigo??0;
            }
        }

        public Funcionario()
        {
            InitializeComponent();
        }

        public long GetCodigoFuncionario()
        {
            return codigoFuncionario;
        }
        public void SetCodigoEmpresa(long _codigoFuncionario)
        {
            codigoFuncionario = _codigoFuncionario;
        }

        public Model.Trabalhista.Funcionario GetFuncionario()
        {
            return (Model.Trabalhista.Funcionario)cbbFuncionario.SelectedItem;
        }
        public void SetFuncionario(Model.Trabalhista.Funcionario _funcionario)
        {
            cbbFuncionario.SelectedItem = _funcionario;
        }

        private void Funcionario_Resize(object sender, EventArgs e)
        {
            RealinhaCampos();
        }

        private void RealinhaCampos()
        {
            gpbFuncionario.Width = Width;
            gpbFuncionario.Height = Height;

            cbbFuncionario.Left = 6;
            cbbFuncionario.Width = gpbFuncionario.Width - 12;
        }

        private void Funcionario_Load(object sender, EventArgs e)
        {
            RealinhaCampos();
            PopularCbbFuncionario();
        }

        private void PopularCbbFuncionario()
        {
            if (Desktop != null)
            {
                SCI.Trabalhista.ResultadoListarFuncionario resultadoListarFuncionario = wrTrabalhista.ListarFuncionario(guid);
                if (resultadoListarFuncionario.Sucesso)
                {
                    if (resultadoListarFuncionario.RetornoListarFuncionario != null)
                    {
                        funcionarios = resultadoListarFuncionario.RetornoListarFuncionario.ToList()
                            .ConvertAll<Model.Trabalhista.Funcionario>(_funcionario =>
                                new Model.Trabalhista.Funcionario(_funcionario.Codigo, _funcionario.Nome, _funcionario.Ativo,_funcionario.Admissao));
                        cbbFuncionario.Items.AddRange(funcionarios.ToArray());
                    }
                }
                else
                {
                    MessageBox.Show(resultadoListarFuncionario.Mensagem);
                }
            }
        }

        private void cbbFuncionario_TextUpdate(object sender, EventArgs e)
        {
            if (funcionarios.Where(_funcionario => _funcionario.Display.Normalizar().Contains(cbbFuncionario.Text.Normalizar())).Any())
            {
                cbbFuncionario.Items.Clear();
                if (!cbbFuncionario.DroppedDown)
                    cbbFuncionario.DroppedDown = true;
                cbbFuncionario.Items.AddRange(funcionarios
                    .Where(_funcionario => _funcionario.Display.Normalizar().Contains(cbbFuncionario.Text.Normalizar())).ToArray());
            }
            else if (cbbFuncionario.Enabled && cbbFuncionario.DroppedDown)
            {
                cbbFuncionario.DroppedDown = false;
                cbbFuncionario.Items.Clear();
            }
            cbbFuncionario.Select(cbbFuncionario.Text.Length, 0);
        }

        private void cbbFuncionario_Enter(object sender, EventArgs e)
        {
            cbbFuncionario.Text = String.Empty;
            cbbFuncionario_TextUpdate(new object(), new EventArgs());
            FuncionarioEnter?.Invoke(this, e);
        }

        private void cbbFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cbbFuncionario.Text = "";
                if (cbbFuncionario.Items.Count > 0)
                {
                    cbbFuncionario.DroppedDown = false;
                    cbbFuncionario.Items.Clear();
                }

                cbbFuncionario.Items.AddRange(funcionarios
                    .Where(_funcionario => _funcionario.Display.Normalizar().Contains(cbbFuncionario.Text.Normalizar())).ToArray());
                cbbFuncionario.SelectAll();
            }
        }

        private void cbbFuncionario_Leave(object sender, EventArgs e)
        {
            FuncionarioLeave?.Invoke(this, e);
        }

        private void cbbFuncionario_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectedItemChance?.Invoke(this, e);
        }

        private void Funcionario_Enter(object sender, EventArgs e)
        {
            if (cbbFuncionario.Visible)
            {
                cbbFuncionario.Focus();
            }
        }
    }
}
