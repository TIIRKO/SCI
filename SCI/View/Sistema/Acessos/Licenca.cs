using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SCI.View.Controles;
using System.Windows.Forms.DataVisualization.Charting;

namespace SCI.View.Sistema.Acessos
{
    public partial class Licenca : BaseForm
    {
        private IRKDesktop.GetData getData = new IRKDesktop.GetData();

        public Licenca()
        {
            InitializeComponent();
        }

        public Licenca(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void Licenca_AfterLoad(object sender, EventArgs e)
        {
            Series _serie = crtLicenca.Series.First();
            _serie.Points.Clear();
            IRKDesktop.PairOfUsoLicencaResultKeyString[] _medias = getData.UsoLicenca();

            string _de = _medias.Where(_md => _md.UsoLicencaResultKey == "DE").Select(_md => _md.Value).FirstOrDefault();
            string _ate = _medias.Where(_md => _md.UsoLicencaResultKey == "ATE").Select(_md => _md.Value).FirstOrDefault();

            lblPeriodo.Text = "Média de uso de Licenças entre " + _de + " e " + _ate;

            _medias.Where(_md => _md.UsoLicencaResultKey != "DE" && _md.UsoLicencaResultKey != "ATE").OrderBy(_md => int.Parse(_md.UsoLicencaResultKey))
                .ToList().ForEach(_md =>
                {
                    _serie.Points.AddXY(_md.UsoLicencaResultKey.ToString() + ":00", _md.Value);
                });

            foreach (DataPoint _ponto in _serie.Points)
            {
                if (_ponto.YValues.First() < 51.00)
                {
                    _ponto.Color = Color.Green;
                }
                else if (_ponto.YValues.First() < 81.00)
                {
                    _ponto.Color = Color.Yellow;
                }
                else
                {
                    _ponto.Color = Color.Red;
                }
            }


            /*Series _serie = crtLicenca.Series.First();
            _serie.Points.Clear();
            IRKDesktop.Licenca[] _licencas = getData.UsoLicenca()
                .Where(_lic => (_lic.DataHoraLog.DayOfWeek != DayOfWeek.Saturday) && (_lic.DataHoraLog.DayOfWeek != DayOfWeek.Sunday))
                .ToArray();

            string _de = _licencas.OrderBy(_l => _l.DataHoraLog).FirstOrDefault().DataHoraLog.ToShortDateString();
            string _ate = _licencas.OrderBy(_l => _l.DataHoraLog).LastOrDefault().DataHoraLog.ToShortDateString();

            lblPeriodo.Text = "Média de uso de Licenças entre " + _de + " e " + _ate;

            for (int i = 7; i <= 22; i++)
            {
                int _md = 0;
                int _qtd = _licencas.Where(_lic => _lic.DataHoraLog.Hour == i).Count();
                if (_qtd > 0)
                {
                    double _tot = _licencas
                        .Where(_lic => _lic.DataHoraLog.Hour == i)
                        .Where(_lic => _lic.QuantidadeLicenca > 0)
                        .Select(_lic => ((double)_lic.UsoLicenca/(double)_lic.QuantidadeLicenca) * 100).Sum();
                    _md = (int)Math.Round((_tot / _qtd), MidpointRounding.AwayFromZero);

                }
                _serie.Points.AddXY(i.ToString() + ":00", _md);
            }
            foreach (DataPoint _ponto in _serie.Points)
            {
                if (_ponto.YValues.First() < 51.00)
                {
                    _ponto.Color = Color.Green;
                }
                else if (_ponto.YValues.First() < 81.00)
                {
                    _ponto.Color = Color.Yellow;
                }
                else
                {
                    _ponto.Color = Color.Red;
                }
            }*/
        }
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

void crtLicenca_MouseMove(object sender, MouseEventArgs e)
{
    var pos = e.Location;
    if (prevPosition.HasValue && pos == prevPosition.Value)
        return;
    tooltip.RemoveAll();
    prevPosition = pos;
    var results = crtLicenca.HitTest(pos.X, pos.Y, false,
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
                tooltip.Show(prop.YValues[0].ToString()+"%", this.crtLicenca,
                                pos.X, pos.Y - 15);
            }
        }
    }
}




    }
}
