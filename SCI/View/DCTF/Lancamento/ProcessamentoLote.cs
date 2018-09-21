using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SCI.View.Controles;
using System.IO;
using SCI.Lib;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace SCI.View.DCTF.Lancamento
{
    public partial class ProcessamentoLote : BaseForm
    {
        private SCI.DCTF.DCTFService wrDCTF = new SCI.DCTF.DCTFService();

        public ProcessamentoLote()
        {
            InitializeComponent();
        }

        public ProcessamentoLote(Desktop _desktop)
        {
            Desktop = _desktop;
            InitializeComponent();
        }

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            if (ofdArquivo.ShowDialog() == DialogResult.OK)
            {
                lblArquivo.Text = ofdArquivo.FileName.ToString();
            }
        }

        private void CriarCabecalhoDataView(List<string> _colunas)
        {
            DataGridViewColumn[] _cols = _colunas.ConvertAll<DataGridViewColumn>(_col => CriarCabecalhoColuna(_col)).ToArray();
            dgvArquivo.Columns.AddRange(_cols);
        }
        private DataGridViewColumn CriarCabecalhoColuna(string _texto)
        {
            DataGridViewTextBoxColumn _col = new DataGridViewTextBoxColumn();
            _col.HeaderText = _texto;
            _col.SortMode = DataGridViewColumnSortMode.NotSortable;
            return _col;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            dgvArquivo.Rows.Clear();
            dgvArquivo.Columns.Clear();
            char _divisor = '\t';
            if (cbbDivisor.SelectedItem.ToString() == "TAB")
            {
                _divisor = '\t';
            }
            else
            {
                _divisor = Convert.ToChar(cbbDivisor.SelectedItem);
            }

            if (Path.GetExtension(ofdArquivo.FileName.ToString()).Normalizar() == Library.Normalizar(".txt"))
            {
                Stream _arquivo = ofdArquivo.OpenFile();
                StreamReader _reader = new StreamReader(_arquivo);
                string _linha = String.Empty;
                for (int _i = 0; _i < nmcPularLinha.Value; _i++)
                    _reader.ReadLine();
                if (chkCabecalho.Checked)
                {
                    _linha = _reader.ReadLine();
                    CriarCabecalhoDataView(_linha.Split(_divisor).ToList());
                }

                while (!_reader.EndOfStream)
                {
                    _linha = _reader.ReadLine();
                    if (!dgvArquivo.Columns.Cast<DataGridViewColumn>().Any())
                        CriarCabecalhoDataView(Enumerable.Repeat(String.Empty, _linha.Split(_divisor).Count()).ToList());

                    dgvArquivo.Rows.Add(_linha.Split(_divisor));
                }
                Salvar = true;
            }
            else if (Path.GetExtension(ofdArquivo.FileName.ToString()).Normalizar() == Library.Normalizar(".xls")
                  || Path.GetExtension(ofdArquivo.FileName.ToString()).Normalizar() == Library.Normalizar(".xlsx"))
            {
                Excel.Application _excel = new Excel.Application();
                Excel.Workbook _workbook = _excel.Workbooks.Open(ofdArquivo.FileName.ToString(), 0, true, 5, "", "",
                    true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                foreach (Excel.Worksheet _worksheet in _workbook.Worksheets)
                {
                    Excel.Range _range;
                    _range = _worksheet.get_Range("A" + (nmcPularLinha.Value + 2).ToString(), Missing.Value);
                    _range = _range.get_End(Excel.XlDirection.xlToRight);
                    _range = _range.get_End(Excel.XlDirection.xlDown);

                    string downAddress = _range.get_Address(
                        false, false, Excel.XlReferenceStyle.xlA1,
                        Type.Missing, Type.Missing);

                    _range = _worksheet.get_Range("A" + (nmcPularLinha.Value + 1).ToString(), downAddress);
                    object[,] _values = new object[_range.Rows.Count+1,_range.Columns.Count+1];
                    for (int _i = 1;_i <= _range.Rows.Count; _i++)
                    {
                        for (int _j =1; _j <= _range.Columns.Count; _j++)
                        {
                            _values[_i, _j] = ((Excel.Range)_range.Cells[_i,_j]).Text;
                        }
                    }
                    
                    for (int _i = 1; _i < _values.GetLength(0); _i++)
                    {
                        List<string> _cells = new List<string>();
                        for (int _j = 1; _j < _values.GetLength(1); _j++)
                        {
                            _cells.Add(_values[_i, _j]?.ToString());
                        }
                        if (!dgvArquivo.Columns.Cast<DataGridViewColumn>().Any())
                        {
                            if (chkCabecalho.Checked)
                            {
                                CriarCabecalhoDataView(_cells);
                            }
                            else
                            {
                                CriarCabecalhoDataView(Enumerable.Repeat(String.Empty, _cells.Count()).ToList());
                                dgvArquivo.Rows.Add(_cells.ToArray());
                            }
                        }
                        else
                        {
                            dgvArquivo.Rows.Add(_cells.ToArray());
                        }
                    }
                }
                Salvar = true;
            }
        }

        private void ProcessamentoLote_AfterLoad(object sender, EventArgs e)
        {
            cbbDivisor.SelectedIndex = 1;
            Salvar = false;
        }

        private void dgvArquivo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvArquivo.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            dgvArquivo.Columns[e.ColumnIndex].Selected = true;
        }

        private void dgvArquivo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvArquivo.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dgvArquivo.Rows[e.RowIndex].Selected = true;
            dgvArquivo.CurrentCell = dgvArquivo.Rows[e.RowIndex].Cells[0];
        }

        private void dgvArquivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvArquivo.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
                {
                    dgvArquivo.Columns.Cast<DataGridViewColumn>().Where(_col => _col.Selected)
                        .ToList().ForEach(_col =>
                        {
                            dgvArquivo.Columns.Remove(_col);
                        });
                }
            }
        }

        private void ProcessamentoLote_SalvarClick(object sender, EventArgs e)
        {
            Salvar = false;
            List<string> _lista = new List<string>();
            foreach (DataGridViewRow _row in dgvArquivo.Rows)
            {
                _lista.Add(String.Join("^", _row.Cells.Cast<DataGridViewCell>().Select(_cel => _cel.Value)));
            }

            SCI.DCTF.ResultadoImportarArquivoLancamento _resultado = wrDCTF.ImportarArquivoLancamentoLote(Guid, _lista.ToArray(), cptCompetencia.AnoMes);

            if (_resultado.Sucesso)
            {
                dgvArquivo.Rows.Clear();
                dgvArquivo.Columns.Clear();
                _resultado.RetornoImportarArquivoLancamento.ToList().ForEach(_lin =>
                {
                    if (!dgvArquivo.Columns.Cast<DataGridViewColumn>().Any())
                    {
                        CriarCabecalhoDataView(_lin.Split('^').ToList());
                    }
                    else
                    {
                        dgvArquivo.Rows.Add(_lin.Split('^'));
                    }
                });
            }
            else
            {
                MessageBox.Show(_resultado.Mensagem);
            }
        }
    }
}
