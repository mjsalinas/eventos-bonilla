using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs
{
    public class EventoDTO
    {
        public int IdEvento { get; set; }
        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Responsable { get; set; }
        public string MensajeError { get; set; }
    }
}
