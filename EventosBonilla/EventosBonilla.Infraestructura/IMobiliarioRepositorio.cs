using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public interface IMobiliarioRepositorio
    {
        public List<MobiliarioDTO> ObtenerMobiliarios();

        public MobiliarioDTO ObtenerMobiliarioPorId(int idMobiliario);

        public MobiliarioDTO CrearMobiliario(MobiliarioDTO mobiliarioNuevo);

        public MobiliarioDTO ModificarMobiliario(MobiliarioDTO mobiliarioNuevo);
    }
}
