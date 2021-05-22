using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public interface IEventosAppService
    {
        public List<EventoDTO> ObtenerEventos();
        public EventoDTO CrearEvento(CrearEventoRequest request);
        public EventoDTO ModificarEvento(ModificarEventoRequest request);
    }
}
