using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SCI.View.Controles;

namespace SCI.View.Sistema.Manutencao
{
    public partial class Menu : BaseForm
    {
        private Acesso.IRKO.Service wrAcesso = new Acesso.IRKO.Service();

        public Menu()
        {
            InitializeComponent();
        }
        public Menu(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void Menu_SalvarClick(object sender, EventArgs e)
        {
            try
            {
                Acesso.IRKO.Menu _menu = (Acesso.IRKO.Menu)trvMenu.SelectedNode?.Tag;
                string _menuSuperior = null;
                if (_menu != null)
                    _menuSuperior = _menu.Menu1;

                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("Campo Nome é obrigatório.");
                    return;
                }

                Acesso.IRKO.MenuTipo? _tipo = null;
                if (rdbMenu.Checked)
                    _tipo = Acesso.IRKO.MenuTipo.Item0;
                else if (rdbCache.Checked)
                    _tipo = Acesso.IRKO.MenuTipo.Item1;
                else if (rdbCliente.Checked)
                    _tipo = Acesso.IRKO.MenuTipo.Item2;

                if (_tipo == null)
                {
                    MessageBox.Show("Selecione o tipo de opção do menu.");
                    return;
                }
                if (_tipo != Acesso.IRKO.MenuTipo.Item0 && string.IsNullOrEmpty(txtPrograma.Text))
                {
                    MessageBox.Show("Campo Programa é obrigatório.");
                    return;
                }

                Acesso.IRKO.Menu _parametroMenu = new Acesso.IRKO.Menu();
                _parametroMenu.Menu1 = txtNome.Text;
                _parametroMenu.Descricao = txtDescricao.Text;
                _parametroMenu.Tipo = _tipo ?? Acesso.IRKO.MenuTipo.Item0;
                if (ckbAtivo.Checked)
                    _parametroMenu.Status = Acesso.IRKO.MenuStatus.Item1;
                else
                    _parametroMenu.Status = Acesso.IRKO.MenuStatus.Item0;

                _parametroMenu.Namespace = txtNamespace.Text;
                _parametroMenu.Programa = txtPrograma.Text;
                _parametroMenu.PermiteTrocaEmpresa = ckbTrocaEmpresa.Checked;
                _parametroMenu.PermiteMultiTela = ckbMultiTelas.Checked;

                Acesso.IRKO.Resultado _retorno = wrAcesso.GravarMenu(Guid, _parametroMenu, _menuSuperior);

                if (!_retorno.Sucesso)
                {
                    MessageBox.Show(_retorno.Mensagem);
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }

        private void Menu_NovoClick(object sender, EventArgs e)
        {
            gpbPrograma.Visible = true;
            gpbNamespace.Visible = true;
            gpbOpcCos.Visible = true;

            txtNome.Text = "";
            txtDescricao.Text = "";

            rdbMenu.Checked = false;
            rdbCliente.Checked = false;
            rdbCache.Checked = false;

            txtPrograma.Text = "";
            txtNamespace.Text = "";
            txtOpcaoCOS.Text = "";
            ckbAtivo.Checked = false;
            ckbMultiTelas.Checked = false;
            ckbTrocaEmpresa.Checked = false;

        }

        private void Menu_AfterLoad(object sender, EventArgs e)
        {
            PopularTrvMenu();
        }

        private TreeNode MontarMenuNode(Acesso.IRKO.Menu _menu)
        {
            TreeNode node = new TreeNode(_menu.Menu1);
            node.Tag = _menu;
            if (_menu.MenusInferiores != null && _menu.MenusInferiores.Count() > 0)
            {
                TreeNode[] nodes = _menu.MenusInferiores
                    .ToList().ConvertAll<TreeNode>(__menu => MontarMenuNode(__menu))
                    .Where(__menu => __menu != null)
                    .ToArray();
                if (nodes.Count() > 0)
                {
                    node.Nodes.AddRange(nodes);
                }
            }

            if (node.Nodes.Count == 0)
            {
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
            }
            return node;
        }

        private void PopularTrvMenu()
        {
            trvMenu.Nodes.Clear();
            Acesso.IRKO.ResultadoMontarMenu resultadoMontarMenu = wrAcesso.MontarMenu(Guid);
            if (resultadoMontarMenu.Sucesso)
            {
                if (resultadoMontarMenu.RetornoResultadoMontarMenu != null)
                {
                    trvMenu.Nodes.AddRange(resultadoMontarMenu.RetornoResultadoMontarMenu.ToList()
                        .ConvertAll<TreeNode>(_menu => MontarMenuNode(_menu))
                        .Where(_menu => _menu != null)
                        .ToArray());
                }
            }
            else
            {
                MessageBox.Show(resultadoMontarMenu.Mensagem);
            }
        }

        private void trvMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void trvMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Acesso.IRKO.Menu _menu = (Acesso.IRKO.Menu)e.Node.Tag;
            txtNome.Text = _menu.Menu1;
            txtDescricao.Text = _menu.Descricao;
            switch(_menu.Tipo)
            {
                case Acesso.IRKO.MenuTipo.Item0:
                    rdbMenu.Checked = true;
                    gpbPrograma.Visible = false;
                    gpbNamespace.Visible = false;
                    gpbOpcCos.Visible = false;
                    break;
                case Acesso.IRKO.MenuTipo.Item1:
                    rdbCache.Checked = true;
                    gpbPrograma.Visible = true;
                    gpbNamespace.Visible = true;
                    gpbOpcCos.Visible = true;
                    break;
                case Acesso.IRKO.MenuTipo.Item2:
                    rdbCliente.Checked = true;
                    gpbPrograma.Visible = true;
                    gpbNamespace.Visible = false;
                    gpbOpcCos.Visible = true;
                    break;
            }
            txtPrograma.Text = _menu.Programa;
            txtNamespace.Text = _menu.Namespace;
            txtOpcaoCOS.Text = _menu.OpcaoMenuCOS;
            ckbAtivo.Checked = _menu.Status == Acesso.IRKO.MenuStatus.Item1;
            ckbMultiTelas.Checked = _menu.PermiteMultiTela;
            ckbTrocaEmpresa.Checked = _menu.PermiteTrocaEmpresa;
        }

        private void trvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }
    }
}
