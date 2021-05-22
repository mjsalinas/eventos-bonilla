using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using EventosBonilla.EventosBonilla.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public class EventosAppService : IEventosAppService
    {
        private readonly IEventosRepositorio _eventosRepositorio;
        public EventosAppService(IEventosRepositorio eventosRepositorio)
        {
            _eventosRepositorio = eventosRepositorio;
        }
        public EventoDTO CrearEvento(CrearEventoRequest request)
        {
            EventoDTO eventoNuevo = new EventoDTO
            {
                IdCategoria = request.IdCategoria,
                Nombre = request.Nombre,
                Responsable = request.Responsable,
            };
            EventoDTO response = _eventosRepositorio.CrearEvento(eventoNuevo);
            return response;
        }

        public EventoDTO ModificarEvento(ModificarEventoRequest request)
        {
            EventoDTO eventoNuevo = new EventoDTO
            {
                IdEvento = request.IdEvento,
                IdCategoria = request.IdCategoria,
                Nombre = request.Nombre,
                Responsable = request.Responsable,
            };
            EventoDTO response = _eventosRepositorio.ModificarEvento(eventoNuevo);
            return response;

        }

        public List<EventoDTO> ObtenerEventos()
        {
            List<EventoDTO> response = _eventosRepositorio.ObtenerEventos();
            return response;
        }
    }
}
