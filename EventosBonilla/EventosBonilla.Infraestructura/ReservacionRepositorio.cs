using EventosBonilla.EventosBonilla.Dominio.Modelos;
using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public class ReservacionRepositorio : IReservacionRepositorio
    {
        private readonly eventos_bonillaContext db;
        public ReservacionRepositorio(eventos_bonillaContext _db)
        {
            db = _db;
        }
        public ReservacionDTO CrearReservacion(ReservacionDTO reservacionNueva)
        {
            Reservacion reservacion = new Reservacion
            {
                 IdCliente = reservacionNueva.IdCliente,
                  IdEvento = reservacionNueva.IdEvento,
                   CategoriaEvento = reservacionNueva.CategoriaEvento,
                    FechaReservacion = reservacionNueva.FechaReservacion
            };
            db.Reservacion.Add(reservacion);
            db.SaveChanges();
            return reservacionNueva;
        }

        public ReservacionDTO ModificarReservacion(ReservacionDTO reservacionNueva)
        {
            Reservacion reservacionRegistrada = db.Reservacion.FirstOrDefault(res => res.IdReservacion == reservacionNueva.IdReservacion);
            Clientes clienteRegistrado = db.Clientes.FirstOrDefault(cliente => cliente.IdClientes == reservacionNueva.IdCliente);
            Eventos eventoRegistrado = db.Eventos.FirstOrDefault(ev => ev.IdEvento == reservacionNueva.IdEvento);
            if (reservacionRegistrada == null)
            {
                return new ReservacionDTO
                {
                    MensajeError = "Reservacion no existe"
                };
            }
            if (clienteRegistrado == null)
            {
                return new ReservacionDTO
                {
                    MensajeError = "Cliente no existe"
                };
            }

            if (eventoRegistrado == null)
            {
                return new ReservacionDTO
                {
                    MensajeError = "Evento no existe"
                };
            }
            reservacionRegistrada.IdCliente = reservacionNueva.IdCliente;
            reservacionRegistrada.IdEvento = reservacionNueva.IdEvento;
            reservacionRegistrada.CategoriaEvento = reservacionNueva.CategoriaEvento;
            reservacionRegistrada.FechaReservacion = reservacionNueva.FechaReservacion;

            db.SaveChanges();
            return reservacionNueva;
        }

        public List<ReservacionDTO> ObtenerReservaciones()
        {
            List<ReservacionDTO> reservacionDTO = new List<ReservacionDTO>();
            List<Reservacion> reservacionEntidad = db.Reservacion.ToList();
            foreach (var reservacion in reservacionEntidad)
            {
                reservacionDTO.Add(new ReservacionDTO
                {
                    IdReservacion = reservacion.IdReservacion,
                    IdCliente = reservacion.IdCliente,
                    IdEvento = reservacion.IdEvento,
                    CategoriaEvento = reservacion.CategoriaEvento,
                    FechaReservacion = reservacion.FechaReservacion,
                });
            }
            return reservacionDTO;
        }

        public ReservacionDTO ObtenerReservacionPorId(int idReservacion)
        {
            Reservacion reservacionRegistrada = db.Reservacion.FirstOrDefault(res => res.IdReservacion == idReservacion);
            return new ReservacionDTO
            {
                IdReservacion = reservacionRegistrada.IdReservacion,
                IdCliente = reservacionRegistrada.IdCliente,
                IdEvento = reservacionRegistrada.IdEvento,
                CategoriaEvento = reservacionRegistrada.CategoriaEvento,
                FechaReservacion = reservacionRegistrada.FechaReservacion
            };
        }
    }
}
