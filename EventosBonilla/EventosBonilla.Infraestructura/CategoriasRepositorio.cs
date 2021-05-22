using EventosBonilla.EventosBonilla.Dominio.Modelos;
using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public class CategoriasRepositorio : ICategoriasRepositorio
    {
        private readonly eventos_bonillaContext db;

        public CategoriasRepositorio(eventos_bonillaContext dbContext)
        {
            db = dbContext;
        }
        public CategoriaDTO CrearCategoria(CategoriaDTO categoriaNueva)
        {
            Categorias categorias = new Categorias
            {
                Categoria = categoriaNueva.Categoria,
            };
            db.Categorias.Add(categorias);
            db.SaveChanges();
            return categoriaNueva;
        }

        public CategoriaDTO ModificarCategoria(CategoriaDTO categoriaNueva)
        {
            Categorias categoriaRegistrada = db.Categorias.FirstOrDefault(cat => cat.IdCategoria == categoriaNueva.IdCategoria);
            if (categoriaRegistrada == null)
            {
                return new CategoriaDTO
                {
                    MensajeError = "Categoria no existe"
                };
            }
            categoriaRegistrada.Categoria = categoriaNueva.Categoria;
            db.SaveChanges();
            return categoriaNueva;
        }

        public CategoriaDTO ObtenerCategoriaPorId(int idCategoria)
        {
            Categorias categoriaRegistrada = db.Categorias.FirstOrDefault(cat => cat.IdCategoria == idCategoria);
            return new CategoriaDTO
            {
               IdCategoria = categoriaRegistrada.IdCategoria,
               Categoria = categoriaRegistrada.Categoria
            };
        }

        public List<CategoriaDTO> ObtenerCategorias()
        {
            List<CategoriaDTO> categoriasDTO = new List<CategoriaDTO>();
            List<Categorias> categoriasEntidad = db.Categorias.ToList();
            foreach (var categoria in categoriasEntidad)
            {
                categoriasDTO.Add(new CategoriaDTO
                {
                    IdCategoria = categoria.IdCategoria,
                    Categoria = categoria.Categoria,
                });
            }
            return categoriasDTO;
        }
    }
}
