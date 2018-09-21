namespace SCI.View.Idioma
{
    partial class ControleIdioma
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
            this.stbIdioma = new SCI.View.Controles.SearchTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbHabilitado = new System.Windows.Forms.CheckBox();
            this.tbcIdioma = new System.Windows.Forms.TabControl();
            this.tbpCampo = new System.Windows.Forms.TabPage();
            this.tbpMensagem = new System.Windows.Forms.TabPage();
            this.dgvCampo = new System.Windows.Forms.DataGridView();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Texto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMensagem = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tbcIdioma.SuspendLayout();
            this.tbpCampo.SuspendLayout();
            this.tbpMensagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensagem)).BeginInit();
            this.SuspendLayout();
            // 
            // stbIdioma
            // 
            this.stbIdioma.ComboBoxValue = "";
            this.stbIdioma.DisplayMember = "Display";
            this.stbIdioma.Label = "Idioma";
            this.stbIdioma.Location = new System.Drawing.Point(5, 37);
            this.stbIdioma.Metodo = "ListarIdiomas";
            this.stbIdioma.Name = "stbIdioma";
            this.stbIdioma.OrigemWebService = true;
            this.stbIdioma.PropriedadeLista = "RetornoListarIdioma";
            this.stbIdioma.ReadOnly = false;
            this.stbIdioma.Resultado = "SCI.Idioma.ResultadoListarIdioma";
            this.stbIdioma.Size = new System.Drawing.Size(356, 50);
            this.stbIdioma.TabIndex = 1;
            this.stbIdioma.TipoItem = "SCI.Model.Linguagem.Idioma";
            this.stbIdioma.WebService = "SCI.Idioma.IdiomaService";
            this.stbIdioma.SelectedItemChange += new System.EventHandler(this.stbIdioma_SelectedItemChange);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbHabilitado);
            this.groupBox1.Location = new System.Drawing.Point(367, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(46, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ativo";
            // 
            // ckbHabilitado
            // 
            this.ckbHabilitado.AutoSize = true;
            this.ckbHabilitado.Location = new System.Drawing.Point(17, 19);
            this.ckbHabilitado.Name = "ckbHabilitado";
            this.ckbHabilitado.Size = new System.Drawing.Size(15, 14);
            this.ckbHabilitado.TabIndex = 0;
            this.ckbHabilitado.UseVisualStyleBackColor = true;
            // 
            // tbcIdioma
            // 
            this.tbcIdioma.Controls.Add(this.tbpCampo);
            this.tbcIdioma.Controls.Add(this.tbpMensagem);
            this.tbcIdioma.Location = new System.Drawing.Point(5, 93);
            this.tbcIdioma.Name = "tbcIdioma";
            this.tbcIdioma.SelectedIndex = 0;
            this.tbcIdioma.Size = new System.Drawing.Size(556, 313);
            this.tbcIdioma.TabIndex = 3;
            // 
            // tbpCampo
            // 
            this.tbpCampo.Controls.Add(this.dgvCampo);
            this.tbpCampo.Location = new System.Drawing.Point(4, 22);
            this.tbpCampo.Name = "tbpCampo";
            this.tbpCampo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCampo.Size = new System.Drawing.Size(548, 287);
            this.tbpCampo.TabIndex = 0;
            this.tbpCampo.Text = "Campos";
            this.tbpCampo.UseVisualStyleBackColor = true;
            // 
            // tbpMensagem
            // 
            this.tbpMensagem.Controls.Add(this.dgvMensagem);
            this.tbpMensagem.Location = new System.Drawing.Point(4, 22);
            this.tbpMensagem.Name = "tbpMensagem";
            this.tbpMensagem.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMensagem.Size = new System.Drawing.Size(548, 287);
            this.tbpMensagem.TabIndex = 1;
            this.tbpMensagem.Text = "Mensagens";
            this.tbpMensagem.UseVisualStyleBackColor = true;
            // 
            // dgvCampo
            // 
            this.dgvCampo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCampo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCampo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Campo,
            this.Texto});
            this.dgvCampo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCampo.Location = new System.Drawing.Point(3, 3);
            this.dgvCampo.Name = "dgvCampo";
            this.dgvCampo.Size = new System.Drawing.Size(542, 281);
            this.dgvCampo.TabIndex = 0;
            // 
            // Campo
            // 
            this.Campo.FillWeight = 60.9137F;
            this.Campo.HeaderText = "Campo";
            this.Campo.Name = "Campo";
            // 
            // Texto
            // 
            this.Texto.FillWeight = 139.0863F;
            this.Texto.HeaderText = "Texto";
            this.Texto.Name = "Texto";
            // 
            // dgvMensagem
            // 
            this.dgvMensagem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMensagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMensagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvMensagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMensagem.Location = new System.Drawing.Point(3, 3);
            this.dgvMensagem.Name = "dgvMensagem";
            this.dgvMensagem.Size = new System.Drawing.Size(542, 281);
            this.dgvMensagem.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 60.9137F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Mensagem";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 139.0863F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Texto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // ControleIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.tbcIdioma);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.stbIdioma);
            this.Excluir = true;
            this.Name = "ControleIdioma";
            this.Salvar = true;
            this.Controls.SetChildIndex(this.stbIdioma, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tbcIdioma, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbcIdioma.ResumeLayout(false);
            this.tbpCampo.ResumeLayout(false);
            this.tbpMensagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.SearchTextBox stbIdioma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckbHabilitado;
        private System.Windows.Forms.TabControl tbcIdioma;
        private System.Windows.Forms.TabPage tbpCampo;
        private System.Windows.Forms.TabPage tbpMensagem;
        private System.Windows.Forms.DataGridView dgvCampo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Texto;
        private System.Windows.Forms.DataGridView dgvMensagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
