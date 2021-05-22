using System;
using System.Collections.Generic;

namespace EventosBonilla.EventosBonilla.Dominio.Modelos
{
    public partial class Eventos
    {
        public int IdEvento { get; set; }
        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Responsable { get; set; }
    }
}
