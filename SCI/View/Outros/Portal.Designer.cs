namespace SCI.View.Outros
{
    partial class Portal
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
            this.wbsPortal = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbsPortal
            // 
            this.wbsPortal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbsPortal.Location = new System.Drawing.Point(0, 0);
            this.wbsPortal.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbsPortal.Name = "wbsPortal";
            this.wbsPortal.ScriptErrorsSuppressed = true;
            this.wbsPortal.Size = new System.Drawing.Size(685, 443);
            this.wbsPortal.TabIndex = 1;
            this.wbsPortal.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // Portal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.wbsPortal);
            this.Excluir = true;
            this.ExibirTitulo = false;
            this.Name = "Portal";
            this.Salvar = true;
            this.ShowCustom = false;
            this.AfterLoad += new System.EventHandler(this.Portal_AfterLoad);
            this.Resize += new System.EventHandler(this.Portal_Resize);
            this.Controls.SetChildIndex(this.wbsPortal, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbsPortal;
    }
}
