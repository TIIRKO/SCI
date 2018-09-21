namespace SCI.View
{
    partial class Desktop
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Desktop));
            this.spcDesktop = new System.Windows.Forms.SplitContainer();
            this.txtFiltroMenu = new System.Windows.Forms.TextBox();
            this.trvMenu = new System.Windows.Forms.TreeView();
            this.imlMenu = new System.Windows.Forms.ImageList(this.components);
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.seletorEmpresa = new SCI.View.Controles.SeletorEmpresa();
            this.cbbFormulario = new System.Windows.Forms.ComboBox();
            this.lblHideShow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spcDesktop)).BeginInit();
            this.spcDesktop.Panel1.SuspendLayout();
            this.spcDesktop.Panel2.SuspendLayout();
            this.spcDesktop.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcDesktop
            // 
            this.spcDesktop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcDesktop.Location = new System.Drawing.Point(0, 0);
            this.spcDesktop.Name = "spcDesktop";
            // 
            // spcDesktop.Panel1
            // 
            this.spcDesktop.Panel1.Controls.Add(this.txtFiltroMenu);
            this.spcDesktop.Panel1.Controls.Add(this.trvMenu);
            this.spcDesktop.Panel1.Controls.Add(this.pnlLogo);
            this.spcDesktop.Panel1.Resize += new System.EventHandler(this.SpcDesktop_Panel1_Resize);
            // 
            // spcDesktop.Panel2
            // 
            this.spcDesktop.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.spcDesktop.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.spcDesktop.Panel2.Controls.Add(this.pnlSuperior);
            this.spcDesktop.Panel2.Controls.Add(this.lblHideShow);
            this.spcDesktop.Panel2.Resize += new System.EventHandler(this.SpcDesktop_Panel2_Resize);
            this.spcDesktop.Size = new System.Drawing.Size(1129, 466);
            this.spcDesktop.SplitterDistance = 211;
            this.spcDesktop.TabIndex = 0;
            this.spcDesktop.TabStop = false;
            this.spcDesktop.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.SpcDesktop_SplitterMoving);
            this.spcDesktop.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SpcDesktop_SplitterMoved);
            // 
            // txtFiltroMenu
            // 
            this.txtFiltroMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroMenu.Location = new System.Drawing.Point(4, 71);
            this.txtFiltroMenu.Name = "txtFiltroMenu";
            this.txtFiltroMenu.Size = new System.Drawing.Size(200, 20);
            this.txtFiltroMenu.TabIndex = 0;
            this.txtFiltroMenu.TabStop = false;
            this.txtFiltroMenu.TextChanged += new System.EventHandler(this.TxtFiltroMenu_TextChanged);
            // 
            // trvMenu
            // 
            this.trvMenu.ImageIndex = 0;
            this.trvMenu.ImageList = this.imlMenu;
            this.trvMenu.Location = new System.Drawing.Point(4, 97);
            this.trvMenu.Name = "trvMenu";
            this.trvMenu.SelectedImageIndex = 0;
            this.trvMenu.Size = new System.Drawing.Size(200, 365);
            this.trvMenu.TabIndex = 0;
            this.trvMenu.TabStop = false;
            this.trvMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TrvMenu_NodeMouseDoubleClick);
            this.trvMenu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TrvMenu_KeyPress);
            // 
            // imlMenu
            // 
            this.imlMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMenu.ImageStream")));
            this.imlMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMenu.Images.SetKeyName(0, "fixedbyvonnie-folder-icon-windows-8-1.png");
            this.imlMenu.Images.SetKeyName(1, "File - Document.ico");
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLogo.Controls.Add(this.ptbLogo);
            this.pnlLogo.Location = new System.Drawing.Point(4, 4);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(200, 61);
            this.pnlLogo.TabIndex = 0;
            // 
            // ptbLogo
            // 
            this.ptbLogo.Image = global::SCI.Properties.Resources.logo_somente_o_nome;
            this.ptbLogo.Location = new System.Drawing.Point(0, -1);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Padding = new System.Windows.Forms.Padding(2);
            this.ptbLogo.Size = new System.Drawing.Size(200, 61);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbLogo.TabIndex = 0;
            this.ptbLogo.TabStop = false;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSuperior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSuperior.Controls.Add(this.seletorEmpresa);
            this.pnlSuperior.Controls.Add(this.cbbFormulario);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(5, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlSuperior.Size = new System.Drawing.Size(905, 50);
            this.pnlSuperior.TabIndex = 2;
            // 
            // seletorEmpresa
            // 
            this.seletorEmpresa.EmpresaPadrao = ((long)(999));
            this.seletorEmpresa.Location = new System.Drawing.Point(3, -1);
            this.seletorEmpresa.Name = "seletorEmpresa";
            this.seletorEmpresa.PermiteGravarEmpresa = true;
            this.seletorEmpresa.PermiteTrocarEmpresa = true;
            this.seletorEmpresa.Size = new System.Drawing.Size(437, 44);
            this.seletorEmpresa.TabIndex = 0;
            this.seletorEmpresa.TabStop = false;
            this.seletorEmpresa.TrocarEmpresa += new System.EventHandler(this.SeletorEmpresa_TrocarEmpresa);
            this.seletorEmpresa.GravarEmpresa += new System.EventHandler(this.SeletorEmpresa_GravarEmpresa);
            this.seletorEmpresa.ChecaTrocaEmpresa += new System.EventHandler(this.SeletorEmpresa_ChecaTrocaEmpresa);
            // 
            // cbbFormulario
            // 
            this.cbbFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbFormulario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbbFormulario.DisplayMember = "Display";
            this.cbbFormulario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFormulario.FormattingEnabled = true;
            this.cbbFormulario.Location = new System.Drawing.Point(593, 15);
            this.cbbFormulario.Name = "cbbFormulario";
            this.cbbFormulario.Size = new System.Drawing.Size(300, 21);
            this.cbbFormulario.TabIndex = 0;
            this.cbbFormulario.TabStop = false;
            this.cbbFormulario.SelectedValueChanged += new System.EventHandler(this.CbbFormulario_SelectedValueChanged);
            // 
            // lblHideShow
            // 
            this.lblHideShow.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblHideShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHideShow.Location = new System.Drawing.Point(0, 0);
            this.lblHideShow.Margin = new System.Windows.Forms.Padding(0);
            this.lblHideShow.Name = "lblHideShow";
            this.lblHideShow.Size = new System.Drawing.Size(5, 462);
            this.lblHideShow.TabIndex = 1;
            this.lblHideShow.Text = " ";
            this.lblHideShow.Click += new System.EventHandler(this.LblHideShow_Click);
            this.lblHideShow.MouseEnter += new System.EventHandler(this.LblHideShow_MouseEnter);
            this.lblHideShow.MouseLeave += new System.EventHandler(this.LblHideShow_MouseLeave);
            // 
            // Desktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 466);
            this.Controls.Add(this.spcDesktop);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Desktop";
            this.Text = "IRKO ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Desktop_FormClosed);
            this.Load += new System.EventHandler(this.Desktop_Load);
            this.Shown += new System.EventHandler(this.Desktop_Shown);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Desktop_Layout);
            this.Resize += new System.EventHandler(this.Desktop_Resize);
            this.spcDesktop.Panel1.ResumeLayout(false);
            this.spcDesktop.Panel1.PerformLayout();
            this.spcDesktop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcDesktop)).EndInit();
            this.spcDesktop.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcDesktop;
        private System.Windows.Forms.PictureBox ptbLogo;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.TreeView trvMenu;
        private System.Windows.Forms.Label lblHideShow;
        private System.Windows.Forms.ImageList imlMenu;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.ComboBox cbbFormulario;
        private Controles.SeletorEmpresa seletorEmpresa;
        private System.Windows.Forms.TextBox txtFiltroMenu;
    }
}

