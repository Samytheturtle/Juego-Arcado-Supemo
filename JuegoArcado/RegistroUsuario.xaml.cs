﻿using System;
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
using JuegoArcado.VentanasDeAlerta;
using ServicioAhorcadoSupremo;

namespace JuegoArcado
{
    /// <summary>
    /// Lógica de interacción para RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void cajaInteraccionNombre(object sender, RoutedEventArgs e)
        {
            cajaDTextoNombre.Clear();
        }

        private void cajaInteraccionTelefono(object sender, RoutedEventArgs e)
        {
            cajaDTextoTelfono.Clear();
        }

        private void cajaInteraccionApellidos(object sender, RoutedEventArgs e)
        {
           cajaDTextoApellidos.Clear();
        }

        private void cajaInteraccionCorreo(object sender, RoutedEventArgs e)
        {
            cajaDTextoCorreo.Clear();
        }

        private void cajaInteraccionContrasenia(object sender, RoutedEventArgs e)
        {
            cajaDTextoContrasenia.Clear();
        }

        private void botonClicCancelar(object sender, RoutedEventArgs e)
        {
            InicioSesion ventanaInicioSesion = new InicioSesion();
            this.Close();
            ventanaInicioSesion.ShowDialog();
        }

        private void botonClicRegistrarse(object sender, RoutedEventArgs e)
        {
            if (!validarCamposVacios()&& validarCorreo()>0)
            {
                registrarJugador();
                AlertaExitoso ventanaAlertaExitoso = new AlertaExitoso();
                ventanaAlertaExitoso.ventanaApertura = 2;
                ventanaAlertaExitoso.labeltipoExito.Content = "REGISTRO EXITOSO";
                ventanaAlertaExitoso.LabeltextoAlerta.Content = "Jugador registrado al sistema exitosamente :D";
                this.Close();
                ventanaAlertaExitoso.ShowDialog();
            }
            else if(validarCorreo()==0)
            {
                AlertaFallo alertaFalloRegistro = new AlertaFallo();
                alertaFalloRegistro.ventanaApertura = 1;
                alertaFalloRegistro.labelInforAlerta.Content = "El correo que usted ingreso ya tiene una cuenta registrada";
                alertaFalloRegistro.labelTipoFallo.Content = "ERROR EN REGISTRO";
                alertaFalloRegistro.ShowDialog();
            }
        }
        private Boolean validarCamposVacios()
        {
            Boolean camposVacios = false;
            if (cajaDTextoNombre.Text == "")
            {
                labelCamposInvalidosNombre.Content = "Por favor, introduzca un nombre";
                camposVacios = true;
            }
            if (cajaDTextoTelfono.Text == "")
            {
                labelCamposInvalidosTelefonos.Content = "Por favor, introduzca su telefono";
                camposVacios = true;
            }
            if (cajaDTextoApellidos.Text == "")
            {
                labelCamposInvalidosApellidos.Content = "Por favor, introduzca su apellido";
                camposVacios = true;
            }
            if (cajaDTextoCorreo.Text == "")
            {
                labelCamposInvalidosCorreo.Content = "Por favor, introduzca su correo";
                camposVacios = true;
            }
            if (cajaDTextoContrasenia.Text == "")
            {
                labelCamposInvalidosContrasenia.Content = "Por favor, introduzca su contraseña";
                camposVacios = true;
            }
            if (calendarioInformacion.SelectedDate==null)
            { 
                //calendarioInformacion.SelectedDate = DateTime.Now;
                labelCamposInvalidosCalendario.Content = "Por favor, introduzca una fecha";
                camposVacios = true;
            }
            return camposVacios;
        }
        private int validarCorreo()
        {
            ServicioAhorcadoSupremo.ServiceAhorcadoClient validarJugadores = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            int idJugador = 1;
            int correoValido = 1;

            List<Jugador> ListaDeJugadores = new List<Jugador>();

            while (validarJugadores.recuperarJugadorAsync(idJugador.ToString()).Result != null)
            {
                ListaDeJugadores.Add(validarJugadores.recuperarJugadorAsync(idJugador.ToString()).Result);
                idJugador++;
            }
            for (int i = 0; i < ListaDeJugadores.Count; i++)
            {
                if (ListaDeJugadores[i].CorreoElectronico == cajaDTextoCorreo.Text)
                {
                    correoValido = 0;
                }
            }

            return correoValido;
        }
        private void registrarJugador()
        {
            ServicioAhorcadoSupremo.ServiceAhorcadoClient registrarJugador = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            Jugador jugadorNuevo = new Jugador();
            jugadorNuevo.Nombre = cajaDTextoNombre.Text;
            jugadorNuevo.Apellidos = cajaDTextoApellidos.Text;
            jugadorNuevo.FechaNacimiento = calendarioInformacion.SelectedDate.ToString();
            jugadorNuevo.Celular = cajaDTextoTelfono.Text;
            jugadorNuevo.CorreoElectronico = cajaDTextoCorreo.Text;
            jugadorNuevo.Password= cajaDTextoContrasenia.Text;
            jugadorNuevo.Puntaje= 0;

            registrarJugador.RegistrarJugadorAsync(jugadorNuevo);
        }
    }
}
