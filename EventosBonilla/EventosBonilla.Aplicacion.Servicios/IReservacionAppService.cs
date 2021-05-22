using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public interface IReservacionAppService
    {
        public List<ReservacionDTO> ObtenerReservaciones();

        public ReservacionDTO CrearReservacion(CrearReservacionRequest request);

        public ReservacionDTO ModificarReservacion(ModificarReservacionRequest request);
    }
}
