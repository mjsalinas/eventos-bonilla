using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Dominio
{
    public class EventosBonillaDomainService : IEventosBonillaDomainService
    {
        IReservacionRepositorio _reservacionRepositorio;
        IMobiliarioRepositorio _mobiliarioRepositorio;
        IMobiliarioPorReservacionRepositorio _mobiliarioPorReservacionRepositorio;
        IClientesRepositorio _clienteRepositorio;

        public EventosBonillaDomainService(IReservacionRepositorio reservacionRepositorio
            , IMobiliarioRepositorio mobiliarioRepositorio
            , IMobiliarioPorReservacionRepositorio mobiliarioPorReservacionRepositorio
            , IClientesRepositorio clientesRepositorio
            )
        {
            _reservacionRepositorio = reservacionRepositorio;
            _mobiliarioRepositorio = mobiliarioRepositorio;
            _mobiliarioPorReservacionRepositorio = mobiliarioPorReservacionRepositorio;
            _clienteRepositorio = clientesRepositorio;
        }
        public bool PermitidoParaReservar(DateTime? fechaReservacion, int? idCliente)
        {
            ClienteDTO cliente = _clienteRepositorio.ObtenerClientePorId((int)idCliente);
            
            if (cliente == null || TieneEdadParaReservar(cliente.FechaNacimiento) == false || TieneEstadoDisponible(cliente) == false)
            {
                return false;
            }

            DateTime ljStartTime = DateTime.Parse( "7:30 AM");
            DateTime ljEndTime = DateTime.Parse("9:00 PM");
            DateTime vsStartTime = DateTime.Parse("3:00 PM");
            DateTime vsEndTime = DateTime.Parse("11:00 PM");


            int dia = (int) ((DateTime)fechaReservacion).DayOfWeek;
            DateTime hora = DateTime.Parse(((DateTime)fechaReservacion).TimeOfDay.ToString());

            if (1 <= dia && dia <= 4 )
            {
                if (ljStartTime <= hora & hora <= ljEndTime)
                {
                    return true;
                }
            } else if  (dia == 5 || dia == 6)
            {
                if (vsStartTime <= hora & hora <= vsEndTime)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExisteReservacion(int? idEvento, DateTime? fechaReservacion)
        {
            List<ReservacionDTO> reservaciones = _reservacionRepositorio.ObtenerReservaciones();
            var reservacionesExistentes = from r in reservaciones
                                          where r.FechaReservacion == fechaReservacion & r.IdEvento == idEvento
                                          select r;
            if (reservaciones.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool MobiliarioDisponible(int? mobiliarioId)
        {
            MobiliarioDTO mobiliario = _mobiliarioRepositorio.ObtenerMobiliarioPorId((int)mobiliarioId);
            if(mobiliario.Estado == "Disponible")
            {
                return true;
            }
            return false;
        }

        public bool PuedeReservarMobiliario(int? idReservacion, int? idMobiliario)
        {
            List<MobiliarioPorReservacionDTO> mobiliarios = _mobiliarioPorReservacionRepositorio.ObtenerMobiliarioPorReservacions();
            var mobiliariosReservados= from m in mobiliarios
                                        where m.IdMobiliario == (int)idMobiliario & m.IdReservacion == (int)idReservacion
                                        select m;
            if (mobiliariosReservados.Count() == 10)
            {
                return false;
            }
            return true;
        }

        public bool TieneEdadParaReservar(DateTime? fechaNacimiento)
        {
            if (((DateTime.Now - (DateTime)fechaNacimiento).TotalDays)/365 < 21)
            {
                return false;
            }
            return true;
        }

        public bool TieneEstadoDisponible(ClienteDTO cliente)
        {
            if(cliente.Estado == "Mora" || cliente.Estado == "Cancelado")
            {
                return false;
            }
            return true;

        }
    }
}
