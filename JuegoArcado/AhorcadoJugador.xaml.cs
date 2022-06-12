using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JuegoArcado
{
    /// <summary>
    /// Lógica de interacción para AhorcadoJugador.xaml
    /// </summary>
    public partial class AhorcadoJugador : Window
    {
        public AhorcadoJugador()
        {
            InitializeComponent();
        }

        private void BtnA(object sender, RoutedEventArgs e) { EnviarLetra('A'); }
        private void BtnB(object sender, RoutedEventArgs e) { EnviarLetra('B'); }
        private void BtnC(object sender, RoutedEventArgs e) { EnviarLetra('C'); }
        private void BtnD(object sender, RoutedEventArgs e) { EnviarLetra('D'); }
        private void BtnE(object sender, RoutedEventArgs e) { EnviarLetra('E'); }
        private void BtnF(object sender, RoutedEventArgs e) { EnviarLetra('F'); }
        private void BtnG(object sender, RoutedEventArgs e) { EnviarLetra('G'); }
        private void BtnH(object sender, RoutedEventArgs e) { EnviarLetra('H'); }
        private void BtnI(object sender, RoutedEventArgs e) { EnviarLetra('I'); }
        private void BtnJ(object sender, RoutedEventArgs e) { EnviarLetra('J'); }
        private void BtnK(object sender, RoutedEventArgs e) { EnviarLetra('K'); }
        private void BtnL(object sender, RoutedEventArgs e) { EnviarLetra('L'); }
        private void BtnM(object sender, RoutedEventArgs e) { EnviarLetra('M'); }
        private void BtnN(object sender, RoutedEventArgs e) { EnviarLetra('N'); }
        private void BtnÑ(object sender, RoutedEventArgs e) { EnviarLetra('Ñ'); }
        private void BtnO(object sender, RoutedEventArgs e) { EnviarLetra('O'); }
        private void BtnP(object sender, RoutedEventArgs e) { EnviarLetra('P'); }
        private void BtnQ(object sender, RoutedEventArgs e) { EnviarLetra('Q'); }
        private void BtnR(object sender, RoutedEventArgs e) { EnviarLetra('R'); }
        private void BtnS(object sender, RoutedEventArgs e) { EnviarLetra('S'); }
        private void BtnT(object sender, RoutedEventArgs e) { EnviarLetra('T'); }
        private void BtnU(object sender, RoutedEventArgs e) { EnviarLetra('U'); }
        private void BtnV(object sender, RoutedEventArgs e) { EnviarLetra('V'); }
        private void BtnW(object sender, RoutedEventArgs e) { EnviarLetra('W'); }
        private void BtnX(object sender, RoutedEventArgs e) { EnviarLetra('X'); }
        private void BtnY(object sender, RoutedEventArgs e) { EnviarLetra('Y'); }
        private void BtnZ(object sender, RoutedEventArgs e) { EnviarLetra('Z'); }

        private void EnviarLetra(char letra)
        {
            //MetodoQueMandaLaLetraAlRetador();
        }

        private void BtnRendirse(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
