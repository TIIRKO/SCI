namespace SCI.View.Controles
{
    partial class NumericTextBox
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
            this.txtNumeric = new System.Windows.Forms.TextBox();
            this.gpbNumeric = new System.Windows.Forms.GroupBox();
            this.gpbNumeric.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumeric
            // 
            this.txtNumeric.Location = new System.Drawing.Point(3, 19);
            this.txtNumeric.Name = "txtNumeric";
            this.txtNumeric.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumeric.Size = new System.Drawing.Size(94, 20);
            this.txtNumeric.TabIndex = 0;
            this.txtNumeric.TextChanged += new System.EventHandler(this.txtNumeric_TextChanged);
            // 
            // gpbNumeric
            // 
            this.gpbNumeric.Controls.Add(this.txtNumeric);
            this.gpbNumeric.Location = new System.Drawing.Point(0, 0);
            this.gpbNumeric.Name = "gpbNumeric";
            this.gpbNumeric.Size = new System.Drawing.Size(100, 50);
            this.gpbNumeric.TabIndex = 1;
            this.gpbNumeric.TabStop = false;
            this.gpbNumeric.Text = "Label";
            // 
            // NumericTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbNumeric);
            this.Name = "NumericTextBox";
            this.Size = new System.Drawing.Size(100, 50);
            this.Load += new System.EventHandler(this.NumericTextBox_Load);
            this.Resize += new System.EventHandler(this.NumericTextBox_Resize);
            this.gpbNumeric.ResumeLayout(false);
            this.gpbNumeric.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumeric;
        private System.Windows.Forms.GroupBox gpbNumeric;
    }
}
