namespace SCI.View.Controles
{
    partial class Competencia
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
            this.txtCompetencia = new System.Windows.Forms.MaskedTextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.gpbCompetencia = new System.Windows.Forms.GroupBox();
            this.lblReadOnly = new System.Windows.Forms.Label();
            this.gpbCompetencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCompetencia
            // 
            this.txtCompetencia.Location = new System.Drawing.Point(3, 20);
            this.txtCompetencia.Mask = "99/9999";
            this.txtCompetencia.Name = "txtCompetencia";
            this.txtCompetencia.Size = new System.Drawing.Size(51, 20);
            this.txtCompetencia.TabIndex = 1;
            this.txtCompetencia.TabStop = false;
            this.txtCompetencia.Leave += new System.EventHandler(this.txtCompetencia_Leave);
            // 
            // lblDescricao
            // 
            this.lblDescricao.Location = new System.Drawing.Point(60, 20);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(113, 20);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gpbCompetencia
            // 
            this.gpbCompetencia.Controls.Add(this.lblReadOnly);
            this.gpbCompetencia.Controls.Add(this.txtCompetencia);
            this.gpbCompetencia.Controls.Add(this.lblDescricao);
            this.gpbCompetencia.Location = new System.Drawing.Point(0, 0);
            this.gpbCompetencia.Name = "gpbCompetencia";
            this.gpbCompetencia.Size = new System.Drawing.Size(210, 50);
            this.gpbCompetencia.TabIndex = 0;
            this.gpbCompetencia.TabStop = false;
            this.gpbCompetencia.Text = "Competência";
            // 
            // lblReadOnly
            // 
            this.lblReadOnly.Location = new System.Drawing.Point(3, 20);
            this.lblReadOnly.Name = "lblReadOnly";
            this.lblReadOnly.Size = new System.Drawing.Size(51, 20);
            this.lblReadOnly.TabIndex = 0;
            this.lblReadOnly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblReadOnly.Visible = false;
            // 
            // Competencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbCompetencia);
            this.Name = "Competencia";
            this.Size = new System.Drawing.Size(210, 50);
            this.Enter += new System.EventHandler(this.Competencia_Enter);
            this.Resize += new System.EventHandler(this.Competencia_Resize);
            this.gpbCompetencia.ResumeLayout(false);
            this.gpbCompetencia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtCompetencia;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.GroupBox gpbCompetencia;
        private System.Windows.Forms.Label lblReadOnly;
    }
}
