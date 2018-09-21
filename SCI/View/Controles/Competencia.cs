using System;
using System.ComponentModel;
using System.Linq;

namespace SCI.View.Controles
{
    public partial class Competencia : CustomControl
    {
        [Bindable(true)]
        [Description("Valor do Campo Data")]
        [Category("Caché")]
        public string Valor
        {
            set
            {
                txtCompetencia.Text = value;
                lblReadOnly.Text = value;
                txtCompetencia_Leave(new object(), new EventArgs());
            }
            get
            {
                return txtCompetencia.Text;
            }
        }
        [Bindable(true)]
        [Description("Texto do Label")]
        [Category("Caché")]
        public string Label
        {
            set
            {
                gpbCompetencia.Text = value;
            }
            get
            {
                return gpbCompetencia.Text;
            }
        }
        [Bindable(true)]
        [Description("Valor da Descrição do Campo")]
        [Category("Caché")]
        public string Descricao
        {
            set
            {
                lblDescricao.Text = value;
            }
            get
            {
                return lblDescricao.Text;
            }
        }
        [Bindable(true)]
        [Description("Valor da Descrição do Campo")]
        [Category("Caché")]
        public string AnoMes
        {
            set
            {
                if (value.Length == 6)
                {
                    Valor = value.Substring(4, 2) + "/" + value.Substring(0,4);
                }
            }
            get
            {
                if (IsValid)
                {
                    if (Valor.Contains("/"))
                    {
                        return Valor.Split('/')[1] + Valor.Split('/')[0];
                    }
                    else
                    {
                        return String.Empty;
                    }
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        [Bindable(true)]
        [Description("Indica se o campo e somente leitura")]
        [Category("Caché")]
        public bool ReadOnly {
            set
            {
                if (value)
                {
                    lblReadOnly.Show();
                    txtCompetencia.Hide();
                }
                else
                {
                    lblReadOnly.Hide();
                    txtCompetencia.Show();
                }
            }
            get
            {
                return lblReadOnly.Visible;
            }
        }

        private string[] meses = { "", "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

        public Competencia()
        {
            InitializeComponent();
        }

        public bool IsValid { set; get; }

        private void Competencia_Resize(object sender, EventArgs e)
        {
            RealinharCampos();
        }
        private void RealinharCampos()
        {
            gpbCompetencia.Width = Width;
            gpbCompetencia.Height = Height;
        }

        private void txtCompetencia_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCompetencia.Text))
            {
                if (txtCompetencia.Text.Contains('/'))
                {
                    string _descMes = txtCompetencia.Text.Split('/')[0];
                    if (String.IsNullOrEmpty(_descMes) || String.IsNullOrWhiteSpace(_descMes))
                        _descMes = "06";
                    string _descAno = txtCompetencia.Text.Split('/')[1];
                    if (String.IsNullOrEmpty(_descAno))
                        _descAno = "2017";
                    if (_descAno.Length == 2)
                        _descAno = "20" + _descAno;
                    txtCompetencia.Text = _descMes + "/" + _descAno;
                    int _mes;
                    if (Int32.TryParse(_descMes, out _mes))
                    {
                        int _ano;
                        if (Int32.TryParse(_descAno, out _ano))
                        {
                            if (_mes >= 1 && _mes <= 12)
                            {
                                if (_ano > 1940)
                                {
                                    IsValid = true;
                                    lblDescricao.Text = meses[_mes] + " de " + _ano.ToString();
                                }
                                else
                                {
                                    IsValid = false;
                                    lblDescricao.Text = "Inválido";
                                }
                            }
                            else
                            {
                                IsValid = false;
                                lblDescricao.Text = "Inválido";
                            }
                        }
                        else
                        {
                            IsValid = false;
                            lblDescricao.Text = "Inválido";
                        }
                    }
                    else
                    {
                        IsValid = false;
                        lblDescricao.Text = "Inválido";
                    }
                }
                else
                {
                    IsValid = false;
                    lblDescricao.Text = "Inválido";
                }
            }
            else
            {
                IsValid = true;
                lblDescricao.Text = String.Empty;
            }
        }

        private void Competencia_Enter(object sender, EventArgs e)
        {
            if (!ReadOnly)
            {
                txtCompetencia.Focus();
            }
        }
    }
}
