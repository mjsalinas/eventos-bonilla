using System;
using System.Collections.Generic;

namespace EventosBonilla.EventosBonilla.Dominio.Modelos
{
    public partial class Clientes
    {
        public int IdClientes { get; set; }
        public string Nombre { get; set; }
        public int? NoTelefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Estado { get; set; }
    }
}
