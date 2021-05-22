using EventosBonilla.EventosBonilla.Dominio.Modelos;
using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public class EventosRepositorio : IEventosRepositorio
    {
        private readonly eventos_bonillaContext db;
        public EventosRepositorio(eventos_bonillaContext _db)
        {
            db = _db;
        }
        public EventoDTO CrearEvento(EventoDTO eventoNuevo)
        {
            Eventos eventos = new Eventos
            {
                 IdCategoria = eventoNuevo.IdEvento,
                  Nombre = eventoNuevo.Nombre,
                   Responsable = eventoNuevo.Responsable
            };
            db.Eventos.Add(eventos);
            db.SaveChanges();
            return eventoNuevo;
        }

        public EventoDTO ModificarEvento(EventoDTO eventoNuevo)
        {
            Eventos eventoRegistrado = db.Eventos.FirstOrDefault(ev => ev.IdEvento == eventoNuevo.IdEvento);
            Categorias categoriaRegistrada = db.Categorias.FirstOrDefault(cat => cat.IdCategoria == eventoNuevo.IdCategoria);

            if (eventoRegistrado == null)
            {
                return new EventoDTO
                {
                    MensajeError = "Evento no existe"
                };
            }
            if (categoriaRegistrada == null)
            {
                return new EventoDTO
                {
                    MensajeError = "Categoria no existe"
                };
            }
            eventoRegistrado.IdCategoria = eventoNuevo.IdCategoria;
            eventoRegistrado.Nombre = eventoNuevo.Nombre;
            eventoRegistrado.Responsable = eventoNuevo.Responsable;

            db.SaveChanges();
            return eventoNuevo;
        }

        public EventoDTO ObtenerEventoPorId(int idEvento)
        {
            Eventos eventoRegistrado = db.Eventos.FirstOrDefault(ev => ev.IdEvento == idEvento);
            return new EventoDTO
            {
                IdEvento = eventoRegistrado.IdEvento,
                IdCategoria = eventoRegistrado.IdCategoria,
                 Nombre = eventoRegistrado.Nombre,
                  Responsable = eventoRegistrado.Responsable
            };
        }

        public List<EventoDTO> ObtenerEventos()
        {
            List<EventoDTO> eventosDTO = new List<EventoDTO>();
            List<Eventos> eventosEntidad = db.Eventos.ToList();
            foreach (var evento in eventosEntidad)
            {
                eventosDTO.Add(new EventoDTO
                {
                    IdEvento = evento.IdEvento,
                    IdCategoria = evento.IdCategoria,
                    Nombre = evento.Nombre,
                    Responsable = evento.Responsable
                });
            }
            return eventosDTO;
        }

    }
}
