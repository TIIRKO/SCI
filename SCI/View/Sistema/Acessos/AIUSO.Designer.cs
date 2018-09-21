namespace SCI.View.Sistema.Acessos
{
    partial class AIUSO
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
            this.crtAiuso = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.crtAiuso)).BeginInit();
            this.SuspendLayout();
            // 
            // crtAiuso
            // 
            chartArea2.Name = "ChartArea1";
            this.crtAiuso.ChartAreas.Add(chartArea2);
            this.crtAiuso.Location = new System.Drawing.Point(5, 52);
            this.crtAiuso.Name = "crtAiuso";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            series2.Name = "Series";
            this.crtAiuso.Series.Add(series2);
            this.crtAiuso.Size = new System.Drawing.Size(675, 368);
            this.crtAiuso.TabIndex = 1;
            this.crtAiuso.Text = "chart1";
            this.crtAiuso.MouseMove += new System.Windows.Forms.MouseEventHandler(this.crtAiuso_MouseMove);
            // 
            // AIUSO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.crtAiuso);
            this.Excluir = true;
            this.Name = "AIUSO";
            this.Salvar = true;
            this.ShowCustom = false;
            this.AfterLoad += new System.EventHandler(this.AIUSO_AfterLoad);
            this.Controls.SetChildIndex(this.crtAiuso, 0);
            ((System.ComponentModel.ISupportInitialize)(this.crtAiuso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtAiuso;
    }
}
