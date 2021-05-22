using System;
using System.Collections.Generic;

namespace EventosBonilla.EventosBonilla.Dominio.Modelos
{
    public partial class Reservacion
    {
        public int IdReservacion { get; set; }
        public int? IdCliente { get; set; }
        public int? IdEvento { get; set; }
        public string CategoriaEvento { get; set; }
        public DateTime? FechaReservacion { get; set; }
    }
}
