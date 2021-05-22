using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs.Requests
{
    public class CrearEventoRequest
    {
        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Responsable { get; set; }
    }
    public class ModificarEventoRequest
    {
        public int IdEvento { get; set; }
        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Responsable { get; set; }
    }
}
