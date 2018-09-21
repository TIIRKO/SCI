namespace SCI.View.DCTF.REINF
{
    partial class EnvioDeArquivos
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
            this.components = new System.ComponentModel.Container();
            this.gpbArquivos = new System.Windows.Forms.GroupBox();
            this.pnlArquivo = new System.Windows.Forms.Panel();
            this.btnSel = new System.Windows.Forms.Button();
            this.btnDes = new System.Windows.Forms.Button();
            this.imgEnviar = new System.Windows.Forms.PictureBox();
            this.gpbEnviados = new System.Windows.Forms.GroupBox();
            this.rptREINF = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RetornoREINFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imgVoltar = new System.Windows.Forms.PictureBox();
            this.pctLoad = new System.Windows.Forms.PictureBox();
            this.lblLoad = new System.Windows.Forms.Label();
            this.gpbArquivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEnviar)).BeginInit();
            this.gpbEnviados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RetornoREINFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVoltar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbArquivos
            // 
            this.gpbArquivos.Controls.Add(this.pnlArquivo);
            this.gpbArquivos.Location = new System.Drawing.Point(5, 37);
            this.gpbArquivos.Name = "gpbArquivos";
            this.gpbArquivos.Size = new System.Drawing.Size(675, 392);
            this.gpbArquivos.TabIndex = 10;
            this.gpbArquivos.TabStop = false;
            this.gpbArquivos.Text = "Arquivos do REINF";
            // 
            // pnlArquivo
            // 
            this.pnlArquivo.AutoScroll = true;
            this.pnlArquivo.Location = new System.Drawing.Point(6, 19);
            this.pnlArquivo.Name = "pnlArquivo";
            this.pnlArquivo.Size = new System.Drawing.Size(663, 367);
            this.pnlArquivo.TabIndex = 0;
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(7, 450);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(120, 23);
            this.btnSel.TabIndex = 12;
            this.btnSel.Text = "Selecionar Tudo";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // btnDes
            // 
            this.btnDes.Location = new System.Drawing.Point(133, 450);
            this.btnDes.Name = "btnDes";
            this.btnDes.Size = new System.Drawing.Size(120, 23);
            this.btnDes.TabIndex = 11;
            this.btnDes.Text = "Limpar Tudo";
            this.btnDes.UseVisualStyleBackColor = true;
            this.btnDes.Click += new System.EventHandler(this.btnDes_Click);
            // 
            // imgEnviar
            // 
            this.imgEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgEnviar.Image = global::SCI.Properties.Resources.seta;
            this.imgEnviar.Location = new System.Drawing.Point(641, 435);
            this.imgEnviar.Name = "imgEnviar";
            this.imgEnviar.Size = new System.Drawing.Size(39, 44);
            this.imgEnviar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgEnviar.TabIndex = 13;
            this.imgEnviar.TabStop = false;
            this.imgEnviar.Click += new System.EventHandler(this.imgEnviar_Click);
            this.imgEnviar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgEnviar_MouseDown);
            // 
            // gpbEnviados
            // 
            this.gpbEnviados.Controls.Add(this.rptREINF);
            this.gpbEnviados.Location = new System.Drawing.Point(7, 37);
            this.gpbEnviados.Name = "gpbEnviados";
            this.gpbEnviados.Size = new System.Drawing.Size(866, 392);
            this.gpbEnviados.TabIndex = 14;
            this.gpbEnviados.TabStop = false;
            this.gpbEnviados.Text = "Arquivos Enviados";
            this.gpbEnviados.Visible = false;
            // 
            // rptREINF
            // 
            this.rptREINF.AutoSize = true;
            this.rptREINF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptREINF.LocalReport.ReportEmbeddedResource = "SCI.View.Report.DCTF.REINF.RetornoREINF.rdlc";
            this.rptREINF.Location = new System.Drawing.Point(3, 16);
            this.rptREINF.Name = "rptREINF";
            this.rptREINF.ServerReport.BearerToken = null;
            this.rptREINF.Size = new System.Drawing.Size(860, 373);
            this.rptREINF.TabIndex = 0;
            // 
            // RetornoREINFBindingSource
            // 
            this.RetornoREINFBindingSource.DataSource = typeof(SCI.Model.Report.DCTF.Reinf.RetornoREINF);
            // 
            // imgVoltar
            // 
            this.imgVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgVoltar.Image = global::SCI.Properties.Resources.setaV;
            this.imgVoltar.Location = new System.Drawing.Point(831, 435);
            this.imgVoltar.Name = "imgVoltar";
            this.imgVoltar.Size = new System.Drawing.Size(39, 44);
            this.imgVoltar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgVoltar.TabIndex = 15;
            this.imgVoltar.TabStop = false;
            this.imgVoltar.Visible = false;
            this.imgVoltar.Click += new System.EventHandler(this.imgVoltar_Click);
            // 
            // pctLoad
            // 
            this.pctLoad.BackgroundImage = global::SCI.Properties.Resources.engrenagem;
            this.pctLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctLoad.Location = new System.Drawing.Point(601, 435);
            this.pctLoad.Name = "pctLoad";
            this.pctLoad.Size = new System.Drawing.Size(34, 28);
            this.pctLoad.TabIndex = 16;
            this.pctLoad.TabStop = false;
            this.pctLoad.Visible = false;
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Font = new System.Drawing.Font("NetTerm ANSI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoad.Location = new System.Drawing.Point(481, 466);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(154, 13);
            this.lblLoad.TabIndex = 17;
            this.lblLoad.Text = "Processando, aguarde.";
            this.lblLoad.Visible = false;
            // 
            // EnvioDeArquivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.pctLoad);
            this.Controls.Add(this.imgVoltar);
            this.Controls.Add(this.gpbEnviados);
            this.Controls.Add(this.imgEnviar);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.btnDes);
            this.Controls.Add(this.gpbArquivos);
            this.Excluir = true;
            this.Name = "EnvioDeArquivos";
            this.Salvar = true;
            this.ShowCustom = false;
            this.Size = new System.Drawing.Size(890, 503);
            this.AfterLoad += new System.EventHandler(this.EnvioDeArquivos_AfterLoad);
            this.Controls.SetChildIndex(this.gpbArquivos, 0);
            this.Controls.SetChildIndex(this.btnDes, 0);
            this.Controls.SetChildIndex(this.btnSel, 0);
            this.Controls.SetChildIndex(this.imgEnviar, 0);
            this.Controls.SetChildIndex(this.gpbEnviados, 0);
            this.Controls.SetChildIndex(this.imgVoltar, 0);
            this.Controls.SetChildIndex(this.pctLoad, 0);
            this.Controls.SetChildIndex(this.lblLoad, 0);
            this.gpbArquivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgEnviar)).EndInit();
            this.gpbEnviados.ResumeLayout(false);
            this.gpbEnviados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RetornoREINFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVoltar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbArquivos;
        private System.Windows.Forms.Panel pnlArquivo;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Button btnDes;
        private System.Windows.Forms.PictureBox imgEnviar;
        private System.Windows.Forms.GroupBox gpbEnviados;
        private Microsoft.Reporting.WinForms.ReportViewer rptREINF;
        private System.Windows.Forms.BindingSource RetornoREINFBindingSource;
        private System.Windows.Forms.PictureBox imgVoltar;
        private System.Windows.Forms.PictureBox pctLoad;
        private System.Windows.Forms.Label lblLoad;
    }
}
