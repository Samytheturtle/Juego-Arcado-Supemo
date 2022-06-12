﻿using ServicioArcado.Modelo.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioArcado
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceAhorcado" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceAhorcado
    {
        [OperationContract]
        string ModificarJugador(Jugador editarJugador, string idJugador);
        [OperationContract]
        Jugador recuperarJugador(string idJugador);

    }


    
}
