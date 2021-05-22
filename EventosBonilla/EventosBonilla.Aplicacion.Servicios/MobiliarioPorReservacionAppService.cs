using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using EventosBonilla.EventosBonilla.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public class MobiliarioPorReservacionAppService : IMobiliarioPorReservacionAppService
    {
        private readonly IMobiliarioPorReservacionRepositorio _mobiliarioPorReservacionRepositorio;
        public MobiliarioPorReservacionAppService(IMobiliarioPorReservacionRepositorio mobiliarioPorReservacionRepositorio)
        {
            _mobiliarioPorReservacionRepositorio = mobiliarioPorReservacionRepositorio;
        }
        public MobiliarioPorReservacionDTO CrearMobiliarioPorReservacion(CrearMobiliarioPorReservacionRequest request)
        {
            MobiliarioPorReservacionDTO mprNuevo = new MobiliarioPorReservacionDTO
            {
                 IdMobiliario = request.IdMobiliario,
                  IdReservacion = request.IdReservacion, 
            };
            MobiliarioPorReservacionDTO response = _mobiliarioPorReservacionRepositorio.CrearMobiliarioPorReservacion(mprNuevo);
            return response;
        }

        public MobiliarioPorReservacionDTO ModificarMobiliarioPorReservacion(ModificarMobiliarioPorReservacionRequest request)
        {
            MobiliarioPorReservacionDTO mprNuevo = new MobiliarioPorReservacionDTO
            {
                IdMobiliarioPorReservacion = request.IdMobiliarioPorReservacion,
                IdMobiliario = request.IdMobiliario,
                IdReservacion = request.IdReservacion,
            };
            MobiliarioPorReservacionDTO response = _mobiliarioPorReservacionRepositorio.ModificarMobiliarioPorReservacion(mprNuevo);
            return response;
        }

        public List<MobiliarioPorReservacionDTO> ObtenerMobiliariosPorReservacion()
        {
            List<MobiliarioPorReservacionDTO> response = _mobiliarioPorReservacionRepositorio.ObtenerMobiliarioPorReservacions();
            return response;
        }
    }
}
