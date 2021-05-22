using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }

        public string MensajeError { get; set; }
    }
}
