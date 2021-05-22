using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public interface ICategoriasAppService
    {
        public List<CategoriaDTO> ObtenerCategorias();
        public CategoriaDTO ObtenerCategoriaPorId(ObtenerCategoriaPorIdRequest request );

        public CategoriaDTO CrearCategoria(CrearCategoriaRequest request);

        public CategoriaDTO ModificarCategoria(ModificarCategoriaRequest request);

    }
}
