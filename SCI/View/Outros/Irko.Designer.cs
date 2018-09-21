namespace SCI.View.Outros
{
    partial class Irko
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
            this.telnet = new ComponentPro.Net.Terminal.TelnetTerminalControl();
            this.SuspendLayout();
            // 
            // telnet
            // 
            this.telnet.BackColor = System.Drawing.Color.Magenta;
            this.telnet.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.telnet.CursorMouse = System.Windows.Forms.Cursors.Arrow;
            this.telnet.CursorText = System.Windows.Forms.Cursors.IBeam;
            this.telnet.InvokeFromCurrentThreads = false;
            this.telnet.Location = new System.Drawing.Point(3, 37);
            this.telnet.Name = "telnet";
            this.telnet.NewLineType = ComponentPro.Net.Terminal.TerminalNewLineType.CRLF;
            this.telnet.ScrollBarEnabled = false;
            this.telnet.Size = new System.Drawing.Size(816, 359);
            this.telnet.TabIndex = 1;
            // 
            // Irko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.telnet);
            this.Excluir = true;
            this.Name = "Irko";
            this.Salvar = true;
            this.ShowCustom = false;
            this.Size = new System.Drawing.Size(905, 467);
            this.AfterLoad += new System.EventHandler(this.Irko_AfterLoad);
            this.Resize += new System.EventHandler(this.Irko_Resize);
            this.Controls.SetChildIndex(this.telnet, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentPro.Net.Terminal.TelnetTerminalControl telnet;
    }
}
