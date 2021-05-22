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
    [Route("mpreservacion")]
    [ApiController]
    public class MobiliarioPorReservacionController : ControllerBase
    {
        private readonly IMobiliarioPorReservacionAppService _mobiliarioPorReservacionAppService;
        public MobiliarioPorReservacionController(IMobiliarioPorReservacionAppService mobiliarioPorReservacionAppService)
        {
            _mobiliarioPorReservacionAppService = mobiliarioPorReservacionAppService;
        }
        [HttpGet]
        public List<MobiliarioPorReservacionDTO> ObtenerCategorias()
        {
            List<MobiliarioPorReservacionDTO> response = _mobiliarioPorReservacionAppService.ObtenerMobiliariosPorReservacion();
            return response;
        }

        [HttpPost]
        public MobiliarioPorReservacionDTO CrearCategoria([FromBody] CrearMobiliarioPorReservacionRequest request)
        {
            MobiliarioPorReservacionDTO response = _mobiliarioPorReservacionAppService.CrearMobiliarioPorReservacion(request);
            return response;
        }

        [HttpPut]
        public MobiliarioPorReservacionDTO ModificarCategoria([FromBody] ModificarMobiliarioPorReservacionRequest request)
        {
            MobiliarioPorReservacionDTO response = _mobiliarioPorReservacionAppService.ModificarMobiliarioPorReservacion(request);
            return response;
        }
    }
}
