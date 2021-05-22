using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs.Requests
{
    public class CrearMobiliarioRequest
    {
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }
    public class ModificarMobiliarioRequest
    {
        public int IdMobiliario { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }

}
