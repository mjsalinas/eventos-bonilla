using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs
{
    public class MobiliarioPorReservacionDTO
    {
        public int IdMobiliarioPorReservacion { get; set; }
        public int? IdReservacion { get; set; }
        public int? IdMobiliario { get; set; }
        public string MensajeError { get; set; }

    }
}
