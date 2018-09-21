using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using SCI.Lib;
using System.Globalization;

namespace SCI.View.Controles
{
    public partial class NumericTextBox : CustomControl
    {
        [Bindable(true)]
        [Description("Quantidade de Casas Decimais")]
        public int Escala
        {
            set
            {
                if (value > Tamanho)
                {
                    value = Tamanho;
                }
                _escala = value;
            }
            get { return _escala; }
        }
        private int _escala { set; get; } = 0;
        [Bindable(true)]
        [Description("Quantidade Máxima de números permitidos(incluindo casas decimais)")]
        public int Tamanho {
            set
            {
                if (value < Escala)
                {
                    value = Escala;
                }
                _tamanho = value;

                RealinhaCampos();
            }
            get { return _tamanho; } }
        private int _tamanho { set; get; } = 10;
        [Bindable(true)]
        [Description("Label do componente")]
        public string Label { set { gpbNumeric.Text = value; } get { return gpbNumeric.Text; } }
        [Bindable(true)]
        [Description("Valor padrão")]
        public string Valor { set { txtNumeric.Text = value; } get { return txtNumeric.Text; } }

        public NumericTextBox()
        {
            InitializeComponent();
        }

        private void txtNumeric_TextChanged(object sender, EventArgs e)
        {
            TextBox _sender = (TextBox)sender;
            string _valor = _sender.Text;
            _valor = Regex.Replace(_valor, "[^0-9]", String.Empty);
            if (string.IsNullOrEmpty(_valor))
            {
                _sender.Text = _valor;
            }
            else
            {
                if (_valor.Length > Tamanho)
                {
                    _valor = _valor.Substring(0, Tamanho);
                }
                if (Escala == Tamanho)
                {
                    _valor = "0" + _valor;
                }
                decimal _decimal = decimal.Parse(_valor) / ((decimal)Math.Pow(10, Escala));
                _sender.Text = _decimal.ToString("N" + Escala.ToString());
                _sender.SelectionStart = _sender.Text.Length;
                _sender.SelectionLength = 0;
            }
        }

        private void NumericTextBox_Resize(object sender, EventArgs e)
        {
            RealinhaCampos();
        }

        private void RealinhaCampos()
        {
            gpbNumeric.Width = Width;
            gpbNumeric.Height = Height;

            txtNumeric.Left = (Width - txtNumeric.Width) / 2 ;
            int _width = 0;
            _width += (int)Math.Floor(Library.TamanhoText(
                String.Join("",Enumerable.Repeat("9", Tamanho).ToArray()), txtNumeric.Font));
            {
                _width += (int)Math.Floor(Library.TamanhoText(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, txtNumeric.Font));
            }
            txtNumeric.Width = _width;
        }

        private void NumericTextBox_Load(object sender, EventArgs e)
        {
            RealinhaCampos();
        }
    }
}
