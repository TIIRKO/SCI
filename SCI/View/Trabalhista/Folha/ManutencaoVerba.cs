using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SCI.View.Controles;

namespace SCI.View.Trabalhista.Folha
{
    public partial class ManutencaoVerba : BaseForm
    {
        private Model.Trabalhista.Verba verbaSalario { set; get; }
        private List<SCI.Trabalhista.Registro> registros = new List<SCI.Trabalhista.Registro>();
        private SCI.Trabalhista.AcessoTrabalhista wrTrabalhista = new SCI.Trabalhista.AcessoTrabalhista();
        public enum VerbaFixa
        {
             Calculada
            , Fixa
            , Variável
        }
        public ManutencaoVerba()
        {
            InitializeComponent();
        }
        public ManutencaoVerba(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
            stbFuncionario.Desktop = _desktop;
            stbVerba.Desktop = _desktop;
        }
        private void ManutencaoVerba_AfterLoad(object sender, EventArgs e)
        {
            Novo = false;
            Cancelar = false;
            Excluir = false;
            Salvar = false;
            Custom = false;
            SCI.Trabalhista.ResultadoRecuperarParametro resultadoRecuperaParameto = wrTrabalhista.RecuperarParametro(Guid);
            if (resultadoRecuperaParameto.Sucesso)
            {
                cptAtual.AnoMes = resultadoRecuperaParameto.AnoMesAtual;
                cptCompetencia.AnoMes = resultadoRecuperaParameto.AnoMesAtual;
                if (resultadoRecuperaParameto.VerbaSalario != null)
                    verbaSalario = new Model.Trabalhista.Verba(resultadoRecuperaParameto.VerbaSalario);
                else
                    verbaSalario = null;
            }
        }
        private void ManutencaoVerba_Load(object sender, EventArgs e)
        {
            RealinharCampos();
        }
        private void ManutencaoVerba_Resize(object sender, EventArgs e)
        {
            RealinharCampos();
        }
        private void RealinharCampos()
        {
            int _left = ((Width / 2) - (pnlMovel.Width / 2));
            pnlMovel.Left = _left < 0 ? 0 : _left;
        }

        private bool LiberaNovo()
        {
            return (stbFuncionario.GetSelectedItem() != null
                    && ((Model.Trabalhista.Funcionario)stbFuncionario.GetSelectedItem()).Ativo
                    && cptAtual.AnoMes == cptCompetencia.AnoMes
                    && tbcVerbas.SelectedTab != tbpFerias
                    && !gpbNovaVerba.Visible);
        }
        private bool LiberaCalcular()
        {
            return (((Model.Trabalhista.Funcionario)stbFuncionario.GetSelectedItem()).Ativo
                      && cptAtual.AnoMes == cptCompetencia.AnoMes
                      && tbcVerbas.SelectedTab != tbpFerias);
        }

        private void PopularVerbaCadastrada(SCI.Trabalhista.Registro[] _registros)
        {
            registros = _registros.ToList();
            _registros.OrderBy(_r => (_r.TipoProvento=="R"?1:(_r.TipoProvento=="D"?2:3))).ThenBy(_r => _r.Verba.Codigo).ToList().ForEach(_r =>
            {
                DataGridView _dgvTemp = null;
                string[] _row = null;
                switch (_r.Tipo)
                {
                    case SCI.Trabalhista.RegistroTipo.Item300:
                        _dgvTemp = dgvPagamento;
                        break;
                    case SCI.Trabalhista.RegistroTipo.Item550:
                        _dgvTemp = dgvAdiantamento;
                        break;
                    case SCI.Trabalhista.RegistroTipo.Item450:
                        _dgvTemp = dgv13Salario;
                        break;
                    case SCI.Trabalhista.RegistroTipo.Item620:
                        _dgvTemp = dgvFeriasBloco1;
                        break;
                    case SCI.Trabalhista.RegistroTipo.Item650:
                        _dgvTemp = dgvFeriasBloco2;
                        break;
                    case SCI.Trabalhista.RegistroTipo.Item680:
                        _dgvTemp = dgvFeriasBloco3;
                        break;
                }
                string _fixa = String.Empty;
                if (_r.FixaSpecified)
                {
                    if (_r.Fixa == SCI.Trabalhista.RegistroFixa.Item0)
                        _fixa = VerbaFixa.Calculada.ToString();
                    else if (_r.Fixa == SCI.Trabalhista.RegistroFixa.Item1)
                        _fixa = VerbaFixa.Fixa.ToString();
                    else if (_r.Fixa == SCI.Trabalhista.RegistroFixa.Item2)
                        _fixa = VerbaFixa.Variável.ToString();
                }

                string _verba = _r.Verba.Codigo.ToString() + " - " + _r.Verba.Descricao;
                string _valor = _r.Valor.ToString("#,##0.00") + " (" + _r.TipoProvento + ")";
                if (_r.TipoProvento == "R")
                {
                    _row = new string[] { _verba, _fixa, _r.Quantidade.ToString("#"), _valor, String.Empty };
                }
                else
                {
                    _row = new string[] { _verba, _fixa, _r.Quantidade.ToString("#"), String.Empty, _valor };
                }
                _dgvTemp.Rows.Add(_row);
            });
        }

