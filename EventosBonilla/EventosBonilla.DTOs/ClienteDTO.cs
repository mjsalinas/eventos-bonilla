using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs
{
    public class ClienteDTO
    {
        public int IdClientes { get; set; }
        public string Nombre { get; set; }
        public int? NoTelefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Estado { get; set; }
        public string MensajeError { get; set; }
    }
}
