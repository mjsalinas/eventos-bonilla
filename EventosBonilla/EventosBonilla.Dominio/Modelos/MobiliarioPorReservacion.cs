using System;
using System.Collections.Generic;

namespace EventosBonilla.EventosBonilla.Dominio.Modelos
{
    public partial class MobiliarioPorReservacion
    {
        public int IdMobiliarioPorReservacion { get; set; }
        public int? IdReservacion { get; set; }
        public int? IdMobiliario { get; set; }
    }
}
