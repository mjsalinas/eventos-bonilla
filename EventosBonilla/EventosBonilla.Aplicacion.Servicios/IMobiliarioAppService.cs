using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public interface IMobiliarioAppService
    {
        public List<MobiliarioDTO> ObtenerMobiliarios();

        public MobiliarioDTO CrearMobiliario(CrearMobiliarioRequest request);

        public MobiliarioDTO ModificarMobiliario(ModificarMobiliarioRequest request);
    }
}
