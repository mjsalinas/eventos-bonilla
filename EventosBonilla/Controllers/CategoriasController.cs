using EventosBonilla.EventosBonilla.Aplicacion.Servicios;
using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using EventosBonilla.EventosBonilla.Infraestructura;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.Controllers
{
    [Route("categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasAppService _categoriasAppService; 
        public CategoriasController(ICategoriasAppService categoriasAppService)
        {
            _categoriasAppService = categoriasAppService;
        }

        [HttpGet]
       public List<CategoriaDTO> ObtenerCategorias ()
        {
            List<CategoriaDTO> response = _categoriasAppService.ObtenerCategorias();
            return response;
        }

        [HttpPost]
        public CategoriaDTO CrearCategoria ([FromBody] CrearCategoriaRequest request)
        {
            CategoriaDTO response = _categoriasAppService.CrearCategoria(request);
            return response;
        }
    }
}
