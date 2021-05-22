using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using EventosBonilla.EventosBonilla.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public class MobiliarioAppService : IMobiliarioAppService
    {
        private readonly IMobiliarioRepositorio _mobiliarioRepositorio;
        public MobiliarioAppService(IMobiliarioRepositorio mobiliarioRepositorio )
        {
            _mobiliarioRepositorio = mobiliarioRepositorio;
        }
        public MobiliarioDTO CrearMobiliario(CrearMobiliarioRequest request)
        {
            MobiliarioDTO mobiliarioNuevo = new MobiliarioDTO
            {
                Nombre = request.Nombre,
                Estado = request.Estado
            };

            MobiliarioDTO response = _mobiliarioRepositorio.CrearMobiliario(mobiliarioNuevo)
;
            return response;
        }

        public MobiliarioDTO ModificarMobiliario(ModificarMobiliarioRequest request)
        {
            MobiliarioDTO mobiliarioNuevo = new MobiliarioDTO
            {
                IdMobiliario = request.IdMobiliario,
                Nombre = request.Nombre,
                Estado = request.Estado
            };
            MobiliarioDTO response = _mobiliarioRepositorio.CrearMobiliario(mobiliarioNuevo)
;
            return response;
        }

        public List<MobiliarioDTO> ObtenerMobiliarios()
        {
            List<MobiliarioDTO> response = _mobiliarioRepositorio.ObtenerMobiliarios();
            return response;
        }
    }
}
