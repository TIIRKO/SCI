using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SCI.View.Controles;
using System.Windows.Forms.DataVisualization.Charting;

namespace SCI.View.Sistema.Acessos
{
    public partial class AIUSO : BaseForm
    {
        private IRKDesktop.GetData getData = new IRKDesktop.GetData();

        public AIUSO()
        {
            InitializeComponent();
        }

        public AIUSO(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void AIUSO_AfterLoad(object sender, EventArgs e)
        {
            Series _serie = crtAiuso.Series.First();
            _serie.Points.Clear();
            var _aiusos = getData.UsoSistema().OrderBy(_dt => _dt.Value);
            double _total = (double)_aiusos.Select(_a => _a.Value).Sum();
            double _md = 0;

            _aiusos.ToList().ForEach(_a =>
            {
                _md = (int)Math.Round(((double)_a.Value / _total) * 100, MidpointRounding.AwayFromZero);
                _serie.Points.AddXY(_a.UsoSistemaResultKey, _md);
            });
        }

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        void crtAiuso_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = crtAiuso.HitTest(pos.X, pos.Y, false,
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
                        tooltip.Show(prop.YValues[0].ToString() + "%", this.crtAiuso,
                                        pos.X, pos.Y - 15);
                    }
                }
            }
        }
    }
}
