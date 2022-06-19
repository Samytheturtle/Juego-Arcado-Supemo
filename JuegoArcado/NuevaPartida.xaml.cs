using ServicioAhorcadoSupremo;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para NuevaPartida.xaml
    /// </summary>
    public partial class NuevaPartida : Window
    {
        private int idJugador;
        public NuevaPartida()
        {
            InitializeComponent();
        }
        public NuevaPartida(int idJugador)
        {
            InitializeComponent();
            ValoresComboBox();
        }

        public void RecuperarCategoria()
        {
            int idCategoria = 0;
            string categoria = cbCategoria.Text;
            if(categoria=="Ciencias Naturales")
            {

                idCategoria = 1;
            }
            else
            {
                idCategoria = 2;
            }

            MostrarPalabras(idCategoria);
        }

        public void ValoresComboBox()
        {
            cbCategoria.Items.Add("Ciencias Naturales");
        }

        public void MostrarPalabras(int idCategoria)
        {
            Palabra[] palabras;
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            palabras = serviceAhorcadoClient.RecuperarPalabraCategoriaAsync(idCategoria).Result;
            DataTable table = new DataTable();
            table.Columns.Add("Palabra", typeof(string));
            table.Columns.Add("Descripcion", typeof(string));
            table.Columns.Add("Dificultad", typeof(string));
            for(int i= 0; i < palabras.Length; i++)
            {
                table.Rows.Add(palabras[i].palabra, palabras[i].descripcion, palabras[i].dificultad);
            }
            dgPalabras.ItemsSource = table.DefaultView;
            dgPalabras.Columns[0].Width = 100;
        }

        private void CrearPartida(object sender, RoutedEventArgs e)
        {
            
        }

        private void ActualizarPalabras(object sender, RoutedEventArgs e)
        {
            RecuperarCategoria();
        }
    }
}
