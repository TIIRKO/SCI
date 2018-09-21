namespace SCI.View.Controles
{
    partial class Funcionario
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
            this.cbbFuncionario = new System.Windows.Forms.ComboBox();
            this.gpbFuncionario = new System.Windows.Forms.GroupBox();
            this.gpbFuncionario.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbFuncionario
            // 
            this.cbbFuncionario.DisplayMember = "Display";
            this.cbbFuncionario.FormattingEnabled = true;
            this.cbbFuncionario.Location = new System.Drawing.Point(6, 19);
            this.cbbFuncionario.Name = "cbbFuncionario";
            this.cbbFuncionario.Size = new System.Drawing.Size(342, 21);
            this.cbbFuncionario.TabIndex = 1;
            this.cbbFuncionario.TabStop = false;
            this.cbbFuncionario.TextUpdate += new System.EventHandler(this.cbbFuncionario_TextUpdate);
            this.cbbFuncionario.SelectedValueChanged += new System.EventHandler(this.cbbFuncionario_SelectedValueChanged);
            this.cbbFuncionario.Enter += new System.EventHandler(this.cbbFuncionario_Enter);
            this.cbbFuncionario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFuncionario_KeyPress);
            this.cbbFuncionario.Leave += new System.EventHandler(this.cbbFuncionario_Leave);
            // 
            // gpbFuncionario
            // 
            this.gpbFuncionario.Controls.Add(this.cbbFuncionario);
            this.gpbFuncionario.Location = new System.Drawing.Point(0, 0);
            this.gpbFuncionario.Name = "gpbFuncionario";
            this.gpbFuncionario.Size = new System.Drawing.Size(356, 50);
            this.gpbFuncionario.TabIndex = 0;
            this.gpbFuncionario.TabStop = false;
            this.gpbFuncionario.Text = "Funcionário";
            // 
            // Funcionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbFuncionario);
            this.Name = "Funcionario";
            this.Size = new System.Drawing.Size(359, 51);
            this.Load += new System.EventHandler(this.Funcionario_Load);
            this.Enter += new System.EventHandler(this.Funcionario_Enter);
            this.Resize += new System.EventHandler(this.Funcionario_Resize);
            this.gpbFuncionario.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbbFuncionario;
        private System.Windows.Forms.GroupBox gpbFuncionario;
    }
}
