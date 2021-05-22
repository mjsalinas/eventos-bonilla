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
    [Route("eventos")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventosAppService _eventosAppService;
        public EventosController(IEventosAppService eventosAppService)
        {
            _eventosAppService = eventosAppService;
        }
        [HttpGet]
        public List <EventoDTO> ObtenerEventos()
        {
            List<EventoDTO> response = _eventosAppService.ObtenerEventos();
            return response;
        }

        [HttpPost]
        public EventoDTO CrearEvento([FromBody] CrearEventoRequest request)
        {
            EventoDTO response = _eventosAppService.CrearEvento(request);
            return response;
        }

        [HttpPut]
        public EventoDTO ModificarEvento([FromBody] ModificarEventoRequest request)
        {
            EventoDTO response = _eventosAppService.ModificarEvento(request);
            return response;
        }
    }
}
