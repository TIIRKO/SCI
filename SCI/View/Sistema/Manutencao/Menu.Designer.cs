namespace SCI.View.Sistema.Manutencao
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.trvMenu = new System.Windows.Forms.TreeView();
            this.imlMenu = new System.Windows.Forms.ImageList(this.components);
            this.gpbNome = new System.Windows.Forms.GroupBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.gpbTipo = new System.Windows.Forms.GroupBox();
            this.rdbCache = new System.Windows.Forms.RadioButton();
            this.rdbCliente = new System.Windows.Forms.RadioButton();
            this.rdbMenu = new System.Windows.Forms.RadioButton();
            this.gpbPrograma = new System.Windows.Forms.GroupBox();
            this.txtPrograma = new System.Windows.Forms.TextBox();
            this.gpbDescricao = new System.Windows.Forms.GroupBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.gpbNamespace = new System.Windows.Forms.GroupBox();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.gpbTrocaEmpresa = new System.Windows.Forms.GroupBox();
            this.ckbTrocaEmpresa = new System.Windows.Forms.CheckBox();
            this.gpbMultiTelas = new System.Windows.Forms.GroupBox();
            this.ckbMultiTelas = new System.Windows.Forms.CheckBox();
            this.gpbOpcCos = new System.Windows.Forms.GroupBox();
            this.txtOpcaoCOS = new System.Windows.Forms.TextBox();
            this.gpbAtivo = new System.Windows.Forms.GroupBox();
            this.ckbAtivo = new System.Windows.Forms.CheckBox();
            this.gpbNome.SuspendLayout();
            this.gpbTipo.SuspendLayout();
            this.gpbPrograma.SuspendLayout();
            this.gpbDescricao.SuspendLayout();
            this.gpbNamespace.SuspendLayout();
            this.gpbTrocaEmpresa.SuspendLayout();
            this.gpbMultiTelas.SuspendLayout();
            this.gpbOpcCos.SuspendLayout();
            this.gpbAtivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvMenu
            // 
            this.trvMenu.HideSelection = false;
            this.trvMenu.ImageIndex = 0;
            this.trvMenu.ImageList = this.imlMenu;
            this.trvMenu.Location = new System.Drawing.Point(5, 37);
            this.trvMenu.Name = "trvMenu";
            this.trvMenu.SelectedImageIndex = 0;
            this.trvMenu.Size = new System.Drawing.Size(322, 431);
            this.trvMenu.TabIndex = 1;
            this.trvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMenu_AfterSelect);
            this.trvMenu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvMenu_NodeMouseClick);
            this.trvMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvMenu_NodeMouseDoubleClick);
            // 
            // imlMenu
            // 
            this.imlMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMenu.ImageStream")));
            this.imlMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMenu.Images.SetKeyName(0, "fixedbyvonnie-folder-icon-windows-8-1.png");
            this.imlMenu.Images.SetKeyName(1, "File - Document.ico");
            // 
            // gpbNome
            // 
            this.gpbNome.Controls.Add(this.txtNome);
            this.gpbNome.Location = new System.Drawing.Point(333, 37);
            this.gpbNome.Name = "gpbNome";
            this.gpbNome.Size = new System.Drawing.Size(347, 50);
            this.gpbNome.TabIndex = 2;
            this.gpbNome.TabStop = false;
            this.gpbNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(6, 19);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(335, 20);
            this.txtNome.TabIndex = 0;
            // 
            // gpbTipo
            // 
            this.gpbTipo.Controls.Add(this.rdbCache);
            this.gpbTipo.Controls.Add(this.rdbCliente);
            this.gpbTipo.Controls.Add(this.rdbMenu);
            this.gpbTipo.Location = new System.Drawing.Point(333, 194);
            this.gpbTipo.Name = "gpbTipo";
            this.gpbTipo.Size = new System.Drawing.Size(275, 50);
            this.gpbTipo.TabIndex = 3;
            this.gpbTipo.TabStop = false;
            this.gpbTipo.Text = "Tipo";
            // 
            // rdbCache
            // 
            this.rdbCache.AutoSize = true;
            this.rdbCache.Location = new System.Drawing.Point(184, 19);
            this.rdbCache.Name = "rdbCache";
            this.rdbCache.Size = new System.Drawing.Size(56, 17);
            this.rdbCache.TabIndex = 2;
            this.rdbCache.TabStop = true;
            this.rdbCache.Text = "Caché";
            this.rdbCache.UseVisualStyleBackColor = true;
            // 
            // rdbCliente
            // 
            this.rdbCliente.AutoSize = true;
            this.rdbCliente.Location = new System.Drawing.Point(99, 19);
            this.rdbCliente.Name = "rdbCliente";
            this.rdbCliente.Size = new System.Drawing.Size(57, 17);
            this.rdbCliente.TabIndex = 1;
            this.rdbCliente.TabStop = true;
            this.rdbCliente.Text = "Cliente";
            this.rdbCliente.UseVisualStyleBackColor = true;
            // 
            // rdbMenu
            // 
            this.rdbMenu.AutoSize = true;
            this.rdbMenu.Location = new System.Drawing.Point(6, 19);
            this.rdbMenu.Name = "rdbMenu";
            this.rdbMenu.Size = new System.Drawing.Size(52, 17);
            this.rdbMenu.TabIndex = 0;
            this.rdbMenu.TabStop = true;
            this.rdbMenu.Text = "Menu";
            this.rdbMenu.UseVisualStyleBackColor = true;
            // 
            // gpbPrograma
            // 
            this.gpbPrograma.Controls.Add(this.txtPrograma);
            this.gpbPrograma.Location = new System.Drawing.Point(333, 250);
            this.gpbPrograma.Name = "gpbPrograma";
            this.gpbPrograma.Size = new System.Drawing.Size(347, 50);
            this.gpbPrograma.TabIndex = 4;
            this.gpbPrograma.TabStop = false;
            this.gpbPrograma.Text = "Programa";
            // 
            // txtPrograma
            // 
            this.txtPrograma.Location = new System.Drawing.Point(6, 19);
            this.txtPrograma.MaxLength = 255;
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.Size = new System.Drawing.Size(335, 20);
            this.txtPrograma.TabIndex = 0;
            // 
            // gpbDescricao
            // 
            this.gpbDescricao.Controls.Add(this.txtDescricao);
            this.gpbDescricao.Location = new System.Drawing.Point(333, 93);
            this.gpbDescricao.Name = "gpbDescricao";
            this.gpbDescricao.Size = new System.Drawing.Size(347, 95);
            this.gpbDescricao.TabIndex = 5;
            this.gpbDescricao.TabStop = false;
            this.gpbDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(6, 19);
            this.txtDescricao.MaxLength = 1024;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(335, 70);
            this.txtDescricao.TabIndex = 0;
            // 
            // gpbNamespace
            // 
            this.gpbNamespace.Controls.Add(this.txtNamespace);
            this.gpbNamespace.Location = new System.Drawing.Point(333, 306);
            this.gpbNamespace.Name = "gpbNamespace";
            this.gpbNamespace.Size = new System.Drawing.Size(347, 50);
            this.gpbNamespace.TabIndex = 6;
            this.gpbNamespace.TabStop = false;
            this.gpbNamespace.Text = "Namespace";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(6, 19);
            this.txtNamespace.MaxLength = 50;
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(335, 20);
            this.txtNamespace.TabIndex = 0;
            // 
            // gpbTrocaEmpresa
            // 
            this.gpbTrocaEmpresa.Controls.Add(this.ckbTrocaEmpresa);
            this.gpbTrocaEmpresa.Location = new System.Drawing.Point(448, 418);
            this.gpbTrocaEmpresa.Name = "gpbTrocaEmpresa";
            this.gpbTrocaEmpresa.Size = new System.Drawing.Size(97, 50);
            this.gpbTrocaEmpresa.TabIndex = 7;
            this.gpbTrocaEmpresa.TabStop = false;
            this.gpbTrocaEmpresa.Text = "Trocar Empresa";
            // 
            // ckbTrocaEmpresa
            // 
            this.ckbTrocaEmpresa.AutoSize = true;
            this.ckbTrocaEmpresa.Location = new System.Drawing.Point(43, 19);
            this.ckbTrocaEmpresa.Name = "ckbTrocaEmpresa";
            this.ckbTrocaEmpresa.Size = new System.Drawing.Size(15, 14);
            this.ckbTrocaEmpresa.TabIndex = 0;
            this.ckbTrocaEmpresa.UseVisualStyleBackColor = true;
            // 
            // gpbMultiTelas
            // 
            this.gpbMultiTelas.Controls.Add(this.ckbMultiTelas);
            this.gpbMultiTelas.Location = new System.Drawing.Point(586, 418);
            this.gpbMultiTelas.Name = "gpbMultiTelas";
            this.gpbMultiTelas.Size = new System.Drawing.Size(94, 50);
            this.gpbMultiTelas.TabIndex = 8;
            this.gpbMultiTelas.TabStop = false;
            this.gpbMultiTelas.Text = "Multiplas Telas";
            // 
            // ckbMultiTelas
            // 
            this.ckbMultiTelas.AutoSize = true;
            this.ckbMultiTelas.Location = new System.Drawing.Point(38, 19);
            this.ckbMultiTelas.Name = "ckbMultiTelas";
            this.ckbMultiTelas.Size = new System.Drawing.Size(15, 14);
            this.ckbMultiTelas.TabIndex = 1;
            this.ckbMultiTelas.UseVisualStyleBackColor = true;
            // 
            // gpbOpcCos
            // 
            this.gpbOpcCos.Controls.Add(this.txtOpcaoCOS);
            this.gpbOpcCos.Location = new System.Drawing.Point(333, 362);
            this.gpbOpcCos.Name = "gpbOpcCos";
            this.gpbOpcCos.Size = new System.Drawing.Size(347, 50);
            this.gpbOpcCos.TabIndex = 9;
            this.gpbOpcCos.TabStop = false;
            this.gpbOpcCos.Text = "Opção do Menu COS";
            // 
            // txtOpcaoCOS
            // 
            this.txtOpcaoCOS.Location = new System.Drawing.Point(6, 19);
            this.txtOpcaoCOS.MaxLength = 50;
            this.txtOpcaoCOS.Name = "txtOpcaoCOS";
            this.txtOpcaoCOS.Size = new System.Drawing.Size(335, 20);
            this.txtOpcaoCOS.TabIndex = 0;
            // 
            // gpbAtivo
            // 
            this.gpbAtivo.Controls.Add(this.ckbAtivo);
            this.gpbAtivo.Location = new System.Drawing.Point(333, 418);
            this.gpbAtivo.Name = "gpbAtivo";
            this.gpbAtivo.Size = new System.Drawing.Size(58, 50);
            this.gpbAtivo.TabIndex = 10;
            this.gpbAtivo.TabStop = false;
            this.gpbAtivo.Text = "Ativo";
            // 
            // ckbAtivo
            // 
            this.ckbAtivo.AutoSize = true;
            this.ckbAtivo.Location = new System.Drawing.Point(20, 19);
            this.ckbAtivo.Name = "ckbAtivo";
            this.ckbAtivo.Size = new System.Drawing.Size(15, 14);
            this.ckbAtivo.TabIndex = 0;
            this.ckbAtivo.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.gpbAtivo);
            this.Controls.Add(this.gpbOpcCos);
            this.Controls.Add(this.gpbMultiTelas);
            this.Controls.Add(this.gpbTrocaEmpresa);
            this.Controls.Add(this.gpbNamespace);
            this.Controls.Add(this.gpbDescricao);
            this.Controls.Add(this.gpbPrograma);
            this.Controls.Add(this.gpbTipo);
            this.Controls.Add(this.gpbNome);
            this.Controls.Add(this.trvMenu);
            this.Excluir = true;
            this.ExibirBotoes = true;
            this.Name = "Menu";
            this.Salvar = true;
            this.ShowCustom = false;
            this.Size = new System.Drawing.Size(699, 666);
            this.AfterLoad += new System.EventHandler(this.Menu_AfterLoad);
            this.SalvarClick += new System.EventHandler(this.Menu_SalvarClick);
            this.NovoClick += new System.EventHandler(this.Menu_NovoClick);
            this.Controls.SetChildIndex(this.trvMenu, 0);
            this.Controls.SetChildIndex(this.gpbNome, 0);
            this.Controls.SetChildIndex(this.gpbTipo, 0);
            this.Controls.SetChildIndex(this.gpbPrograma, 0);
            this.Controls.SetChildIndex(this.gpbDescricao, 0);
            this.Controls.SetChildIndex(this.gpbNamespace, 0);
            this.Controls.SetChildIndex(this.gpbTrocaEmpresa, 0);
            this.Controls.SetChildIndex(this.gpbMultiTelas, 0);
            this.Controls.SetChildIndex(this.gpbOpcCos, 0);
            this.Controls.SetChildIndex(this.gpbAtivo, 0);
            this.gpbNome.ResumeLayout(false);
            this.gpbNome.PerformLayout();
            this.gpbTipo.ResumeLayout(false);
            this.gpbTipo.PerformLayout();
            this.gpbPrograma.ResumeLayout(false);
            this.gpbPrograma.PerformLayout();
            this.gpbDescricao.ResumeLayout(false);
            this.gpbDescricao.PerformLayout();
            this.gpbNamespace.ResumeLayout(false);
            this.gpbNamespace.PerformLayout();
            this.gpbTrocaEmpresa.ResumeLayout(false);
            this.gpbTrocaEmpresa.PerformLayout();
            this.gpbMultiTelas.ResumeLayout(false);
            this.gpbMultiTelas.PerformLayout();
            this.gpbOpcCos.ResumeLayout(false);
            this.gpbOpcCos.PerformLayout();
            this.gpbAtivo.ResumeLayout(false);
            this.gpbAtivo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvMenu;
        private System.Windows.Forms.GroupBox gpbNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.GroupBox gpbTipo;
        private System.Windows.Forms.RadioButton rdbCache;
        private System.Windows.Forms.RadioButton rdbCliente;
        private System.Windows.Forms.RadioButton rdbMenu;
        private System.Windows.Forms.GroupBox gpbPrograma;
        private System.Windows.Forms.TextBox txtPrograma;
        private System.Windows.Forms.GroupBox gpbDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.GroupBox gpbNamespace;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.GroupBox gpbTrocaEmpresa;
        private System.Windows.Forms.CheckBox ckbTrocaEmpresa;
        private System.Windows.Forms.GroupBox gpbMultiTelas;
        private System.Windows.Forms.CheckBox ckbMultiTelas;
        private System.Windows.Forms.GroupBox gpbOpcCos;
        private System.Windows.Forms.TextBox txtOpcaoCOS;
        private System.Windows.Forms.GroupBox gpbAtivo;
        private System.Windows.Forms.CheckBox ckbAtivo;
        private System.Windows.Forms.ImageList imlMenu;
    }
}
