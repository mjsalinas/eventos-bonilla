using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs.Requests
{
    public class CrearReservacionRequest
    {
        public int? IdCliente { get; set; }
        public int? IdEvento { get; set; }
        public string CategoriaEvento { get; set; }
        public DateTime? FechaReservacion { get; set; }
    }
    public class ModificarReservacionRequest
    {
        public int IdReservacion { get; set; }
        public int? IdCliente { get; set; }
        public int? IdEvento { get; set; }
        public string CategoriaEvento { get; set; }
        public DateTime? FechaReservacion { get; set; }
    }
}
