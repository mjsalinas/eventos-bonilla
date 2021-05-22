using EventosBonilla.EventosBonilla.Dominio;
using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using EventosBonilla.EventosBonilla.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public class ReservacionAppService : IReservacionAppService
    {
        IReservacionRepositorio _reservacionRepositorio;
        IEventosBonillaDomainService _eventosDomainService;
        public ReservacionAppService(IReservacionRepositorio reservacionRepositorio, IEventosBonillaDomainService eventosDomainService)
        {
            _reservacionRepositorio = reservacionRepositorio;
            _eventosDomainService = eventosDomainService;
        }
        public ReservacionDTO CrearReservacion(CrearReservacionRequest request)
        {
            ReservacionDTO reservacionNueva = new ReservacionDTO
            {
                IdCliente = request.IdCliente,
                IdEvento = request.IdEvento,
                CategoriaEvento = request.CategoriaEvento,
                FechaReservacion = request.FechaReservacion
            };

            bool puedeReservar = _eventosDomainService.PermitidoParaReservar(reservacionNueva.FechaReservacion, reservacionNueva.IdCliente);
            bool existeReservacion = _eventosDomainService.ExisteReservacion(reservacionNueva.IdEvento, reservacionNueva.FechaReservacion);
            
            if (puedeReservar & !existeReservacion)
            {
                ReservacionDTO response = _reservacionRepositorio.CrearReservacion(reservacionNueva);
                return response;
            }
            return new ReservacionDTO
            {
                MensajeError = "Reservacion ya existe"
            };
        }

        public ReservacionDTO ModificarReservacion(ModificarReservacionRequest request)
        {
            ReservacionDTO response = new ReservacionDTO();
            ReservacionDTO reservacionNueva = new ReservacionDTO
            {
                IdReservacion = request.IdReservacion,
                IdCliente = request.IdCliente,
                IdEvento = request.IdEvento,
                CategoriaEvento = request.CategoriaEvento,
                FechaReservacion = request.FechaReservacion
            };
            ReservacionDTO registroExistente = _reservacionRepositorio.ObtenerReservacionPorId(reservacionNueva.IdReservacion);
            if (reservacionNueva.FechaReservacion != registroExistente.FechaReservacion)
            {
                bool puedeReservar = _eventosDomainService.PermitidoParaReservar(reservacionNueva.FechaReservacion, reservacionNueva.IdCliente);
                if (puedeReservar)
                {
                    response = _reservacionRepositorio.ModificarReservacion(reservacionNueva);
                    return response;
                }
              
            }
            response = _reservacionRepositorio.ModificarReservacion(reservacionNueva);
            return response;
        }

        public List<ReservacionDTO> ObtenerReservaciones()
        {
            List<ReservacionDTO> response = _reservacionRepositorio.ObtenerReservaciones();
            return response;
        }
    }
}
