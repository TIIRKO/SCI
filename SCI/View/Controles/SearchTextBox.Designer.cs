namespace SCI.View.Controles
{
    partial class SearchTextBox
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
            this.cbbSearchTextBox = new System.Windows.Forms.ComboBox();
            this.gpbSearchTextBox = new System.Windows.Forms.GroupBox();
            this.lblReadOnly = new System.Windows.Forms.Label();
            this.gpbSearchTextBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbSearchTextBox
            // 
            this.cbbSearchTextBox.DisplayMember = "Display";
            this.cbbSearchTextBox.FormattingEnabled = true;
            this.cbbSearchTextBox.Location = new System.Drawing.Point(6, 19);
            this.cbbSearchTextBox.Name = "cbbSearchTextBox";
            this.cbbSearchTextBox.Size = new System.Drawing.Size(342, 21);
            this.cbbSearchTextBox.TabIndex = 1;
            this.cbbSearchTextBox.TabStop = false;
            this.cbbSearchTextBox.TextUpdate += new System.EventHandler(this.cbbSearchTextBox_TextUpdate);
            this.cbbSearchTextBox.SelectedValueChanged += new System.EventHandler(this.cbbSearchTextBox_SelectedValueChanged);
            this.cbbSearchTextBox.Enter += new System.EventHandler(this.cbbSearchTextBox_Enter);
            this.cbbSearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbSearchTextBox_KeyPress);
            this.cbbSearchTextBox.Leave += new System.EventHandler(this.cbbSearchTextBox_Leave);
            // 
            // gpbSearchTextBox
            // 
            this.gpbSearchTextBox.Controls.Add(this.lblReadOnly);
            this.gpbSearchTextBox.Controls.Add(this.cbbSearchTextBox);
            this.gpbSearchTextBox.Location = new System.Drawing.Point(0, 0);
            this.gpbSearchTextBox.Name = "gpbSearchTextBox";
            this.gpbSearchTextBox.Size = new System.Drawing.Size(356, 50);
            this.gpbSearchTextBox.TabIndex = 0;
            this.gpbSearchTextBox.TabStop = false;
            this.gpbSearchTextBox.Text = "Label";
            // 
            // lblReadOnly
            // 
            this.lblReadOnly.Location = new System.Drawing.Point(6, 19);
            this.lblReadOnly.Name = "lblReadOnly";
            this.lblReadOnly.Size = new System.Drawing.Size(342, 21);
            this.lblReadOnly.TabIndex = 0;
            this.lblReadOnly.Visible = false;
            // 
            // SearchTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbSearchTextBox);
            this.Name = "SearchTextBox";
            this.Size = new System.Drawing.Size(356, 50);
            this.Load += new System.EventHandler(this.SearchTextBox_Load);
            this.Enter += new System.EventHandler(this.SearchTextBox_Enter);
            this.Resize += new System.EventHandler(this.SearchTextBox_Resize);
            this.gpbSearchTextBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbSearchTextBox;
        private System.Windows.Forms.GroupBox gpbSearchTextBox;
        private System.Windows.Forms.Label lblReadOnly;
    }
}
