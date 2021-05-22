using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using EventosBonilla.EventosBonilla.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public class CategoriasAppService :ICategoriasAppService
    {
        private readonly ICategoriasRepositorio _categoriaRepositorio;
        public CategoriasAppService(ICategoriasRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public CategoriaDTO CrearCategoria(CrearCategoriaRequest request)
        {
            CategoriaDTO categoriaNueva = new CategoriaDTO
            {
                Categoria = request.Categoria
            };
            CategoriaDTO response = _categoriaRepositorio.CrearCategoria(categoriaNueva);
            return response;
        }

        public CategoriaDTO ModificarCategoria(ModificarCategoriaRequest request)
        {
            throw new NotImplementedException();
        }

        public CategoriaDTO ObtenerCategoriaPorId(ObtenerCategoriaPorIdRequest request)
        {
            throw new NotImplementedException();
        }

        public List<CategoriaDTO> ObtenerCategorias()
        {
            List<CategoriaDTO> response = _categoriaRepositorio.ObtenerCategorias();
            return response;
        }
    }
}
