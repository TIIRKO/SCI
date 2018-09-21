namespace SCI.View.DCTF.Lancamento
{
    partial class ProcessamentoLote
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
            this.cptCompetencia = new SCI.View.Controles.Competencia();
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.btnArquivo = new System.Windows.Forms.Button();
            this.lblArquivo = new System.Windows.Forms.Label();
            this.dgvArquivo = new System.Windows.Forms.DataGridView();
            this.gpbArquivo = new System.Windows.Forms.GroupBox();
            this.chkCabecalho = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbDivisor = new System.Windows.Forms.ComboBox();
            this.btnImportar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nmcPularLinha = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArquivo)).BeginInit();
            this.gpbArquivo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmcPularLinha)).BeginInit();
            this.SuspendLayout();
            // 
            // cptCompetencia
            // 
            this.cptCompetencia.AnoMes = "201706";
            this.cptCompetencia.Descricao = "Junho de 2017";
            this.cptCompetencia.IsValid = true;
            this.cptCompetencia.Label = "Competência";
            this.cptCompetencia.Location = new System.Drawing.Point(5, 37);
            this.cptCompetencia.Name = "cptCompetencia";
            this.cptCompetencia.ReadOnly = false;
            this.cptCompetencia.Size = new System.Drawing.Size(210, 50);
            this.cptCompetencia.TabIndex = 1;
            this.cptCompetencia.Valor = "06/2017";
            // 
            // ofdArquivo
            // 
            this.ofdArquivo.Filter = "Texto|*.txt|Excel|*.xls;*.xlsx";
            this.ofdArquivo.InitialDirectory = "@\"C:\\\"";
            this.ofdArquivo.Title = "Selecione o arquivo...";
            // 
            // btnArquivo
            // 
            this.btnArquivo.Location = new System.Drawing.Point(567, 54);
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.Size = new System.Drawing.Size(75, 23);
            this.btnArquivo.TabIndex = 2;
            this.btnArquivo.Text = "Arquivo";
            this.btnArquivo.UseVisualStyleBackColor = true;
            this.btnArquivo.Click += new System.EventHandler(this.btnArquivo_Click);
            // 
            // lblArquivo
            // 
            this.lblArquivo.Location = new System.Drawing.Point(240, 54);
            this.lblArquivo.Name = "lblArquivo";
            this.lblArquivo.Size = new System.Drawing.Size(321, 23);
            this.lblArquivo.TabIndex = 3;
            // 
            // dgvArquivo
            // 
            this.dgvArquivo.AllowUserToResizeRows = false;
            this.dgvArquivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArquivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArquivo.Location = new System.Drawing.Point(3, 16);
            this.dgvArquivo.Name = "dgvArquivo";
            this.dgvArquivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.dgvArquivo.Size = new System.Drawing.Size(631, 315);
            this.dgvArquivo.TabIndex = 4;
            this.dgvArquivo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArquivo_ColumnHeaderMouseClick);
            this.dgvArquivo.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArquivo_RowHeaderMouseClick);
            this.dgvArquivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvArquivo_KeyDown);
            // 
            // gpbArquivo
            // 
            this.gpbArquivo.Controls.Add(this.dgvArquivo);
            this.gpbArquivo.Location = new System.Drawing.Point(5, 153);
            this.gpbArquivo.Name = "gpbArquivo";
            this.gpbArquivo.Size = new System.Drawing.Size(637, 334);
            this.gpbArquivo.TabIndex = 5;
            this.gpbArquivo.TabStop = false;
            this.gpbArquivo.Text = "Arquivo";
            // 
            // chkCabecalho
            // 
            this.chkCabecalho.AutoSize = true;
            this.chkCabecalho.Checked = true;
            this.chkCabecalho.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCabecalho.Location = new System.Drawing.Point(13, 19);
            this.chkCabecalho.Name = "chkCabecalho";
            this.chkCabecalho.Size = new System.Drawing.Size(15, 14);
            this.chkCabecalho.TabIndex = 6;
            this.chkCabecalho.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCabecalho);
            this.groupBox1.Location = new System.Drawing.Point(5, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 50);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tratar a primeira linha como Cabeçalho";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbDivisor);
            this.groupBox2.Location = new System.Drawing.Point(309, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(89, 50);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Divisor";
            // 
            // cbbDivisor
            // 
            this.cbbDivisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDivisor.FormattingEnabled = true;
            this.cbbDivisor.Items.AddRange(new object[] {
            "TAB",
            ";",
            ",",
            "^",
            "|",
            "$",
            "%"});
            this.cbbDivisor.Location = new System.Drawing.Point(6, 16);
            this.cbbDivisor.Name = "cbbDivisor";
            this.cbbDivisor.Size = new System.Drawing.Size(69, 21);
            this.cbbDivisor.TabIndex = 0;
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(405, 111);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 9;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nmcPularLinha);
            this.groupBox3.Location = new System.Drawing.Point(221, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(82, 50);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pular Linhas";
            // 
            // nmcPularLinha
            // 
            this.nmcPularLinha.Location = new System.Drawing.Point(6, 19);
            this.nmcPularLinha.Name = "nmcPularLinha";
            this.nmcPularLinha.Size = new System.Drawing.Size(52, 20);
            this.nmcPularLinha.TabIndex = 0;
            // 
            // ProcessamentoLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpbArquivo);
            this.Controls.Add(this.lblArquivo);
            this.Controls.Add(this.btnArquivo);
            this.Controls.Add(this.cptCompetencia);
            this.Excluir = true;
            this.ExibirBotoes = true;
            this.Name = "ProcessamentoLote";
            this.Salvar = true;
            this.ShowCustom = false;
            this.Size = new System.Drawing.Size(685, 490);
            this.AfterLoad += new System.EventHandler(this.ProcessamentoLote_AfterLoad);
            this.SalvarClick += new System.EventHandler(this.ProcessamentoLote_SalvarClick);
            this.Controls.SetChildIndex(this.cptCompetencia, 0);
            this.Controls.SetChildIndex(this.btnArquivo, 0);
            this.Controls.SetChildIndex(this.lblArquivo, 0);
            this.Controls.SetChildIndex(this.gpbArquivo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnImportar, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArquivo)).EndInit();
            this.gpbArquivo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmcPularLinha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.Competencia cptCompetencia;
        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.Button btnArquivo;
        private System.Windows.Forms.Label lblArquivo;
        private System.Windows.Forms.DataGridView dgvArquivo;
        private System.Windows.Forms.GroupBox gpbArquivo;
        private System.Windows.Forms.CheckBox chkCabecalho;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbDivisor;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nmcPularLinha;
    }
}
