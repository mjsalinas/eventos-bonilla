using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Dominio
{
    public interface IEventosBonillaDomainService
    {
        public bool ExisteReservacion(int? idEvento, DateTime? fechaReservacion);

        public bool PermitidoParaReservar(DateTime? fechaReservacion, int? idCliente);

        public bool MobiliarioDisponible(int? mobiliarioId);

        public bool PuedeReservarMobiliario(int? idReservacion, int? idMobiliario);

        public bool TieneEdadParaReservar(DateTime? fechaNacimiento);

        public bool TieneEstadoDisponible(ClienteDTO cliente);

    }
}
