using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCI.View.Controles;
using Microsoft.Reporting.WinForms;

namespace SCI.View.Trabalhista.Folha
{
    public partial class FolhaPorCentroCusto : BaseForm
    {

        private SCI.Trabalhista.AcessoTrabalhista wrTrabalhista = new SCI.Trabalhista.AcessoTrabalhista();

        public FolhaPorCentroCusto()
        {
            InitializeComponent();
        }
        public FolhaPorCentroCusto(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void BtnGerar_Click(object sender, EventArgs e)
        {
            string _tiporegistro = null;
            if (rdbMensal.Checked)
                _tiporegistro = "300";
            else if (rdbAdiantamento.Checked)
                _tiporegistro = "550";
            else if (rdbDecimoTerceiro.Checked)
                _tiporegistro = "450";

            SCI.Trabalhista.ResultadoListarVerbaCadastrada resultado = wrTrabalhista.FolhaCentroCusto(Guid, cptCompetencia.AnoMes, _tiporegistro,null,null);
            if (resultado.Sucesso)
            {
                rpvAnalitico.LocalReport.DataSources.Clear();
                if (resultado.RetornoListarVerbaCadastrada != null)
                {
                    ReportDataSource _source = new ReportDataSource("Registro", resultado.RetornoListarVerbaCadastrada.Cast<SCI.Trabalhista.Registro>().ToList()
                        .ConvertAll<Model.Trabalhista.Registro>(_registro => new Model.Trabalhista.Registro(_registro)));
                    rpvAnalitico.LocalReport.DataSources.Add(_source);
                }
                rpvAnalitico.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Agora", DateTime.Now.ToString()) });
                rpvAnalitico.RefreshReport();
            }
        }
    }
}
