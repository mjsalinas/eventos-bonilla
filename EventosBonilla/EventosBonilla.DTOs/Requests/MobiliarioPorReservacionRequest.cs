using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs.Requests
{
    public class CrearMobiliarioPorReservacionRequest
    {
        public int? IdReservacion { get; set; }
        public int? IdMobiliario { get; set; }
    }
    public class ModificarMobiliarioPorReservacionRequest
    {
        public int IdMobiliarioPorReservacion { get; set; }
        public int? IdReservacion { get; set; }
        public int? IdMobiliario { get; set; }
    }
}
