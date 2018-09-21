using System;
using SCI.View.Controles;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using MinimalisticTelnet;
using System.Drawing;

namespace SCI.View.Outros
{
    public partial class Irko : BaseForm
    {
        public Irko()
        {
            InitializeComponent();
        }
        public Irko(Desktop _desktop)
        {
            InitializeComponent();
            Desktop = _desktop;
        }

        private string comando { set; get; } = string.Empty;


        private void Irko_AfterLoad(object sender, EventArgs e)
        {
            telnet.Connect("128.0.0.5", 23);
            telnet.Send("IRKO");
            telnet.Send(new ConsoleKeyInfo('\x13', System.ConsoleKey.Enter, false, false, false));
            telnet.Focus();
        }

        private void Redesenhar()
        {
            //pnlVT100.Refresh();
        }

        public class Posicao
        {
            public int linha { set; get; }
            public int coluna { set; get; }
            public Posicao() { }
            public Posicao(int _linha, int _coluna) { linha = _linha; coluna = _coluna; }
            public Posicao(string _pos) { linha = int.Parse(_pos.Split(';')[0]); coluna = int.Parse(_pos.Split(';')[1]); }
        }

        public class Mensagem
        {
            public Socket _socket { set; get; } = null;

        }

        private enum chartype
        {
            ukg0, ukg1, usg0, usg1, specg0, specg1, altg0, altg1, altspecg0, altspecg1
        }
        public static Posicao Home { get { return new Posicao(1, 1); } }

        private chartype charMode { set; get; } = chartype.usg0;
        private Posicao posicaoAtual { set; get; } = new Posicao(1, 1);

        private void pnlVT100_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!string.IsNullOrEmpty(comando))
            {
                char[] _caracteres = comando.ToCharArray();
                for (int _indice = 0; _indice < _caracteres.Length; _indice++)
                {
                    switch (char.GetNumericValue(_caracteres[_indice]))
                    {
                        // caracter 27 é o escape.
                        case 27:
                            funcaoVT100(_caracteres, ref _indice);
                            continue;
                        default:
                            e.Graphics.DrawString(Convert.ToString(_caracteres[_indice]), this.Font, new SolidBrush(Color.Red), new PointF(posicaoAtual.coluna,posicaoAtual.linha));
                            break;
                    }
                }
            }
        }


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

        private void DefineCharType(char _conjunto,char _tipo)
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


        private void Irko_Resize(object sender, EventArgs e)
        {
            telnet.Width = Width - (telnet.Left * 2);
            telnet.Height = Height - telnet.Top - 3;
        }
    }
}
