using EventosBonilla.EventosBonilla.Dominio.Modelos;
using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public class MobiliarioPorReservacionRepositorio : IMobiliarioPorReservacionRepositorio
    {
        private readonly eventos_bonillaContext db;
        public MobiliarioPorReservacionRepositorio(eventos_bonillaContext _db)
        {
            db = _db;
        }
        public MobiliarioPorReservacionDTO CrearMobiliarioPorReservacion(MobiliarioPorReservacionDTO reservacionMobiliarioNueva)
        {
            MobiliarioPorReservacion mobiliarioPorReservacion = new MobiliarioPorReservacion
            {
                IdMobiliario =reservacionMobiliarioNueva.IdMobiliario,
                IdReservacion = reservacionMobiliarioNueva.IdReservacion
            };
            db.MobiliarioPorReservacion.Add(mobiliarioPorReservacion);
            db.SaveChanges();
            return reservacionMobiliarioNueva;
        }

        public MobiliarioPorReservacionDTO ModificarMobiliarioPorReservacion(MobiliarioPorReservacionDTO reservacionMobiliarioNueva)
        {
            MobiliarioPorReservacion mobiliarioPorReservacionRegistrada = db.MobiliarioPorReservacion.FirstOrDefault(mpr => mpr.IdMobiliarioPorReservacion == reservacionMobiliarioNueva.IdMobiliarioPorReservacion);
            if (mobiliarioPorReservacionRegistrada == null)
            {
                return new MobiliarioPorReservacionDTO
                {
                    MensajeError = "Reservacion para ese mobiliario no existe"
                };
            }
            mobiliarioPorReservacionRegistrada.IdMobiliario = reservacionMobiliarioNueva.IdMobiliario;
            mobiliarioPorReservacionRegistrada.IdReservacion = reservacionMobiliarioNueva.IdReservacion;
            db.SaveChanges();
            return reservacionMobiliarioNueva;
        }

        public MobiliarioPorReservacionDTO ObtenerMobiliarioPorReservacionPorId(int idMobiliarioPorReservacion)
        {
            MobiliarioPorReservacion mobiliarioPorReservacionRegistrada = db.MobiliarioPorReservacion.FirstOrDefault(mpr => mpr.IdMobiliarioPorReservacion == idMobiliarioPorReservacion);
            return new MobiliarioPorReservacionDTO
            {
                IdMobiliarioPorReservacion = mobiliarioPorReservacionRegistrada.IdMobiliarioPorReservacion,
                IdMobiliario = mobiliarioPorReservacionRegistrada.IdMobiliario,
                IdReservacion = mobiliarioPorReservacionRegistrada.IdReservacion
            };  
        }

        public List<MobiliarioPorReservacionDTO> ObtenerMobiliarioPorReservacions()
        {
            List<MobiliarioPorReservacionDTO> mobiliarioPorReservacionDTO = new List<MobiliarioPorReservacionDTO>();
            List<MobiliarioPorReservacion> mobiliarioPorReservacionesEntidad = db.MobiliarioPorReservacion.ToList();
            foreach (var mpr in mobiliarioPorReservacionesEntidad)
            {
                mobiliarioPorReservacionDTO.Add(new MobiliarioPorReservacionDTO
                {
                    IdMobiliarioPorReservacion = mpr.IdMobiliarioPorReservacion,
                    IdMobiliario = mpr.IdMobiliario,
                    IdReservacion = mpr.IdReservacion
                });
            }
            return mobiliarioPorReservacionDTO;
        }
    }
}
