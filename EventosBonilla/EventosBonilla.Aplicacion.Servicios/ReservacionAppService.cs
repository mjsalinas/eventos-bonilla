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

        public ReservacionAppService(IReservacionRepositorio reservacionRepositorio)
        {
            _reservacionRepositorio = reservacionRepositorio;
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
            ReservacionDTO response = _reservacionRepositorio.CrearReservacion(reservacionNueva);
            return response;
        }

        public ReservacionDTO ModificarReservacion(ModificarReservacionRequest request)
        {
            ReservacionDTO reservacionNueva = new ReservacionDTO
            {
                IdReservacion = request.IdReservacion,
                IdCliente = request.IdCliente,
                IdEvento = request.IdEvento,
                CategoriaEvento = request.CategoriaEvento,
                FechaReservacion = request.FechaReservacion
            };
            ReservacionDTO response = _reservacionRepositorio.ModificarReservacion(reservacionNueva);
            return response;
        }

        public List<ReservacionDTO> ObtenerReservaciones()
        {
            List<ReservacionDTO> response = _reservacionRepositorio.ObtenerReservaciones();
            return response;
        }
    }
}
