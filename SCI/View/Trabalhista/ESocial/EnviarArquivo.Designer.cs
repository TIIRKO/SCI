namespace SCI.View.Trabalhista.ESocial
{
    partial class EnviarArquivo
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
            this.gpbArquivos = new System.Windows.Forms.GroupBox();
            this.pnlArquivo = new System.Windows.Forms.Panel();
            this.btnSel = new System.Windows.Forms.Button();
            this.btnDes = new System.Windows.Forms.Button();
            this.gpbEnviados = new System.Windows.Forms.GroupBox();
            this.trvEnviado = new System.Windows.Forms.TreeView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.gpbArquivos.SuspendLayout();
            this.gpbEnviados.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbArquivos
            // 
            this.gpbArquivos.Controls.Add(this.pnlArquivo);
            this.gpbArquivos.Location = new System.Drawing.Point(5, 37);
            this.gpbArquivos.Name = "gpbArquivos";
            this.gpbArquivos.Size = new System.Drawing.Size(675, 392);
            this.gpbArquivos.TabIndex = 1;
            this.gpbArquivos.TabStop = false;
            this.gpbArquivos.Text = "Arquivos do E-Social";
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
            this.btnSel.Location = new System.Drawing.Point(11, 435);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(120, 23);
            this.btnSel.TabIndex = 2;
            this.btnSel.Text = "Selecionar Tudo";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.BtnSel_Click);
            // 
            // btnDes
            // 
            this.btnDes.Location = new System.Drawing.Point(137, 435);
            this.btnDes.Name = "btnDes";
            this.btnDes.Size = new System.Drawing.Size(120, 23);
            this.btnDes.TabIndex = 3;
            this.btnDes.Text = "Desselecionar Tudo";
            this.btnDes.UseVisualStyleBackColor = true;
            this.btnDes.Click += new System.EventHandler(this.BtnDes_Click);
            // 
            // gpbEnviados
            // 
            this.gpbEnviados.Controls.Add(this.trvEnviado);
            this.gpbEnviados.Location = new System.Drawing.Point(5, 37);
            this.gpbEnviados.Name = "gpbEnviados";
            this.gpbEnviados.Size = new System.Drawing.Size(675, 392);
            this.gpbEnviados.TabIndex = 1;
            this.gpbEnviados.TabStop = false;
            this.gpbEnviados.Text = "Arquivos Enviados";
            this.gpbEnviados.Visible = false;
            // 
            // trvEnviado
            // 
            this.trvEnviado.Location = new System.Drawing.Point(9, 22);
            this.trvEnviado.Name = "trvEnviado";
            this.trvEnviado.Size = new System.Drawing.Size(657, 361);
            this.trvEnviado.TabIndex = 0;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(11, 435);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(120, 23);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Visible = false;
            this.btnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // EnviarArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.btnDes);
            this.Controls.Add(this.gpbEnviados);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.gpbArquivos);
            this.Controls.Add(this.btnSel);
            this.Excluir = true;
            this.Name = "EnviarArquivo";
            this.Salvar = true;
            this.ShowCustom = false;
            this.Size = new System.Drawing.Size(685, 522);
            this.TextoCustom = "Enviar";
            this.AfterLoad += new System.EventHandler(this.EnviarArquivo_AfterLoad);
            this.BtnCustomClick += new System.EventHandler(this.EnviarArquivo_BtnCustomClick);
            this.Controls.SetChildIndex(this.btnSel, 0);
            this.Controls.SetChildIndex(this.gpbArquivos, 0);
            this.Controls.SetChildIndex(this.btnVoltar, 0);
            this.Controls.SetChildIndex(this.gpbEnviados, 0);
            this.Controls.SetChildIndex(this.btnDes, 0);
            this.gpbArquivos.ResumeLayout(false);
            this.gpbEnviados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbArquivos;
        private System.Windows.Forms.Panel pnlArquivo;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Button btnDes;
        private System.Windows.Forms.GroupBox gpbEnviados;
        private System.Windows.Forms.TreeView trvEnviado;
        private System.Windows.Forms.Button btnVoltar;
    }
}
