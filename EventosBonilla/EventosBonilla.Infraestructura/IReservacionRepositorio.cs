using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public interface IReservacionRepositorio
    {
        public List<ReservacionDTO> ObtenerReservaciones();

        public ReservacionDTO ObtenerReservacionPorId(int idReservacion);

        public ReservacionDTO CrearReservacion(ReservacionDTO reservacionNueva);

        public ReservacionDTO ModificarReservacion(ReservacionDTO reservacionNueva);

    }
}
