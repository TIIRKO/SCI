namespace SCI.View.Sistema.Acessos
{
    partial class Licenca
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.crtLicenca = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblPeriodo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.crtLicenca)).BeginInit();
            this.SuspendLayout();
            // 
            // crtLicenca
            // 
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.CursorX.IntervalOffset = 1D;
            chartArea2.CursorX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea2.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.crtLicenca.ChartAreas.Add(chartArea2);
            this.crtLicenca.Location = new System.Drawing.Point(5, 60);
            this.crtLicenca.Name = "crtLicenca";
            this.crtLicenca.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.ChartArea = "ChartArea1";
            series2.IsValueShownAsLabel = true;
            series2.Name = "Series";
            this.crtLicenca.Series.Add(series2);
            this.crtLicenca.Size = new System.Drawing.Size(675, 403);
            this.crtLicenca.TabIndex = 1;
            this.crtLicenca.MouseMove += new System.Windows.Forms.MouseEventHandler(this.crtLicenca_MouseMove);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Location = new System.Drawing.Point(3, 34);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(520, 23);
            this.lblPeriodo.TabIndex = 3;
            // 
            // Licenca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.crtLicenca);
            this.Excluir = true;
            this.Name = "Licenca";
            this.Salvar = true;
            this.ShowCustom = false;
            this.Size = new System.Drawing.Size(685, 509);
            this.AfterLoad += new System.EventHandler(this.Licenca_AfterLoad);
            this.Controls.SetChildIndex(this.crtLicenca, 0);
            this.Controls.SetChildIndex(this.lblPeriodo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.crtLicenca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtLicenca;
        private System.Windows.Forms.Label lblPeriodo;
    }
}
