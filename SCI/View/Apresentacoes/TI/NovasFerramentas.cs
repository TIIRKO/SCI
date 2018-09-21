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

namespace SCI.View.Apresentacoes.TI
{
    public partial class NovasFerramentas : BaseForm
    {
        public NovasFerramentas()
        {
            InitializeComponent();
        }
        public NovasFerramentas(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }
    }
}