        private void AtualizarVerbas()
        {
            Novo = false;
            Custom = false;
            registros.Clear();
            dgvPagamento.Rows.Clear();
            dgvAdiantamento.Rows.Clear();
            dgv13Salario.Rows.Clear();
            dgvFeriasBloco1.Rows.Clear();
            dgvFeriasBloco2.Rows.Clear();
            dgvFeriasBloco3.Rows.Clear();

            if (!String.IsNullOrEmpty(cptCompetencia.AnoMes) && stbFuncionario.GetSelectedItem() != null)
            {
                if (LiberaNovo())
                    Novo = true;
                if (LiberaCalcular())
                    Custom = true;

                SCI.Trabalhista.ResultadoListarVerbaCadastrada resultado = wrTrabalhista.ListarVerbaCadastrada(Guid, cptCompetencia.AnoMes, ((Model.Trabalhista.Funcionario)stbFuncionario.GetSelectedItem())?.Codigo.ToString());
                if (resultado.Sucesso)
                {
                    if (resultado.RetornoListarVerbaCadastrada != null)
                    {
                        PopularVerbaCadastrada(resultado.RetornoListarVerbaCadastrada);
                    }
                }
                else
                {
                    MessageBox.Show(resultado.Mensagem);
                }
            }
        }

        private void cptCompetencia_Leave(object sender, EventArgs e)
        {
            AtualizarVerbas();
        }

        private void stbFuncionario_SelectedItemChange(object sender, EventArgs e)
        {
            AtualizarVerbas();
        }


