using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public interface ICategoriasRepositorio
    {
        public List<CategoriaDTO> ObtenerCategorias();

        public CategoriaDTO ObtenerCategoriaPorId(int idCategoria);

        public CategoriaDTO CrearCategoria(CategoriaDTO categoriaNueva);

        public CategoriaDTO ModificarCategoria(CategoriaDTO categoriaNueva);

    }
}
