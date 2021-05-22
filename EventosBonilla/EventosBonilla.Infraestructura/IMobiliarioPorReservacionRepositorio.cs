using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public interface IMobiliarioPorReservacionRepositorio
    {
        public List<MobiliarioPorReservacionDTO> ObtenerMobiliarioPorReservacions();

        public MobiliarioPorReservacionDTO ObtenerMobiliarioPorReservacionPorId(int idMobiliarioPorReservacion);

        public MobiliarioPorReservacionDTO CrearMobiliarioPorReservacion(MobiliarioPorReservacionDTO reservacionMobiliarioNueva);

        public MobiliarioPorReservacionDTO ModificarMobiliarioPorReservacion(MobiliarioPorReservacionDTO reservacionMobiliarioNueva);

    }
}
