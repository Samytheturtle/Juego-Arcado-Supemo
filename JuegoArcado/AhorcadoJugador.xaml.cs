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
        public String nombreRetador = "";
        public String descripcionPalabra = "";
        public String progresoPalabra = "A H O R C A D O U W U";

        public AhorcadoJugador()
        {
            InitializeComponent();
            lbNombreRetador.Content = nombreRetador;
            lbDescripcionPalabra.Content = descripcionPalabra;
            lbProgresoPalabra.Content = progresoPalabra;

        }

        private void ClickBtnA(object sender, RoutedEventArgs e) { BtnA.Visibility = Visibility.Hidden; /*DeshabilitarHabilitarBotonesLetras(false);*/ EnviarLetra('A'); }
        private void ClickBtnB(object sender, RoutedEventArgs e) { BtnB.Visibility = Visibility.Hidden; EnviarLetra('B'); }
        private void ClickBtnC(object sender, RoutedEventArgs e) { BtnC.Visibility = Visibility.Hidden; EnviarLetra('C'); }
        private void ClickBtnD(object sender, RoutedEventArgs e) { BtnD.Visibility = Visibility.Hidden; EnviarLetra('D'); }
        private void ClickBtnE(object sender, RoutedEventArgs e) { BtnE.Visibility = Visibility.Hidden; EnviarLetra('E'); }
        private void ClickBtnF(object sender, RoutedEventArgs e) { BtnF.Visibility = Visibility.Hidden; EnviarLetra('F'); }
        private void ClickBtnG(object sender, RoutedEventArgs e) { BtnG.Visibility = Visibility.Hidden; EnviarLetra('G'); }
        private void ClickBtnH(object sender, RoutedEventArgs e) { BtnH.Visibility = Visibility.Hidden; EnviarLetra('H'); }
        private void ClickBtnI(object sender, RoutedEventArgs e) { BtnI.Visibility = Visibility.Hidden; EnviarLetra('I'); }
        private void ClickBtnJ(object sender, RoutedEventArgs e) { BtnJ.Visibility = Visibility.Hidden; EnviarLetra('J'); }
        private void ClickBtnK(object sender, RoutedEventArgs e) { BtnK.Visibility = Visibility.Hidden; EnviarLetra('K'); }
        private void ClickBtnL(object sender, RoutedEventArgs e) { BtnL.Visibility = Visibility.Hidden; EnviarLetra('L'); }
        private void ClickBtnM(object sender, RoutedEventArgs e) { BtnM.Visibility = Visibility.Hidden; EnviarLetra('M'); }
        private void ClickBtnN(object sender, RoutedEventArgs e) { BtnN.Visibility = Visibility.Hidden; EnviarLetra('N'); }
        private void ClickBtnÑ(object sender, RoutedEventArgs e) { BtnÑ.Visibility = Visibility.Hidden; EnviarLetra('Ñ'); }
        private void ClickBtnO(object sender, RoutedEventArgs e) { BtnO.Visibility = Visibility.Hidden; EnviarLetra('O'); }
        private void ClickBtnP(object sender, RoutedEventArgs e) { BtnP.Visibility = Visibility.Hidden; EnviarLetra('P'); }
        private void ClickBtnQ(object sender, RoutedEventArgs e) { BtnQ.Visibility = Visibility.Hidden; EnviarLetra('Q'); }
        private void ClickBtnR(object sender, RoutedEventArgs e) { BtnR.Visibility = Visibility.Hidden; EnviarLetra('R'); }
        private void ClickBtnS(object sender, RoutedEventArgs e) { BtnS.Visibility = Visibility.Hidden; EnviarLetra('S'); }
        private void ClickBtnT(object sender, RoutedEventArgs e) { BtnT.Visibility = Visibility.Hidden; EnviarLetra('T'); }
        private void ClickBtnU(object sender, RoutedEventArgs e) { BtnU.Visibility = Visibility.Hidden; EnviarLetra('U'); }
        private void ClickBtnV(object sender, RoutedEventArgs e) { BtnV.Visibility = Visibility.Hidden; EnviarLetra('V'); }
        private void ClickBtnW(object sender, RoutedEventArgs e) { BtnW.Visibility = Visibility.Hidden; EnviarLetra('W'); }
        private void ClickBtnX(object sender, RoutedEventArgs e) { BtnX.Visibility = Visibility.Hidden; EnviarLetra('X'); }
        private void ClickBtnY(object sender, RoutedEventArgs e) { BtnY.Visibility = Visibility.Hidden; EnviarLetra('Y'); }
        private void ClickBtnZ(object sender, RoutedEventArgs e) { BtnZ.Visibility = Visibility.Hidden; EnviarLetra('Z'); }

        private void EnviarLetra(char letra)
        {
            int conexion = 1;
            if (conexion == 1)
            {
                HabilitarBotonesLetras(false);
                //MetodoQueMandaLaLetraAlRetador();
                ColocarInstruccion("Esperando al Retador");

            }
            else
            {
                HabilitarBotonesLetras(false);
                ColocarInstruccion("No hay conexión con el servidor");
            }
        }

        public void ActualizarProgreso(int numSprite, String progreso)
        {
            ColocarExtremidadAhorcado(numSprite);
            lbProgresoPalabra.Content = progreso;
            HabilitarBotonesLetras(true);
            ColocarInstruccion("Selecciona una letra");
        }

        private void ColocarExtremidadAhorcado(int numSprite)
        {
            BitmapImage sprite = new BitmapImage();
            sprite.BeginInit();
            sprite.UriSource = new Uri("/AhorcadoSprite" + numSprite + ".png", UriKind.Relative);
            sprite.EndInit();
            SpriteAhorcado.Source = sprite;
        }


        private void BtnRendirse(object sender, RoutedEventArgs e)
        {
            //Simulación de entrada de datos (Cuando el Retador confirma)
            ActualizarProgreso(2, "P R U E B A");
            //this.Close();
        }

        private void HabilitarBotonesLetras(Boolean accion)
        {
            BtnA.IsEnabled = accion;
            BtnB.IsEnabled = accion;
            BtnC.IsEnabled = accion;
            BtnD.IsEnabled = accion;
            BtnE.IsEnabled = accion;
            BtnF.IsEnabled = accion;
            BtnG.IsEnabled = accion;
            BtnH.IsEnabled = accion;
            BtnI.IsEnabled = accion;
            BtnJ.IsEnabled = accion;
            BtnK.IsEnabled = accion;
            BtnL.IsEnabled = accion;
            BtnM.IsEnabled = accion;
            BtnN.IsEnabled = accion;
            BtnÑ.IsEnabled = accion;
            BtnO.IsEnabled = accion;
            BtnP.IsEnabled = accion;
            BtnQ.IsEnabled = accion;
            BtnR.IsEnabled = accion;
            BtnS.IsEnabled = accion;
            BtnT.IsEnabled = accion;
            BtnU.IsEnabled = accion;
            BtnV.IsEnabled = accion;
            BtnW.IsEnabled = accion;
            BtnX.IsEnabled = accion;
            BtnY.IsEnabled = accion;
            BtnZ.IsEnabled = accion;
        }

        private void ColocarInstruccion(String instruccion)
        {
            lbInstruccionJugador.Content = instruccion;
        }


    }
}
