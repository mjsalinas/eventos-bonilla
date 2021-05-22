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
    public class MobiliarioPorReservacionAppService : IMobiliarioPorReservacionAppService
    {
        private readonly IMobiliarioPorReservacionRepositorio _mobiliarioPorReservacionRepositorio;
        private readonly IEventosBonillaDomainService _eventosDomainService;
        public MobiliarioPorReservacionAppService(IMobiliarioPorReservacionRepositorio mobiliarioPorReservacionRepositorio, IEventosBonillaDomainService eventosDomainService)
        {
            _mobiliarioPorReservacionRepositorio = mobiliarioPorReservacionRepositorio;
            _eventosDomainService = eventosDomainService;
        }
        public MobiliarioPorReservacionDTO CrearMobiliarioPorReservacion(CrearMobiliarioPorReservacionRequest request)
        {
            MobiliarioPorReservacionDTO mprNuevo = new MobiliarioPorReservacionDTO
            {
                 IdMobiliario = request.IdMobiliario,
                  IdReservacion = request.IdReservacion, 
            };
            bool mobiliarioDisponible = _eventosDomainService.MobiliarioDisponible(mprNuevo.IdMobiliario);
            bool puedeReservarMobiliario = _eventosDomainService.PuedeReservarMobiliario(request.IdReservacion, request.IdMobiliario);
            if (mobiliarioDisponible & puedeReservarMobiliario)
            {
                MobiliarioPorReservacionDTO response = _mobiliarioPorReservacionRepositorio.CrearMobiliarioPorReservacion(mprNuevo);
                return response;
            }
            return new MobiliarioPorReservacionDTO
            {
                MensajeError = "No puede reservar ese mobiliario"
            };
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
