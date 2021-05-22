using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs
{
    public class ReservacionDTO
    {
        public int IdReservacion { get; set; }
        public int? IdCliente { get; set; }
        public int? IdEvento { get; set; }
        public string CategoriaEvento { get; set; }
        public DateTime? FechaReservacion { get; set; }
        public string MensajeError { get; set; }


    }
}
