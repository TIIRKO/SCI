using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCI.View.Controles;

namespace SCI.View.Outros
{
    public partial class Portal : BaseForm
    {
        public Portal()
        {
            InitializeComponent();
        }

        public Portal(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void Portal_Resize(object sender, EventArgs e)
        {
            AlinharCampos();
        }

        private void Portal_AfterLoad(object sender, EventArgs e)
        {
            AlinharCampos();
            wbsPortal.Navigate("https://www.irko.com.br/csp/admsys/portal/test/home2.csp?GUID=" + Guid);
        }

        private void AlinharCampos()
        {
            //wbsPortal.Height = Height - wbsPortal.Top;
            //wbsPortal.Width = Width - 10;
        }

    }
}
