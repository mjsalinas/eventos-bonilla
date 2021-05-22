using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs
{
    public class MobiliarioDTO
    {
        public int IdMobiliario { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string MensajeError { get; set; }

    }
}
