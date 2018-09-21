namespace SCI.View.Sistema.Monitoramento
{
    partial class Painel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chtLicenca = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gpbLicenca = new System.Windows.Forms.GroupBox();
            this.crtAiuso = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gpbIRKO = new System.Windows.Forms.GroupBox();
            this.tbcPainel = new System.Windows.Forms.TabControl();
            this.tbpGeral = new System.Windows.Forms.TabPage();
            this.gpbTotalChamado = new System.Windows.Forms.GroupBox();
            this.crtChamados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gpbChamado = new System.Windows.Forms.GroupBox();
            this.dgvChamado = new System.Windows.Forms.DataGridView();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abertos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fechados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NaoProcede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbWork = new System.Windows.Forms.GroupBox();
            this.crtWork = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gpbLock = new System.Windows.Forms.GroupBox();
            this.crtLock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbpLock = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.chtLicenca)).BeginInit();
            this.gpbLicenca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtAiuso)).BeginInit();
            this.gpbIRKO.SuspendLayout();
            this.tbcPainel.SuspendLayout();
            this.tbpGeral.SuspendLayout();
            this.gpbTotalChamado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtChamados)).BeginInit();
            this.gpbChamado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamado)).BeginInit();
            this.gpbWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtWork)).BeginInit();
            this.gpbLock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtLock)).BeginInit();
            this.SuspendLayout();
            // 
            // chtLicenca
            // 
            chartArea6.Name = "ChartArea1";
            this.chtLicenca.ChartAreas.Add(chartArea6);
            this.chtLicenca.Location = new System.Drawing.Point(6, 15);
            this.chtLicenca.Name = "chtLicenca";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.IsVisibleInLegend = false;
            series6.Name = "Series1";
            this.chtLicenca.Series.Add(series6);
            this.chtLicenca.Size = new System.Drawing.Size(150, 150);
            this.chtLicenca.TabIndex = 1;
            this.chtLicenca.Text = "Licenças";
            this.chtLicenca.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chtLicenca_MouseMove);
            // 
            // gpbLicenca
            // 
            this.gpbLicenca.Controls.Add(this.chtLicenca);
            this.gpbLicenca.Location = new System.Drawing.Point(9, 6);
            this.gpbLicenca.Name = "gpbLicenca";
            this.gpbLicenca.Size = new System.Drawing.Size(163, 171);
            this.gpbLicenca.TabIndex = 2;
            this.gpbLicenca.TabStop = false;
            this.gpbLicenca.Text = "Licenças";
            // 
            // crtAiuso
            // 
            chartArea7.Name = "ChartArea1";
            this.crtAiuso.ChartAreas.Add(chartArea7);
            this.crtAiuso.Location = new System.Drawing.Point(7, 15);
            this.crtAiuso.Name = "crtAiuso";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            series7.IsVisibleInLegend = false;
            series7.Name = "Series";
            this.crtAiuso.Series.Add(series7);
            this.crtAiuso.Size = new System.Drawing.Size(150, 150);
            this.crtAiuso.TabIndex = 3;
            this.crtAiuso.Text = "chart1";
            this.crtAiuso.MouseMove += new System.Windows.Forms.MouseEventHandler(this.crtAiuso_MouseMove);
            // 
            // gpbIRKO
            // 
            this.gpbIRKO.Controls.Add(this.crtAiuso);
            this.gpbIRKO.Location = new System.Drawing.Point(178, 6);
            this.gpbIRKO.Name = "gpbIRKO";
            this.gpbIRKO.Size = new System.Drawing.Size(163, 171);
            this.gpbIRKO.TabIndex = 4;
            this.gpbIRKO.TabStop = false;
            this.gpbIRKO.Text = "Usuários IRKO";
            // 
            // tbcPainel
            // 
            this.tbcPainel.Controls.Add(this.tbpGeral);
            this.tbcPainel.Controls.Add(this.tbpLock);
            this.tbcPainel.Location = new System.Drawing.Point(5, 37);
            this.tbcPainel.Name = "tbcPainel";
            this.tbcPainel.SelectedIndex = 0;
            this.tbcPainel.Size = new System.Drawing.Size(955, 463);
            this.tbcPainel.TabIndex = 5;
            // 
            // tbpGeral
            // 
            this.tbpGeral.Controls.Add(this.gpbTotalChamado);
            this.tbpGeral.Controls.Add(this.gpbChamado);
            this.tbpGeral.Controls.Add(this.gpbWork);
            this.tbpGeral.Controls.Add(this.gpbLock);
            this.tbpGeral.Controls.Add(this.gpbLicenca);
            this.tbpGeral.Controls.Add(this.gpbIRKO);
            this.tbpGeral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeral.Name = "tbpGeral";
            this.tbpGeral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeral.Size = new System.Drawing.Size(947, 437);
            this.tbpGeral.TabIndex = 0;
            this.tbpGeral.Text = "Geral";
            this.tbpGeral.UseVisualStyleBackColor = true;
            // 
            // gpbTotalChamado
            // 
            this.gpbTotalChamado.Controls.Add(this.crtChamados);
            this.gpbTotalChamado.Location = new System.Drawing.Point(685, 183);
            this.gpbTotalChamado.Name = "gpbTotalChamado";
            this.gpbTotalChamado.Size = new System.Drawing.Size(256, 236);
            this.gpbTotalChamado.TabIndex = 9;
            this.gpbTotalChamado.TabStop = false;
            this.gpbTotalChamado.Text = "Total de Chamados";
            // 
            // crtChamados
            // 
            chartArea8.Name = "ChartArea1";
            this.crtChamados.ChartAreas.Add(chartArea8);
            this.crtChamados.Location = new System.Drawing.Point(7, 15);
            this.crtChamados.Name = "crtChamados";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            series8.IsVisibleInLegend = false;
            series8.Name = "Series";
            this.crtChamados.Series.Add(series8);
            this.crtChamados.Size = new System.Drawing.Size(243, 215);
            this.crtChamados.TabIndex = 3;
            this.crtChamados.Text = "chart1";
            // 
            // gpbChamado
            // 
            this.gpbChamado.Controls.Add(this.dgvChamado);
            this.gpbChamado.Location = new System.Drawing.Point(9, 183);
            this.gpbChamado.Name = "gpbChamado";
            this.gpbChamado.Size = new System.Drawing.Size(670, 236);
            this.gpbChamado.TabIndex = 8;
            this.gpbChamado.TabStop = false;
            this.gpbChamado.Text = "Chamados";
            // 
            // dgvChamado
            // 
            this.dgvChamado.AllowUserToAddRows = false;
            this.dgvChamado.AllowUserToDeleteRows = false;
            this.dgvChamado.AllowUserToOrderColumns = true;
            this.dgvChamado.AllowUserToResizeRows = false;
            this.dgvChamado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChamado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nome,
            this.Total,
            this.Abertos,
            this.Fechados,
            this.NaoProcede});
            this.dgvChamado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChamado.Location = new System.Drawing.Point(3, 16);
            this.dgvChamado.Name = "dgvChamado";
            this.dgvChamado.ReadOnly = true;
            this.dgvChamado.RowHeadersVisible = false;
            this.dgvChamado.Size = new System.Drawing.Size(664, 217);
            this.dgvChamado.TabIndex = 7;
            // 
            // Nome
            // 
            this.Nome.FillWeight = 152.2843F;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.FillWeight = 86.92893F;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Abertos
            // 
            this.Abertos.FillWeight = 86.92893F;
            this.Abertos.HeaderText = "Abertos";
            this.Abertos.Name = "Abertos";
            this.Abertos.ReadOnly = true;
            // 
            // Fechados
            // 
            this.Fechados.FillWeight = 86.92893F;
            this.Fechados.HeaderText = "Fechados";
            this.Fechados.Name = "Fechados";
            this.Fechados.ReadOnly = true;
            // 
            // NaoProcede
            // 
            this.NaoProcede.FillWeight = 86.92893F;
            this.NaoProcede.HeaderText = "Não Procede";
            this.NaoProcede.Name = "NaoProcede";
            this.NaoProcede.ReadOnly = true;
            // 
            // gpbWork
            // 
            this.gpbWork.Controls.Add(this.crtWork);
            this.gpbWork.Location = new System.Drawing.Point(516, 6);
            this.gpbWork.Name = "gpbWork";
            this.gpbWork.Size = new System.Drawing.Size(163, 171);
            this.gpbWork.TabIndex = 6;
            this.gpbWork.TabStop = false;
            this.gpbWork.Text = "/Work";
            // 
            // crtWork
            // 
            chartArea9.Name = "ChartArea1";
            this.crtWork.ChartAreas.Add(chartArea9);
            this.crtWork.Location = new System.Drawing.Point(7, 15);
            this.crtWork.Name = "crtWork";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            series9.IsVisibleInLegend = false;
            series9.Name = "Series";
            this.crtWork.Series.Add(series9);
            this.crtWork.Size = new System.Drawing.Size(150, 150);
            this.crtWork.TabIndex = 3;
            this.crtWork.Text = "chart1";
            this.crtWork.MouseMove += new System.Windows.Forms.MouseEventHandler(this.crtWork_MouseMove);
            // 
            // gpbLock
            // 
            this.gpbLock.Controls.Add(this.crtLock);
            this.gpbLock.Location = new System.Drawing.Point(347, 6);
            this.gpbLock.Name = "gpbLock";
            this.gpbLock.Size = new System.Drawing.Size(163, 171);
            this.gpbLock.TabIndex = 5;
            this.gpbLock.TabStop = false;
            this.gpbLock.Text = "Locks";
            // 
            // crtLock
            // 
            chartArea10.Name = "ChartArea1";
            this.crtLock.ChartAreas.Add(chartArea10);
            this.crtLock.Location = new System.Drawing.Point(7, 15);
            this.crtLock.Name = "crtLock";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            series10.IsVisibleInLegend = false;
            series10.Name = "Series";
            this.crtLock.Series.Add(series10);
            this.crtLock.Size = new System.Drawing.Size(150, 150);
            this.crtLock.TabIndex = 3;
            this.crtLock.Text = "chart1";
            this.crtLock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.crtLock_MouseMove);
            // 
            // tbpLock
            // 
            this.tbpLock.Location = new System.Drawing.Point(4, 22);
            this.tbpLock.Name = "tbpLock";
            this.tbpLock.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLock.Size = new System.Drawing.Size(947, 437);
            this.tbpLock.TabIndex = 1;
            this.tbpLock.Text = "Locks";
            this.tbpLock.UseVisualStyleBackColor = true;
            // 
            // Painel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.tbcPainel);
            this.Excluir = true;
            this.Name = "Painel";
            this.Salvar = true;
            this.ShowCustom = false;
            this.Size = new System.Drawing.Size(963, 563);
            this.AfterLoad += new System.EventHandler(this.Painel_AfterLoad);
            this.Resize += new System.EventHandler(this.Painel_Resize);
            this.Controls.SetChildIndex(this.tbcPainel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chtLicenca)).EndInit();
            this.gpbLicenca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crtAiuso)).EndInit();
            this.gpbIRKO.ResumeLayout(false);
            this.tbcPainel.ResumeLayout(false);
            this.tbpGeral.ResumeLayout(false);
            this.gpbTotalChamado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crtChamados)).EndInit();
            this.gpbChamado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamado)).EndInit();
            this.gpbWork.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crtWork)).EndInit();
            this.gpbLock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crtLock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtLicenca;
        private System.Windows.Forms.GroupBox gpbLicenca;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtAiuso;
        private System.Windows.Forms.GroupBox gpbIRKO;
        private System.Windows.Forms.TabControl tbcPainel;
        private System.Windows.Forms.TabPage tbpGeral;
        private System.Windows.Forms.GroupBox gpbLock;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtLock;
        private System.Windows.Forms.TabPage tbpLock;
        private System.Windows.Forms.GroupBox gpbWork;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtWork;
        private System.Windows.Forms.DataGridView dgvChamado;
        private System.Windows.Forms.GroupBox gpbChamado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abertos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fechados;
        private System.Windows.Forms.DataGridViewTextBoxColumn NaoProcede;
        private System.Windows.Forms.GroupBox gpbTotalChamado;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtChamados;
    }
}
