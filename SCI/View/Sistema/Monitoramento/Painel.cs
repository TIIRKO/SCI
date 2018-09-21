using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SCI.View.Controles;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace SCI.View.Sistema.Monitoramento
{
    public partial class Painel : BaseForm
    {
        SCI.Sistema.IRKO.Service wrSistema = new SCI.Sistema.IRKO.Service();

        public Painel()
        {
            InitializeComponent();
        }
        public Painel(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void RealinharCampos()
        {
            tbcPainel.Width = Width - (tbcPainel.Left * 2);
            tbcPainel.Height = Height - tbcPainel.Top - 3;
            int _gpbWidth = 0;
            if (tbpGeral.Width > (tbpGeral.Height * 1.8))
            {
                _gpbWidth = ((int)Math.Round((tbpGeral.Height * 1.8), MidpointRounding.AwayFromZero) - 18) / 4;
            }
            else
            {
                _gpbWidth = (tbpGeral.Width - 18) / 4;
            }

            gpbLicenca.Width = _gpbWidth;
            gpbLicenca.Height = _gpbWidth + 8;

            gpbIRKO.Width = _gpbWidth;
            gpbIRKO.Height = _gpbWidth + 8;

            gpbLock.Width = _gpbWidth;
            gpbLock.Height = _gpbWidth + 8;

            gpbWork.Width = _gpbWidth;
            gpbWork.Height = _gpbWidth + 8;

            gpbTotalChamado.Width = _gpbWidth;
            gpbTotalChamado.Height = _gpbWidth + 8;

            gpbLicenca.Left = 3;
            gpbIRKO.Left = gpbLicenca.Left + gpbLicenca.Width + 3;
            gpbLock.Left = gpbIRKO.Left + gpbIRKO.Width + 3;
            gpbWork.Left = gpbLock.Left + gpbLock.Width + 3;
            gpbTotalChamado.Top = gpbLicenca.Top + gpbLicenca.Height + 5;
            gpbTotalChamado.Left = gpbWork.Left;

            gpbChamado.Top = gpbLicenca.Top + gpbLicenca.Height + 5;
            gpbChamado.Left = 3;
            gpbChamado.Width = gpbWork.Left - gpbChamado.Left - 3;
            gpbChamado.Height = _gpbWidth + 8;
            

            chtLicenca.Width = gpbLicenca.Width - 13;
            chtLicenca.Height = gpbLicenca.Height - 21;

            crtAiuso.Width = gpbIRKO.Width - 13;
            crtAiuso.Height = gpbIRKO.Height - 21;

            crtLock.Width = gpbLock.Width - 13;
            crtLock.Height = gpbLock.Height - 21;

            crtWork.Width = gpbWork.Width - 13;
            crtWork.Height = gpbWork.Height - 21;

            crtChamados.Width = gpbTotalChamado.Width - 13;
            crtChamados.Height = gpbTotalChamado.Height - 21;
        }

        private void Atualizar()
        {
            SCI.Sistema.IRKO.ResultadoPainel _resultado = wrSistema.Painel(Guid);
            if (_resultado.Sucesso)
            {
                SCI.Sistema.IRKO.Painel _painel = _resultado.RetornoPainel;

                double _md = 0;

                Series _serieLicenca = chtLicenca.Series.First();
                _serieLicenca.Points.Clear();

                _md = (int)Math.Round(((double)_painel.UsoAtualLicenca / _painel.TotalLincenca) * 100, MidpointRounding.AwayFromZero);
                _serieLicenca.Points.AddXY("Em Uso("+_md.ToString()+"%)", _md);

                long _livre = _painel.TotalLincenca - _painel.UsoAtualLicenca;
                _md = (int)Math.Round(((double)_livre / _painel.TotalLincenca) * 100, MidpointRounding.AwayFromZero);
                _serieLicenca.Points.AddXY("Livre(" + _md.ToString() + "%)", _md);

                Series _serieAIUSO = crtAiuso.Series.First();
                _serieAIUSO.Points.Clear();

                _painel.RotinaSistemaIrko.OrderByDescending(_irko => _irko.Value).Take(10).ToList().ForEach(_irk =>
                {
                    _md = (int)Math.Round(((double)_irk.Value / _painel.TotalLogadoIrko) * 100, MidpointRounding.AwayFromZero);
                    _serieAIUSO.Points.AddXY(_irk.RotinaSistemaIrkoKey, _md);
                });

                long _outros = _painel.RotinaSistemaIrko.OrderByDescending(_irko => _irko.Value).Skip(10)
                    .Select(_irk => _irk.Value).Sum();
                _md = (int)Math.Round(((double)_outros / _painel.TotalLogadoIrko) * 100, MidpointRounding.AwayFromZero);
                _serieAIUSO.Points.AddXY("Outros", _md);

                Series _serieLock = crtLock.Series.First();
                _serieLock.Points.Clear();

                _md = (int)Math.Round(((double)_painel.UsoLock / _painel.TamanhoLock) * 100, MidpointRounding.AwayFromZero);
                _serieLock.Points.AddXY("Em Uso(" + _md.ToString() + "%)", _md);

                _md = (int)Math.Round(((double)_painel.LockLivre / _painel.TamanhoLock) * 100, MidpointRounding.AwayFromZero);
                _serieLock.Points.AddXY("Livre(" + _md.ToString() + "%)", _md);

                _md = (int)Math.Round(((double)_painel.LockSistema / _painel.TamanhoLock) * 100, MidpointRounding.AwayFromZero);
                _serieLock.Points.AddXY("Sistema(" + _md.ToString() + "%)", _md);

                Series _serieWork = crtWork.Series.First();
                _serieWork.Points.Clear();

                _serieWork.Points.AddXY("Em Uso(" + _painel.WorkUsado.ToString() + "%)", _painel.WorkUsado);
                _serieWork.Points.AddXY("Livre(" + (100 - _painel.WorkUsado) + "%)", (100 - _painel.WorkUsado));

                AtualizarChamados(_painel);
            }
            else
            {
                MessageBox.Show(_resultado.Mensagem);
            }
        }

        private void AtualizarChamados(SCI.Sistema.IRKO.Painel _painel)
        {
            dgvChamado.Rows.Clear();
            string _anomes = _painel.Chamados.FirstOrDefault().ANOMES;
            int _ano = int.Parse(_anomes.Substring(0, 4));
            int _mes = int.Parse(_anomes.Substring(4,2));
            string[] _meses = new string[] {"","Janeiro","Fevereiro","Março","Abril","Maio","Junho","Julho","Agosto","Setembro","Outubro","Novembro","Dezembro" };

            gpbChamado.Text = "Chamados até " + _meses[_mes] +" de " + _ano.ToString();

            double _totalChamado = double.Parse(_painel.Chamados.Where(_chamado => _chamado.Nome == "Total").FirstOrDefault().TotalChamado);

            _painel.Chamados.ToList().ForEach(_chamado =>
            {
                if (_chamado.Nome == "Total")
                {
                    gpbTotalChamado.Text = "Total de Chamados: " + _chamado.TotalChamado;
                    Series _serieChamado = crtChamados.Series.First();
                    _serieChamado.Points.Clear();

                    int _md;

                    _md = (int)Math.Round((double.Parse(_chamado.Fechado) / double.Parse(_chamado.TotalChamado)) * 100, MidpointRounding.AwayFromZero);
                    _serieChamado.Points.AddXY("Fechados(" + _md.ToString() + "%)", _md);

                    _md = (int)Math.Round((double.Parse(_chamado.Pendente) / double.Parse(_chamado.TotalChamado)) * 100, MidpointRounding.AwayFromZero);
                    _serieChamado.Points.AddXY("Abertos(" + _md.ToString() + "%)", _md);

                    _md = (int)Math.Round((double.Parse(_chamado.NaoProcede) / double.Parse(_chamado.TotalChamado)) * 100, MidpointRounding.AwayFromZero);
                    _serieChamado.Points.AddXY("Não Procede(" + _md.ToString() + "%)", _md);
                }
                else
                {
                    int _mdTotal = (int)Math.Round(((double.Parse(_chamado.TotalChamado) / _totalChamado)) * 100, MidpointRounding.AwayFromZero);
                    
                    int _mdPendente = (int)Math.Round(((double.Parse(_chamado.Pendente) / double.Parse(_chamado.TotalChamado))) * 100, MidpointRounding.AwayFromZero);
                    int _mdFechado = (int)Math.Round(((double.Parse(_chamado.Fechado) / double.Parse(_chamado.TotalChamado))) * 100, MidpointRounding.AwayFromZero);
                    int _mdNapProcede = (int)Math.Round(((double.Parse(_chamado.NaoProcede) / double.Parse(_chamado.TotalChamado))) * 100, MidpointRounding.AwayFromZero);

                    string[] _linha = new string[] { _chamado.Nome, _chamado.TotalChamado+"("+ _mdTotal + "%)", _chamado.Pendente + "(" + _mdPendente + "%)", _chamado.Fechado + "(" + _mdFechado + "%)", _chamado.NaoProcede + "(" + _mdNapProcede + "%)" };
                    dgvChamado.Rows.Add(_linha);
                }
            });

        }


        private void AtualizarLock()
        {

        }

        private void Painel_AfterLoad(object sender, EventArgs e)
        {
            RealinharCampos();
            Atualizar();

            System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 20000; //20 segundos
            _timer.Tick += new System.EventHandler(_timer_Tick);
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Atualizar();
            }
#pragma warning disable CS0168 // A variável foi declarada, mas nunca foi usada
            catch (Exception ex)
#pragma warning restore CS0168 // A variável foi declarada, mas nunca foi usada
            { }
        }

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        void MouseOver(object sender, MouseEventArgs e)
        {
            var _sender = (Chart)sender;
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = _sender.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);
                        tooltip.Show(prop.YValues[0].ToString() + "%", _sender,
                                        pos.X, pos.Y - 15);
                    }
                }
            }
        }

        private void chtLicenca_MouseMove(object sender, MouseEventArgs e)
        {
            MouseOver(sender, e);
        }

        private void crtAiuso_MouseMove(object sender, MouseEventArgs e)
        {
            MouseOver(sender, e);
        }

        private void crtLock_MouseMove(object sender, MouseEventArgs e)
        {
            MouseOver(sender, e);
        }

        private void Painel_Resize(object sender, EventArgs e)
        {
            RealinharCampos();
        }

        private void crtWork_MouseMove(object sender, MouseEventArgs e)
        {
            MouseOver(sender, e);
        }
    }
}
