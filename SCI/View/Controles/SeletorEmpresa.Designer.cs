namespace SCI.View.Controles
{
    partial class SeletorEmpresa
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
            this.gpbEmpresa = new System.Windows.Forms.GroupBox();
            this.btnAcao = new System.Windows.Forms.Button();
            this.cbbEmpresa = new System.Windows.Forms.ComboBox();
            this.gpbEmpresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbEmpresa
            // 
            this.gpbEmpresa.Controls.Add(this.btnAcao);
            this.gpbEmpresa.Controls.Add(this.cbbEmpresa);
            this.gpbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbEmpresa.Location = new System.Drawing.Point(0, 0);
            this.gpbEmpresa.Name = "gpbEmpresa";
            this.gpbEmpresa.Size = new System.Drawing.Size(565, 44);
            this.gpbEmpresa.TabIndex = 0;
            this.gpbEmpresa.TabStop = false;
            this.gpbEmpresa.Text = "Empresa";
            // 
            // btnAcao
            // 
            this.btnAcao.Location = new System.Drawing.Point(484, 15);
            this.btnAcao.Name = "btnAcao";
            this.btnAcao.Size = new System.Drawing.Size(75, 23);
            this.btnAcao.TabIndex = 1;
            this.btnAcao.Text = "Trocar";
            this.btnAcao.UseVisualStyleBackColor = true;
            this.btnAcao.Click += new System.EventHandler(this.btnAcao_Click);
            // 
            // cbbEmpresa
            // 
            this.cbbEmpresa.DisplayMember = "Display";
            this.cbbEmpresa.Enabled = false;
            this.cbbEmpresa.FormattingEnabled = true;
            this.cbbEmpresa.Location = new System.Drawing.Point(6, 17);
            this.cbbEmpresa.Name = "cbbEmpresa";
            this.cbbEmpresa.Size = new System.Drawing.Size(472, 21);
            this.cbbEmpresa.TabIndex = 0;
            this.cbbEmpresa.TextUpdate += new System.EventHandler(this.cbbEmpresa_TextUpdate);
            this.cbbEmpresa.SelectedValueChanged += new System.EventHandler(this.cbbEmpresa_SelectedValueChanged);
            this.cbbEmpresa.Enter += new System.EventHandler(this.cbbEmpresa_Enter);
            this.cbbEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbEmpresa_KeyPress);
            // 
            // SeletorEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbEmpresa);
            this.Name = "SeletorEmpresa";
            this.Size = new System.Drawing.Size(567, 44);
            this.Load += new System.EventHandler(this.SeletorEmpresa_Load);
            this.Resize += new System.EventHandler(this.SeletorEmpresa_Resize);
            this.gpbEmpresa.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbEmpresa;
        private System.Windows.Forms.ComboBox cbbEmpresa;
        private System.Windows.Forms.Button btnAcao;
    }
}
