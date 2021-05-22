using EventosBonilla.EventosBonilla.Aplicacion.Servicios;
using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.Controllers
{
    [Route("mobiliario")]
    [ApiController]
    public class MobiliarioController : ControllerBase
    {
        private readonly IMobiliarioAppService _mobiliarioAppService;

        public MobiliarioController(IMobiliarioAppService mobiliarioAppService)
        {
            _mobiliarioAppService = mobiliarioAppService;
        }

        [HttpGet]
        public List<MobiliarioDTO> ObtenerMobiliarios()
        {
            List<MobiliarioDTO> response = _mobiliarioAppService.ObtenerMobiliarios();
            return response;
        }

        [HttpPost]
        public MobiliarioDTO CrearCategoria([FromBody] CrearMobiliarioRequest request)
        {
            MobiliarioDTO response = _mobiliarioAppService.CrearMobiliario(request);
            return response;
        }

        [HttpPut]
        public MobiliarioDTO ModificarCategoria([FromBody] ModificarMobiliarioRequest request)
        {
            MobiliarioDTO response = _mobiliarioAppService.ModificarMobiliario(request);
            return response;
        }
    }
}
