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
using MinimalisticTelnet;

namespace SCI.View.Outros
{
    public partial class VisualTelNet : BaseForm
    {

        private string comando { set; get; } = string.Empty;

        public VisualTelNet()
        {
            InitializeComponent();
        }
        public VisualTelNet(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private void VisualTelNet_AfterLoad(object sender, EventArgs e)
        {
            //TelnetConnection tc = new TelnetConnection("128.0.0.5", 23);
            TelnetConnection tc = new TelnetConnection("187.9.214.58", 23);
            
            string a;

            a = tc.Read();

            tc.WriteLine("irko");

            comando = tc.Read();

            Redesenhar();
        }


        public class Posicao
        {
            public int linha { set; get; }
            public int coluna { set; get; }
            public Posicao() { }
            public Posicao(int _linha, int _coluna) { linha = _linha; coluna = _coluna; }
            public Posicao(string _pos) { linha = int.Parse(_pos.Split(';')[0]); coluna = int.Parse(_pos.Split(';')[1]); }
        }
        private enum chartype
        {
            ukg0, ukg1, usg0, usg1, specg0, specg1, altg0, altg1, altspecg0, altspecg1
        }

        private static Posicao Home { get { return new Posicao(1, 1); } }
        private chartype charMode { set; get; } = chartype.usg0;
        private Posicao posicaoAtual { set; get; } = new Posicao(1, 1);
        private string[,] mapa80 = new string[30,80];
        private string[,] mapa160 = new string[30, 80];

        private void funcaoVT100(char[] _caracteres, ref int _indice)
        {
            char _comType = _caracteres[_indice + 1];
            switch (_comType)
            {
                case '(':
                case ')':
                    DefineCharType(_comType, _caracteres[_indice + 2]);
                    _indice = _indice + 2;
                    break;
                case '[':
                    char _com = _caracteres[_indice + 2];
                    switch (_com)
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            _indice = _indice + 2;
                            ComandoVT100Numerico(_caracteres, ref _indice);
                            break;
                        case 'J':
                            ComandoVT100Limpar();
                            break;
                    }
                    break;
            }
        }

        private void ComandoVT100Limpar()
        {
        }

        private void MontarMapa()
        {

        }


        private void ComandoVT100Numerico(char[] _caracteres, ref int _indice)
        {
            string comando = string.Empty;
            for (int _j = _indice; _j <= _caracteres.Length; _j++)
            {
                if (_caracteres[_j] == 'H')
                {
                    _indice = _j + 1;
                    break;
                }
                comando += _caracteres[_j];
            }

            posicaoAtual = new Posicao(comando);
        }

        private void DefineCharType(char _conjunto, char _tipo)
        {
            if (_conjunto == '(')
            {
                switch (_tipo)
                {
                    case 'A':
                        charMode = chartype.ukg0;
                        break;
                    case 'B':
                        charMode = chartype.usg0;
                        break;
                    case '0':
                        charMode = chartype.specg0;
                        break;
                    case '1':
                        charMode = chartype.altg0;
                        break;
                    case '2':
                        charMode = chartype.altspecg0;
                        break;
                }
            }
            else
            {
                switch (_tipo)
                {
                    case 'A':
                        charMode = chartype.ukg1;
                        break;
                    case 'B':
                        charMode = chartype.usg1;
                        break;
                    case '0':
                        charMode = chartype.specg1;
                        break;
                    case '1':
                        charMode = chartype.altg1;
                        break;
                    case '2':
                        charMode = chartype.altspecg1;
                        break;
                }
            }
        }

        private void Redesenhar()
        {
            //pnlVT100.Refresh();
        }

    }
}
