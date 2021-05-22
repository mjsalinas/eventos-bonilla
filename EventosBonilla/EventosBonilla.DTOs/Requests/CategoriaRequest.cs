using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.DTOs.Requests
{
    public class ObtenerCategoriaPorIdRequest
    {
        public int IdCategoria { get; set; }

    }
    public class CrearCategoriaRequest
    {
        public string Categoria { get; set; }
    }

    public class ModificarCategoriaRequest
    {
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
    }
}
