using EventosBonilla.EventosBonilla.Dominio.Modelos;
using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public class MobiliarioRepositorio : IMobiliarioRepositorio
    {
        private readonly eventos_bonillaContext db;
        public MobiliarioDTO CrearMobiliario(MobiliarioDTO mobiliarioNuevo)
        {
            Mobiliario mobiliarios = new Mobiliario
            {
                 Nombre = mobiliarioNuevo.Nombre,
                 Estado = mobiliarioNuevo.Estado,
            };
            db.Mobiliario.Add(mobiliarios);
            db.SaveChanges();
            return mobiliarioNuevo;
        }

        public MobiliarioDTO ModificarMobiliario(MobiliarioDTO mobiliarioNuevo)
        {
            Mobiliario mobiliarioRegistrado = db.Mobiliario.FirstOrDefault(mob => mob.IdMobiliario== mobiliarioNuevo.IdMobiliario);
            if (mobiliarioRegistrado == null)
            {
                return new MobiliarioDTO
                {
                    MensajeError = "Mobiliario no existe"
                };
            }
            mobiliarioRegistrado.Nombre = mobiliarioNuevo.Nombre;
            mobiliarioRegistrado.Estado = mobiliarioNuevo.Estado;
            db.SaveChanges();
            return mobiliarioNuevo;
        }

        public MobiliarioDTO ObtenerMobiliarioPorId(int idMobiliario)
        {
            Mobiliario mobiliarioRegistrado = db.Mobiliario.FirstOrDefault(mob => mob.IdMobiliario== idMobiliario);
            return new MobiliarioDTO
            {
             IdMobiliario = mobiliarioRegistrado.IdMobiliario,
             Nombre = mobiliarioRegistrado.Nombre,
             Estado = mobiliarioRegistrado.Estado
               };
        }

        public List<MobiliarioDTO> ObtenerMobiliarios()
        {
            List<MobiliarioDTO> mobiliarioDTO = new List<MobiliarioDTO>();
            List<Mobiliario> mobiliariosEntidad = db.Mobiliario.ToList();
            foreach (var mobiliario in mobiliariosEntidad)
            {
                mobiliarioDTO.Add(new MobiliarioDTO
                {
                    IdMobiliario = mobiliario.IdMobiliario,
                    Nombre = mobiliario.Nombre,
                    Estado = mobiliario.Estado
                });
            }
            return mobiliarioDTO;
        }
    }
}
