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
    [Route("reservacion")]
    [ApiController]
    public class ReservacionController : ControllerBase
    {
        private readonly IReservacionAppService _reservacionAppService;
        public ReservacionController(IReservacionAppService reservacionAppService)
        {
            _reservacionAppService = reservacionAppService;
        }

        [HttpGet]
        public List<ReservacionDTO> ObtenerReservaciones()
        {
            List<ReservacionDTO> response = _reservacionAppService.ObtenerReservaciones();
            return response;
        }

        [HttpPost]
        public ReservacionDTO CrearReservacion([FromBody] CrearReservacionRequest request)
        {
            ReservacionDTO response = _reservacionAppService.CrearReservacion(request);
            return response;
        }

        [HttpPut]
        public ReservacionDTO ModificarReservacion([FromBody] ModificarReservacionRequest request)
        {
            ReservacionDTO response = _reservacionAppService.ModificarReservacion(request);
            return response;
        }
    }
}
