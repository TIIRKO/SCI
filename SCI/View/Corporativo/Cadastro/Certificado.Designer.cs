namespace SCI.View.Corporativo.Cadastro
{
    partial class Certificado
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblArquivo = new System.Windows.Forms.Label();
            this.btnArquivo = new System.Windows.Forms.Button();
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.gpbInfo = new System.Windows.Forms.GroupBox();
            this.gpbSerial = new System.Windows.Forms.GroupBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.gpbVencimento = new System.Windows.Forms.GroupBox();
            this.lblVencimento = new System.Windows.Forms.Label();
            this.gpbResumo = new System.Windows.Forms.GroupBox();
            this.lblResumo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpbInfo.SuspendLayout();
            this.gpbSerial.SuspendLayout();
            this.gpbVencimento.SuspendLayout();
            this.gpbResumo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblArquivo);
            this.groupBox1.Controls.Add(this.btnArquivo);
            this.groupBox1.Location = new System.Drawing.Point(5, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro Digital";
            // 
            // lblArquivo
            // 
            this.lblArquivo.Location = new System.Drawing.Point(6, 19);
            this.lblArquivo.Name = "lblArquivo";
            this.lblArquivo.Size = new System.Drawing.Size(394, 23);
            this.lblArquivo.TabIndex = 5;
            // 
            // btnArquivo
            // 
            this.btnArquivo.Location = new System.Drawing.Point(406, 19);
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.Size = new System.Drawing.Size(75, 23);
            this.btnArquivo.TabIndex = 4;
            this.btnArquivo.Text = "Arquivo";
            this.btnArquivo.UseVisualStyleBackColor = true;
            this.btnArquivo.Click += new System.EventHandler(this.btnArquivo_Click);
            // 
            // ofdArquivo
            // 
            this.ofdArquivo.InitialDirectory = "@\"C:\\\"";
            this.ofdArquivo.Title = "Selecione o arquivo...";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSenha);
            this.groupBox2.Location = new System.Drawing.Point(5, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(6, 19);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(128, 20);
            this.txtSenha.TabIndex = 3;
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(152, 109);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(75, 23);
            this.btnCarregar.TabIndex = 3;
            this.btnCarregar.Text = "Carregar";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // gpbInfo
            // 
            this.gpbInfo.Controls.Add(this.gpbSerial);
            this.gpbInfo.Controls.Add(this.gpbVencimento);
            this.gpbInfo.Controls.Add(this.gpbResumo);
            this.gpbInfo.Location = new System.Drawing.Point(5, 162);
            this.gpbInfo.Name = "gpbInfo";
            this.gpbInfo.Size = new System.Drawing.Size(675, 136);
            this.gpbInfo.TabIndex = 4;
            this.gpbInfo.TabStop = false;
            this.gpbInfo.Text = "Informações do Certificado";
            // 
            // gpbSerial
            // 
            this.gpbSerial.Controls.Add(this.lblSerial);
            this.gpbSerial.Location = new System.Drawing.Point(228, 75);
            this.gpbSerial.Name = "gpbSerial";
            this.gpbSerial.Size = new System.Drawing.Size(291, 50);
            this.gpbSerial.TabIndex = 2;
            this.gpbSerial.TabStop = false;
            this.gpbSerial.Text = "Serial";
            // 
            // lblSerial
            // 
            this.lblSerial.Location = new System.Drawing.Point(6, 16);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(279, 23);
            this.lblSerial.TabIndex = 2;
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gpbVencimento
            // 
            this.gpbVencimento.Controls.Add(this.lblVencimento);
            this.gpbVencimento.Location = new System.Drawing.Point(6, 75);
            this.gpbVencimento.Name = "gpbVencimento";
            this.gpbVencimento.Size = new System.Drawing.Size(216, 50);
            this.gpbVencimento.TabIndex = 1;
            this.gpbVencimento.TabStop = false;
            this.gpbVencimento.Text = "Vencimento";
            // 
            // lblVencimento
            // 
            this.lblVencimento.Location = new System.Drawing.Point(4, 16);
            this.lblVencimento.Name = "lblVencimento";
            this.lblVencimento.Size = new System.Drawing.Size(204, 23);
            this.lblVencimento.TabIndex = 1;
            this.lblVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gpbResumo
            // 
            this.gpbResumo.Controls.Add(this.lblResumo);
            this.gpbResumo.Location = new System.Drawing.Point(6, 19);
            this.gpbResumo.Name = "gpbResumo";
            this.gpbResumo.Size = new System.Drawing.Size(663, 50);
            this.gpbResumo.TabIndex = 0;
            this.gpbResumo.TabStop = false;
            this.gpbResumo.Text = "Resumo";
            // 
            // lblResumo
            // 
            this.lblResumo.Location = new System.Drawing.Point(6, 16);
            this.lblResumo.Name = "lblResumo";
            this.lblResumo.Size = new System.Drawing.Size(651, 23);
            this.lblResumo.TabIndex = 0;
            this.lblResumo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Certificado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.gpbInfo);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Excluir = true;
            this.ExibirBotoes = true;
            this.Name = "Certificado";
            this.Salvar = true;
            this.ShowCustom = false;
            this.SalvarClick += new System.EventHandler(this.Certificado_SalvarClick);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnCarregar, 0);
            this.Controls.SetChildIndex(this.gpbInfo, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpbInfo.ResumeLayout(false);
            this.gpbSerial.ResumeLayout(false);
            this.gpbVencimento.ResumeLayout(false);
            this.gpbResumo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblArquivo;
        private System.Windows.Forms.Button btnArquivo;
        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.GroupBox gpbInfo;
        private System.Windows.Forms.GroupBox gpbResumo;
        private System.Windows.Forms.GroupBox gpbSerial;
        private System.Windows.Forms.GroupBox gpbVencimento;
        private System.Windows.Forms.Label lblResumo;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblVencimento;
    }
}
