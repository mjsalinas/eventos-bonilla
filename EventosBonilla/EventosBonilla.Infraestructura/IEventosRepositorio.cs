using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public interface IEventosRepositorio
    {
        public List<EventoDTO> ObtenerEventos();

        public EventoDTO ObtenerEventoPorId(int idEvento);

        public EventoDTO CrearEvento(EventoDTO eventoNuevo);

        public EventoDTO ModificarEvento(EventoDTO eventoNuevo);

    }
}
