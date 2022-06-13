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

namespace JuegoArcado.VentanasDeAlerta
{
    /// <summary>
    /// Lógica de interacción para AlertaRegistroExitoso.xaml
    /// </summary>
    public partial class AlertaExitoso : Window
    {
        /*Banda les para abrir dependiendo la ventana estos son los cases
         1=listaPartidas
         2=Iniciar Sesion
        
         Dependiendo el caso ya agregan mas case si gustan
        
         VantanaApertura==Abrir la ventana */
        public int ventanaApertura;
        public int idJugador;
        public AlertaExitoso()
        {
            InitializeComponent();
            
        }
        public AlertaExitoso(int idJugador)
        {
            InitializeComponent();
            this.idJugador=idJugador;
            labeltipoExito.Content = idJugador;

        }
        private void BotonClicAceptar(object sender, RoutedEventArgs e)
        {
            switch (ventanaApertura)
            {
                case 1:
                    ListaPartidas ventanaListaPartidas = new ListaPartidas(idJugador);
                    this.Close();
                    ventanaListaPartidas.ShowDialog();
                    
                    break;
                case 2:
                    InicioSesion ventanaIniciarSesion= new InicioSesion();
                    this.Close();
                    ventanaIniciarSesion.ShowDialog();
                    break;

            }
        }
    }
}
