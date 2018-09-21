using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SCI.Lib;

namespace SCI.View.Controles
{
    public partial class SearchTextBox : CustomControl
    {
        public Desktop Desktop;

        [Bindable(true)]
        [Description("Valor do ComboBox")]
        public string ComboBoxValue {
            set
            {
                cbbSearchTextBox.Text = value;
                lblReadOnly.Text = value;
            }
            get
            {
                return cbbSearchTextBox.Text;
            }
        }
        [Bindable(true)]
        [Description("Tipo dos itens do ComboBox")]
        public string TipoItem { set; get; }
        [Bindable(true)]
        [Description("Tipo dos itens do ComboBox")]
        public string DisplayMember {
            set
            {
                cbbSearchTextBox.DisplayMember = value;
            }
            get
            {
                return cbbSearchTextBox.DisplayMember;
            }
        }

        [Bindable(true)]
        [Description("Indica se os dados devem vir de um webservice do caché")]
        public bool OrigemWebService { set; get; }
        [Bindable(true)]
        [Description("Serviço de origem dos dados")]
        public string WebService { set; get; }
        [Bindable(true)]
        [Description("Método de origem dos dados")]
        public string Metodo { set; get; }
        [Bindable(true)]
        [Description("Tipo do objeto resultado do web service")]
        public string Resultado { set; get; }
        [Bindable(true)]
        [Description("Propriedade do resultado onde a lista de dados se encontra")]
        public string PropriedadeLista { set; get; }

        [Bindable(true)]
        [Description("Label do campo Funcionário")]
        public string Label
        {
            set
            {
                gpbSearchTextBox.Text = value;
            }
            get
            {
                return gpbSearchTextBox.Text;
            }
        }

        [Bindable(true)]
        [Description("Indica se o campo é somente leitura")]
        public bool ReadOnly
        {
            set
            {
                lblReadOnly.Visible = value;
                cbbSearchTextBox.Visible = !value;
            }
            get
            {
                return lblReadOnly.Visible;
            }
        }
        [Bindable(true)]
        [Description("Evento disparado ao entrar no campo de seleção de funcionário")]
        public event EventHandler ComboBoxEnter;
        [Bindable(true)]
        [Description("Evento disparado ao deixar o campo de seleção de funcionário")]
        public event EventHandler ComboBoxLeave;
        [Bindable(true)]
        [Description("Evento disparado ao deixar trocar o funcionário selecionado")]
        public event EventHandler SelectedItemChange;

        private string guid
        {
            get
            {
                return Desktop?.GetGuid();
            }
        }
        private dynamic[] _itens;

        private List<dynamic> itens
        {
            set
            {
                _itens = value.ToArray();
            }
            get
            {
                return CreateItensList(_itens);
            }
        }
        public void SetItens(List<dynamic> __itens)
        {
            itens = __itens;
        }

        private static List<T> CreateItensList<T>(params T[] __itens)
        {
            if (__itens != null)
            {
                return new List<T>(__itens);
            }
            else
            {
                return null;
            }
        }

        public SearchTextBox()
        {
            InitializeComponent();
        }
        public dynamic GetSelectedItem()
        {
            return Convert.ChangeType(cbbSearchTextBox.SelectedItem, Type.GetType(TipoItem));
        }
        public void SetSelectedItem(dynamic __item)
        {
            cbbSearchTextBox.SelectedItem = Convert.ChangeType(__item, Type.GetType(TipoItem));
        }

        public void Recarregar()
        {
            PopularItens();
        }


        private void SearchTextBox_Load(object sender, EventArgs e)
        {
            RealinhaCampos();
            PopularItens();
        }

        private void PopularItens()
        {
            _itens = null;
            if (Desktop != null && OrigemWebService)
            {
                object referencia = Activator.CreateInstance(Type.GetType(WebService));
                dynamic resultado = referencia.GetType().GetMethod(Metodo).Invoke(referencia,new object[] { guid } );
                resultado = Convert.ChangeType(resultado, Type.GetType(Resultado));
                if (resultado.Sucesso)
                {
                    dynamic[] _tmp = resultado.GetType().GetProperty(PropriedadeLista).GetValue(resultado);
                    if (_tmp != null)
                    {
                        _itens = Array.ConvertAll(_tmp, _i => Activator.CreateInstance(Type.GetType(TipoItem), _i));
                        cbbSearchTextBox.Items.AddRange(_itens);
                    }
                }
                else
                {
                    MessageBox.Show(resultado.Mensagem);
                }
            }
        }

        private void cbbSearchTextBox_TextUpdate(object sender, EventArgs e)
        {
            if (itens?.Where(_i => Library.NormalizarString(_i.GetType().GetProperty(cbbSearchTextBox.DisplayMember).GetValue(_i))
                        .Contains(cbbSearchTextBox.Text.Normalizar())).Any()??false)
            {
                cbbSearchTextBox.Items?.Clear();
                if (!cbbSearchTextBox.DroppedDown)
                    cbbSearchTextBox.DroppedDown = true;

                cbbSearchTextBox.Items?.AddRange(itens
                    .Where(_i => Library.NormalizarString(_i.GetType().GetProperty(cbbSearchTextBox.DisplayMember).GetValue(_i))
                    .Contains(cbbSearchTextBox.Text.Normalizar())).ToArray());
            }
            else if (cbbSearchTextBox.Enabled && cbbSearchTextBox.DroppedDown)
            {
                cbbSearchTextBox.DroppedDown = false;
                cbbSearchTextBox.Items?.Clear();
            }
            cbbSearchTextBox.Select(cbbSearchTextBox.Text.Length, 0);
        }

        private void cbbSearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                cbbSearchTextBox.Text = String.Empty;
                lblReadOnly.Text = String.Empty;
                if (cbbSearchTextBox.Items.Count > 0)
                {
                    cbbSearchTextBox.DroppedDown = false;
                    cbbSearchTextBox.Items.Clear();
                }

                cbbSearchTextBox.Items.AddRange(itens
                    .Where(_i => Library.NormalizarString(_i.GetType().GetProperty(cbbSearchTextBox.DisplayMember).GetValue(_i))
                    .Contains(cbbSearchTextBox.Text.Normalizar())).ToArray());
                cbbSearchTextBox.SelectAll();
            }
        }

        private void cbbSearchTextBox_Enter(object sender, EventArgs e)
        {
            //cbbSearchTextBox.Text = String.Empty;
            //lblReadOnly.Text = String.Empty;
            //cbbSearchTextBox_TextUpdate(new object(), new EventArgs());
            ComboBoxEnter?.Invoke(this, e);
        }

        private void cbbSearchTextBox_Leave(object sender, EventArgs e)
        {
            ComboBoxLeave?.Invoke(this, e);
        }

        private void cbbSearchTextBox_SelectedValueChanged(object sender, EventArgs e)
        {
            lblReadOnly.Text = cbbSearchTextBox.Text;
            SelectedItemChange?.Invoke(this, e);
        }

        private void SearchTextBox_Resize(object sender, EventArgs e)
        {
            RealinhaCampos();
        }

        private void RealinhaCampos()
        {
            gpbSearchTextBox.Width = Width;
            gpbSearchTextBox.Height = Height;

            cbbSearchTextBox.Left = 6;
            cbbSearchTextBox.Width = gpbSearchTextBox.Width - 12;
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            if (cbbSearchTextBox.Visible)
            {
                cbbSearchTextBox.Focus();
            }
        }
    }
}
