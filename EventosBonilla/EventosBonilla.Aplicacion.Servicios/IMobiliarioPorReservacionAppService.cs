using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public interface IMobiliarioPorReservacionAppService
    {
        public List<MobiliarioPorReservacionDTO> ObtenerMobiliariosPorReservacion();

        public MobiliarioPorReservacionDTO CrearMobiliarioPorReservacion(CrearMobiliarioPorReservacionRequest request);

        public MobiliarioPorReservacionDTO ModificarMobiliarioPorReservacion(ModificarMobiliarioPorReservacionRequest request);
    }
}
