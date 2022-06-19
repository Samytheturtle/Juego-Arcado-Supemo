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
        private Palabra[] palabras;
        private int idJugador;
        public NuevaPartida()
        {
            InitializeComponent();
        }
        public NuevaPartida(int idJugador)
        {
            InitializeComponent();
            ValoresComboBox();
            this.idJugador = idJugador;
        }

        public void RecuperarCategoria()
        {
            int idCategoria = 0;
            string categoria = cbCategoria.Text;
            if (categoria == "Ciencias Naturales")
            {

                idCategoria = 1;
            }
            if (categoria == "Videojuegos")
            {
                idCategoria = 2;
            }
            if (categoria == "Historia")
            {
                idCategoria = 3;
            }
            if (categoria == "Tecnologías")
            {

                idCategoria = 4;
            }
            if (categoria == "Geología")
            {
                idCategoria = 5;
            }
            if (categoria == "Cultura General")
            {
                idCategoria = 6;
            }
            if (categoria == "Anime")
            {
                idCategoria = 7;
            }
            MostrarPalabras(idCategoria);
        }

        public void ValoresComboBox()
        {
            cbCategoria.Items.Add("Ciencias Naturales");
            cbCategoria.Items.Add("Videojuegos");
            cbCategoria.Items.Add("Historia");
            cbCategoria.Items.Add("Tecnologías");
            cbCategoria.Items.Add("Geología");
            cbCategoria.Items.Add("Cultura General");
            cbCategoria.Items.Add("Anime");
        }

        public void MostrarPalabras(int idCategoria)
        {

            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            palabras = serviceAhorcadoClient.RecuperarPalabraCategoriaAsync(idCategoria).Result;
            DataTable table = new DataTable();
            table.Columns.Add("Palabra", typeof(string));
            table.Columns.Add("Descripcion", typeof(string));
            table.Columns.Add("Dificultad", typeof(string));
            table.Columns.Add("IdPalabra", typeof(string));
            for (int i = 0; i < palabras.Length; i++)
            {
                table.Rows.Add(palabras[i].palabra, palabras[i].descripcion, palabras[i].dificultad, palabras[i].IdPalabra);
            }
            dgPalabras.ItemsSource = table.DefaultView;
            dgPalabras.Columns[0].Width = 100;
        }

        private void CrearPartida(object sender, RoutedEventArgs e)
        {
            if (dgPalabras.SelectedItem == null)
            {
                MessageBox.Show("Seleccione Una fila ", "Error");
            }
            else
            {
                string palabra = RecuperarIdPalabra();
                ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
                DateTime fecha = DateTime.Now;
                string fechaPartida = fecha.ToString("yyyy-MM-dd");
                if ("Partida Creada" == serviceAhorcadoClient.RegistrarPartidaAsync(fechaPartida, idJugador, int.Parse(palabra)).Result)
                {
                    MessageBox.Show("Partida Creada", "Gane :D");
                    Partida nuevaPartida = serviceAhorcadoClient.RecuperarPartidaAsync(fechaPartida, idJugador, int.Parse(palabra)).Result;
                    AhorcadoRetador ahorcadoRetador = new AhorcadoRetador(idJugador, nuevaPartida);
                    this.Close();
                    ahorcadoRetador.Show();
                }
                else
                {
                    MessageBox.Show("La partida no ha podido ser creada", "Error");

                }

            }
        }

        private void ActualizarPalabras(object sender, RoutedEventArgs e)
        {
            RecuperarCategoria();
        }
        private string RecuperarIdPalabra()
        {
            DataRowView row = (DataRowView)dgPalabras.SelectedItems[0];
            string palabra = row["IdPalabra"].ToString();
            return palabra;

        }

        private void CancelarNuevaPartida(object sender, RoutedEventArgs e)
        {
            ListaPartidas listaPartidas = new ListaPartidas(idJugador);
            this.Close();
            listaPartidas.Show();
        }
    }
}