        private void ManutencaoVerba_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                cptAtual.Focus();
            }
        }

        private void ManutencaoVerba_NovoClick(object sender, EventArgs e)
        {
            if (cptCompetencia.IsValid)
            {
                if (stbFuncionario.GetSelectedItem() != null)
                {
                    if (tbcVerbas.SelectedTab != tbpFerias)
                    {
                        tbcVerbas.Top = 205;

                        gpbNovaVerba.Visible = true;
                        cptCompetencia.ReadOnly = true;
                        stbFuncionario.ReadOnly = true;

                        stbVerba.SetSelectedItem(null);
                        txtQuantidade.Text = "";
                        txtValor.Text = "";

                        Novo = false;
                        Salvar = true;
                        Cancelar = true;
                    }
                    else
                    {
                        MessageBox.Show("Lançamento de Férias por esta tela está indisponível");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Funcionário.");
                    stbFuncionario.Focus();
                }
            }
            else
            {
                MessageBox.Show("Competência inválida.");
                cptCompetencia.Focus();
            }
        }

        private void ManutencaoVerba_CancelarClick(object sender, EventArgs e)
        {
            tbcVerbas.Top = 121;

            gpbNovaVerba.Visible = false;
            cptCompetencia.ReadOnly = false;
            stbFuncionario.ReadOnly = false;

            stbVerba.SetSelectedItem(null);
            txtQuantidade.Text = "";
            txtValor.Text = "";

            Novo = true;
            Salvar = false;
            Cancelar = false;

            tbcVerbas.TabPages.Cast<TabPage>().ToList().ForEach(_tab =>
            {
                if (!tbcVerbas.SelectedTab.Equals(_tab))
                {
                    ((Control)_tab).Enabled = true;
                }
            });
        }

        private void tbcVerbas_Selecting(object sender, TabControlCancelEventArgs e)
        {
            Control _control = e.TabPage.Controls.Cast<Control>().First();

            if (_control is DataGridView)
            {
                if (LiberaNovo())
                {
                }
                else
                {
                    if (((DataGridView)_control).Rows.Count == 0)
                    {
                        e.Cancel = true;
                    }
                }
            }
            else if (_control is TabControl)
            {
                bool _show = false;
                ((TabControl)_control).TabPages.Cast<TabPage>().ToList().ForEach(_page =>
                {
                    Control __control = _page.Controls.Cast<Control>().First();
                    if (((DataGridView)__control).Rows.Count > 0)
                    {
                        _show = true;
                    }
                });
                if (!_show)
                {
                    e.Cancel = true;
                }
            }

            if (Salvar)
            {
                e.Cancel = true;
            }

            if (!e.Cancel)
            {
                if (e.TabPage == tbpFerias)
                {
                    Novo = false;
                    Custom = false;
                }
                else
                {
                    if (LiberaNovo())
                        Novo = true;
                    if (LiberaCalcular())
                        Custom = true;
                }
            }
        }

        private void ManutencaoVerba_SalvarClick(object sender, EventArgs e)
        {
            TabPage _tab = tbcVerbas.SelectedTab;
            if (_tab != tbpFerias)
            {
                DataGridView _grid = null;
                _grid = _tab.Controls.Cast<DataGridView>().Where(_c => _c is DataGridView).FirstOrDefault();
                if (_grid != null)
                {
                    if (stbVerba.GetSelectedItem() is null)
                    {
                        MessageBox.Show("Verba é obrigatório");
                        stbVerba.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtQuantidade.Valor) && String.IsNullOrEmpty(txtValor.Valor))
                    {
                        MessageBox.Show("Quantidade ou valor devem ser preenchidos");
                        txtQuantidade.Focus();
                        return;
                    }

                    string _tipoRegistro = _grid.Tag.ToString();
                    string _tipoVerba = rdbVariavel.Checked ? "V" : "F";
                    SCI.Trabalhista.Resultado _resultado = wrTrabalhista.GravarVerba(Guid, cptAtual.AnoMes,
                        ((Model.Trabalhista.Funcionario)stbFuncionario.GetSelectedItem()).Codigo.ToString(),
                        _tipoRegistro, _tipoVerba, ((Model.Trabalhista.Verba)stbVerba.GetSelectedItem()).Codigo.ToString(),
                        txtQuantidade.Valor, txtValor.Valor);

                    if (_resultado.Sucesso)
                    {
                        AtualizarVerbas();
                        ChecaVerbaTipo();
                        stbVerba.Focus();
                    }
                    else
                    {
                        MessageBox.Show(_resultado.Mensagem);
                        AtualizarVerbas();
                        stbVerba.Focus();
                    }
                }
            }
        }

        private void ManutencaoVerba_ExclurClick(object sender, EventArgs e)
        {
            TabPage _tab = tbcVerbas.SelectedTab;
            if (_tab != tbpFerias)
            {
                DataGridView _grid = null;
                _grid = _tab.Controls.Cast<DataGridView>().Where(_c => _c is DataGridView).FirstOrDefault();
                if (_grid != null)
                {
                    if (_grid.SelectedRows.Count > 0)
                    {
                        string _tipoRegistro;
                        string _codigoverba;
                        SCI.Trabalhista.Resultado _resultado;

                        _tipoRegistro = _grid.Tag.ToString();
                        _codigoverba = String.Join("^",_grid.SelectedRows.Cast<DataGridViewRow>()
                            .Where(_row => _row.Cells[1].Value.ToString() == VerbaFixa.Fixa.ToString())
                            .Select(_row => _row.Cells[0].Value.ToString().Split('-')[0].Replace(" ",String.Empty)));
                        if (!String.IsNullOrEmpty(_codigoverba))
                        {
                            _resultado = wrTrabalhista.ExcluirVerba(Guid, cptCompetencia.AnoMes,
                                ((Model.Trabalhista.Funcionario)stbFuncionario.GetSelectedItem()).Codigo.ToString(), _tipoRegistro,
                                "F", _codigoverba);
                        }

                        _tipoRegistro = _grid.Tag.ToString();
                        _codigoverba = String.Join("^", _grid.SelectedRows.Cast<DataGridViewRow>()
                            .Where(_row => _row.Cells[1].Value.ToString() == VerbaFixa.Variável.ToString())
                            .Select(_row => _row.Cells[0].Value.ToString().Split('-')[0].Replace(" ", String.Empty)));
                        if (!String.IsNullOrEmpty(_codigoverba))
                        {
                            _resultado = wrTrabalhista.ExcluirVerba(Guid, cptCompetencia.AnoMes,
                            ((Model.Trabalhista.Funcionario)stbFuncionario.GetSelectedItem()).Codigo.ToString(), _tipoRegistro,
                            "V", _codigoverba);
                        }
                        AtualizarVerbas();
                        _grid.Select();
                    }
                    else
                    {
                        MessageBox.Show("É necessário selecionar quais Verbas deseja excluir.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Manutenção de férias ainda não implementada.");
            }
        }

        private void tbcFerias_Selecting(object sender, TabControlCancelEventArgs e)
        {
            Control _control = e.TabPage.Controls.Cast<Control>().First();

            if (_control is DataGridView)
            {
                if (((DataGridView)_control).Rows.Count == 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ChecaVerbaTipo()
        {
            gpbSalario.Hide();
            tbcVerbas.Show();
            txtQuantidade.Show();
            txtValor.Show();
            if ((rdbFixa.Checked || rdbVariavel.Checked) && stbVerba.GetSelectedItem() != null)
            {
                DataGridView _dgv = tbcVerbas.SelectedTab.Controls.Cast<DataGridView>().First();
                SCI.Trabalhista.RegistroFixa _fixa = SCI.Trabalhista.RegistroFixa.Item2;
                if (rdbFixa.Checked)
                {
                    _fixa = SCI.Trabalhista.RegistroFixa.Item1;
                }
                long _codigoverba = ((Model.Trabalhista.Verba)stbVerba.GetSelectedItem()).Codigo;
                SCI.Trabalhista.Registro _registro = registros
                    .Where(__registro => (__registro.Fixa == _fixa && __registro.Verba.Codigo == _codigoverba))
                    .FirstOrDefault();

                if (_registro != null)
                {
                    txtQuantidade.Valor = _registro.Quantidade.ToString();
                    txtValor.Valor = _registro.Valor.ToString();
                }
                else
                {
                    txtQuantidade.Valor = String.Empty;
                    txtValor.Valor = String.Empty;
                }

                if (verbaSalario?.Codigo == _codigoverba && rdbFixa.Checked)
                {
                    tbcVerbas.Hide();
                    txtQuantidade.Hide();
                    txtValor.Hide();
                    gpbSalario.Show();
                }
            }
            else
            {
                txtQuantidade.Text = String.Empty;
                txtValor.Text = String.Empty;
            }
        }

        private void rdbFixa_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ChecaVerbaTipo();
            }
        }

        private void rdbVariavel_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ChecaVerbaTipo();
            }
        }

        private void stbVerba_SelectedItemChange(object sender, EventArgs e)
        {
            ChecaVerbaTipo();
        }

        private void ManutencaoVerba_BtnCustomClick(object sender, EventArgs e)
        {
            TabPage _tab = tbcVerbas.SelectedTab;
            if (_tab != tbpFerias)
            {
                DataGridView _grid = null;
                _grid = _tab.Controls.Cast<DataGridView>().Where(_c => _c is DataGridView).FirstOrDefault();
                if (_grid != null)
                {
                    SCI.Trabalhista.Resultado _resultado = wrTrabalhista.CalcularFolha(Guid, cptCompetencia.AnoMes, ((Model.Trabalhista.Funcionario)stbFuncionario.GetSelectedItem()).Codigo.ToString(), _grid.Tag.ToString());
                    if (_resultado.Sucesso)
                    {
                        AtualizarVerbas();
                        _grid.Focus();
                    }
                    else
                    {
                        MessageBox.Show(_resultado.Mensagem);
                    }
                }
            }
        }

        private void dgvPagamento_SelectionChanged(object sender, EventArgs e)
        {
            if (cptAtual.AnoMes == cptCompetencia.AnoMes)
            {
                DataGridView _sender = (DataGridView)sender;
                if (_sender.SelectedRows.Count > 0)
                {
                    if (_sender.SelectedRows.Cast<DataGridViewRow>()
                        .Where(_row => _row.Cells[1].Value.ToString() != VerbaFixa.Calculada.ToString()).Any())
                    {
                        Excluir = true;
                    }
                    else
                    {
                        Excluir = false;
                    }
                }
                else
                {
                    Excluir = false;
                }
            }
            else
            {
                Excluir = false;
            }
        }
    }
}
