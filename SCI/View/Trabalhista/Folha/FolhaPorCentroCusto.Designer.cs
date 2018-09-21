namespace SCI.View.Trabalhista.Folha
{
    partial class FolhaPorCentroCusto
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
            this.cptAtual = new SCI.View.Controles.Competencia();
            this.cptCompetencia = new SCI.View.Controles.Competencia();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDecimoTerceiro = new System.Windows.Forms.RadioButton();
            this.rdbAdiantamento = new System.Windows.Forms.RadioButton();
            this.rdbMensal = new System.Windows.Forms.RadioButton();
            this.stbCentroCusto = new SCI.View.Controles.SearchTextBox();
            this.stbFuncionario = new SCI.View.Controles.SearchTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpbResumido = new System.Windows.Forms.TabPage();
            this.tbpSintico = new System.Windows.Forms.TabPage();
            this.tbpAnalitico = new System.Windows.Forms.TabPage();
            this.rpvAnalitico = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnGerar = new System.Windows.Forms.Button();
            this.RegistroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpAnalitico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegistroBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cptAtual
            // 
            this.cptAtual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cptAtual.AnoMes = "201706";
            this.cptAtual.Descricao = "Junho de 2017";
            this.cptAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cptAtual.IsValid = true;
            this.cptAtual.Label = "Competência Atual";
            this.cptAtual.Location = new System.Drawing.Point(674, 37);
            this.cptAtual.Name = "cptAtual";
            this.cptAtual.ReadOnly = true;
            this.cptAtual.Size = new System.Drawing.Size(245, 50);
            this.cptAtual.TabIndex = 1;
            this.cptAtual.Valor = "06/2017";
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
            this.cptCompetencia.TabIndex = 2;
            this.cptCompetencia.Valor = "06/2017";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDecimoTerceiro);
            this.groupBox1.Controls.Add(this.rdbAdiantamento);
            this.groupBox1.Controls.Add(this.rdbMensal);
            this.groupBox1.Location = new System.Drawing.Point(221, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Pagamento";
            // 
            // rdbDecimoTerceiro
            // 
            this.rdbDecimoTerceiro.AutoSize = true;
            this.rdbDecimoTerceiro.Location = new System.Drawing.Point(252, 20);
            this.rdbDecimoTerceiro.Name = "rdbDecimoTerceiro";
            this.rdbDecimoTerceiro.Size = new System.Drawing.Size(103, 17);
            this.rdbDecimoTerceiro.TabIndex = 2;
            this.rdbDecimoTerceiro.Text = "Décimo Terceiro";
            this.rdbDecimoTerceiro.UseVisualStyleBackColor = true;
            // 
            // rdbAdiantamento
            // 
            this.rdbAdiantamento.AutoSize = true;
            this.rdbAdiantamento.Location = new System.Drawing.Point(130, 20);
            this.rdbAdiantamento.Name = "rdbAdiantamento";
            this.rdbAdiantamento.Size = new System.Drawing.Size(90, 17);
            this.rdbAdiantamento.TabIndex = 1;
            this.rdbAdiantamento.Text = "Adiantamento";
            this.rdbAdiantamento.UseVisualStyleBackColor = true;
            // 
            // rdbMensal
            // 
            this.rdbMensal.AutoSize = true;
            this.rdbMensal.Checked = true;
            this.rdbMensal.Location = new System.Drawing.Point(7, 20);
            this.rdbMensal.Name = "rdbMensal";
            this.rdbMensal.Size = new System.Drawing.Size(59, 17);
            this.rdbMensal.TabIndex = 0;
            this.rdbMensal.TabStop = true;
            this.rdbMensal.Text = "Mensal";
            this.rdbMensal.UseVisualStyleBackColor = true;
            // 
            // stbCentroCusto
            // 
            this.stbCentroCusto.ComboBoxValue = "";
            this.stbCentroCusto.DisplayMember = "Display";
            this.stbCentroCusto.Label = "Centro de Custo";
            this.stbCentroCusto.Location = new System.Drawing.Point(5, 93);
            this.stbCentroCusto.Metodo = null;
            this.stbCentroCusto.Name = "stbCentroCusto";
            this.stbCentroCusto.OrigemWebService = false;
            this.stbCentroCusto.PropriedadeLista = null;
            this.stbCentroCusto.ReadOnly = false;
            this.stbCentroCusto.Resultado = null;
            this.stbCentroCusto.Size = new System.Drawing.Size(356, 50);
            this.stbCentroCusto.TabIndex = 4;
            this.stbCentroCusto.TipoItem = null;
            this.stbCentroCusto.WebService = null;
            // 
            // stbFuncionario
            // 
            this.stbFuncionario.ComboBoxValue = "";
            this.stbFuncionario.DisplayMember = "Display";
            this.stbFuncionario.Label = "Funcionário";
            this.stbFuncionario.Location = new System.Drawing.Point(367, 93);
            this.stbFuncionario.Metodo = null;
            this.stbFuncionario.Name = "stbFuncionario";
            this.stbFuncionario.OrigemWebService = false;
            this.stbFuncionario.PropriedadeLista = null;
            this.stbFuncionario.ReadOnly = false;
            this.stbFuncionario.Resultado = null;
            this.stbFuncionario.Size = new System.Drawing.Size(356, 50);
            this.stbFuncionario.TabIndex = 5;
            this.stbFuncionario.TipoItem = null;
            this.stbFuncionario.WebService = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpbResumido);
            this.tabControl1.Controls.Add(this.tbpSintico);
            this.tabControl1.Controls.Add(this.tbpAnalitico);
            this.tabControl1.Location = new System.Drawing.Point(5, 149);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(914, 447);
            this.tabControl1.TabIndex = 6;
            // 
            // tpbResumido
            // 
            this.tpbResumido.Location = new System.Drawing.Point(4, 22);
            this.tpbResumido.Name = "tpbResumido";
            this.tpbResumido.Padding = new System.Windows.Forms.Padding(3);
            this.tpbResumido.Size = new System.Drawing.Size(906, 421);
            this.tpbResumido.TabIndex = 0;
            this.tpbResumido.Text = "Resumido";
            this.tpbResumido.UseVisualStyleBackColor = true;
            // 
            // tbpSintico
            // 
            this.tbpSintico.Location = new System.Drawing.Point(4, 22);
            this.tbpSintico.Name = "tbpSintico";
            this.tbpSintico.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSintico.Size = new System.Drawing.Size(906, 421);
            this.tbpSintico.TabIndex = 1;
            this.tbpSintico.Text = "Sintético";
            this.tbpSintico.UseVisualStyleBackColor = true;
            // 
            // tbpAnalitico
            // 
            this.tbpAnalitico.Controls.Add(this.rpvAnalitico);
            this.tbpAnalitico.Location = new System.Drawing.Point(4, 22);
            this.tbpAnalitico.Name = "tbpAnalitico";
            this.tbpAnalitico.Size = new System.Drawing.Size(906, 421);
            this.tbpAnalitico.TabIndex = 2;
            this.tbpAnalitico.Text = "Analítico";
            this.tbpAnalitico.UseVisualStyleBackColor = true;
            // 
            // rpvAnalitico
            // 
            this.rpvAnalitico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvAnalitico.LocalReport.ReportEmbeddedResource = "SCI.View.Report.Trabalhista.Folha.FolhaPorCentroCusto.rdlc";
            this.rpvAnalitico.Location = new System.Drawing.Point(0, 0);
            this.rpvAnalitico.Name = "rpvAnalitico";
            this.rpvAnalitico.ServerReport.BearerToken = null;
            this.rpvAnalitico.Size = new System.Drawing.Size(906, 421);
            this.rpvAnalitico.TabIndex = 0;
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(729, 109);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 7;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.BtnGerar_Click);
            // 
            // RegistroBindingSource
            // 
            this.RegistroBindingSource.DataSource = typeof(SCI.Model.Trabalhista.Registro);
            // 
            // FolhaPorCentroCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Cancelar = true;
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.stbFuncionario);
            this.Controls.Add(this.stbCentroCusto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cptCompetencia);
            this.Controls.Add(this.cptAtual);
            this.Excluir = true;
            this.ExibirBotoes = false;
            this.Name = "FolhaPorCentroCusto";
            this.Salvar = true;
            this.ShowCustom = false;
            this.Size = new System.Drawing.Size(924, 599);
            this.Controls.SetChildIndex(this.cptAtual, 0);
            this.Controls.SetChildIndex(this.cptCompetencia, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.stbCentroCusto, 0);
            this.Controls.SetChildIndex(this.stbFuncionario, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnGerar, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbpAnalitico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RegistroBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.Competencia cptAtual;
        private Controles.Competencia cptCompetencia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDecimoTerceiro;
        private System.Windows.Forms.RadioButton rdbAdiantamento;
        private System.Windows.Forms.RadioButton rdbMensal;
        private Controles.SearchTextBox stbCentroCusto;
        private Controles.SearchTextBox stbFuncionario;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpbResumido;
        private System.Windows.Forms.TabPage tbpSintico;
        private System.Windows.Forms.TabPage tbpAnalitico;
        private System.Windows.Forms.Button btnGerar;
        private Microsoft.Reporting.WinForms.ReportViewer rpvAnalitico;
        private System.Windows.Forms.BindingSource RegistroBindingSource;
    }
}
