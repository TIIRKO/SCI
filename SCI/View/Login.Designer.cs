namespace SCI.View
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.cbbIdioma = new System.Windows.Forms.ComboBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gpbIdioma = new System.Windows.Forms.GroupBox();
            this.gpbSenha = new System.Windows.Forms.GroupBox();
            this.gpbUsuario = new System.Windows.Forms.GroupBox();
            this.gpbSistema = new System.Windows.Forms.GroupBox();
            this.cbbSistema = new System.Windows.Forms.ComboBox();
            this.gpbIdioma.SuspendLayout();
            this.gpbSenha.SuspendLayout();
            this.gpbUsuario.SuspendLayout();
            this.gpbSistema.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(6, 19);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(156, 20);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUsuario_KeyPress);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(6, 19);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(156, 20);
            this.txtSenha.TabIndex = 0;
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSenha_KeyPress);
            // 
            // cbbIdioma
            // 
            this.cbbIdioma.DisplayMember = "Descricao";
            this.cbbIdioma.FormattingEnabled = true;
            this.cbbIdioma.Location = new System.Drawing.Point(6, 19);
            this.cbbIdioma.Name = "cbbIdioma";
            this.cbbIdioma.Size = new System.Drawing.Size(156, 21);
            this.cbbIdioma.TabIndex = 0;
            this.cbbIdioma.SelectedIndexChanged += new System.EventHandler(this.CbbIdioma_SelectedIndexChanged);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(18, 236);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(99, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Limpar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // gpbIdioma
            // 
            this.gpbIdioma.BackColor = System.Drawing.Color.Transparent;
            this.gpbIdioma.Controls.Add(this.cbbIdioma);
            this.gpbIdioma.Location = new System.Drawing.Point(12, 68);
            this.gpbIdioma.Name = "gpbIdioma";
            this.gpbIdioma.Size = new System.Drawing.Size(172, 50);
            this.gpbIdioma.TabIndex = 1;
            this.gpbIdioma.TabStop = false;
            this.gpbIdioma.Text = "Idioma";
            // 
            // gpbSenha
            // 
            this.gpbSenha.BackColor = System.Drawing.Color.Transparent;
            this.gpbSenha.Controls.Add(this.txtSenha);
            this.gpbSenha.Location = new System.Drawing.Point(12, 180);
            this.gpbSenha.Name = "gpbSenha";
            this.gpbSenha.Size = new System.Drawing.Size(172, 50);
            this.gpbSenha.TabIndex = 3;
            this.gpbSenha.TabStop = false;
            this.gpbSenha.Text = "Senha";
            // 
            // gpbUsuario
            // 
            this.gpbUsuario.BackColor = System.Drawing.Color.Transparent;
            this.gpbUsuario.Controls.Add(this.txtUsuario);
            this.gpbUsuario.Location = new System.Drawing.Point(12, 124);
            this.gpbUsuario.Name = "gpbUsuario";
            this.gpbUsuario.Size = new System.Drawing.Size(172, 50);
            this.gpbUsuario.TabIndex = 2;
            this.gpbUsuario.TabStop = false;
            this.gpbUsuario.Text = "Usuário";
            // 
            // gpbSistema
            // 
            this.gpbSistema.BackColor = System.Drawing.Color.Transparent;
            this.gpbSistema.Controls.Add(this.cbbSistema);
            this.gpbSistema.Location = new System.Drawing.Point(12, 12);
            this.gpbSistema.Name = "gpbSistema";
            this.gpbSistema.Size = new System.Drawing.Size(172, 50);
            this.gpbSistema.TabIndex = 0;
            this.gpbSistema.TabStop = false;
            this.gpbSistema.Text = "Sistema";
            // 
            // cbbSistema
            // 
            this.cbbSistema.DisplayMember = "Descricao";
            this.cbbSistema.FormattingEnabled = true;
            this.cbbSistema.Items.AddRange(new object[] {
            "IRKO",
            "Painel Sistema"});
            this.cbbSistema.Location = new System.Drawing.Point(6, 19);
            this.cbbSistema.Name = "cbbSistema";
            this.cbbSistema.Size = new System.Drawing.Size(156, 21);
            this.cbbSistema.TabIndex = 0;
            this.cbbSistema.Text = "IRKO";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(195, 279);
            this.Controls.Add(this.gpbSistema);
            this.Controls.Add(this.gpbSenha);
            this.Controls.Add(this.gpbUsuario);
            this.Controls.Add(this.gpbIdioma);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnEnviar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "Bem Vindo";
            this.gpbIdioma.ResumeLayout(false);
            this.gpbSenha.ResumeLayout(false);
            this.gpbSenha.PerformLayout();
            this.gpbUsuario.ResumeLayout(false);
            this.gpbUsuario.PerformLayout();
            this.gpbSistema.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.ComboBox cbbIdioma;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gpbIdioma;
        private System.Windows.Forms.GroupBox gpbSenha;
        private System.Windows.Forms.GroupBox gpbUsuario;
        private System.Windows.Forms.GroupBox gpbSistema;
        private System.Windows.Forms.ComboBox cbbSistema;
    }
}