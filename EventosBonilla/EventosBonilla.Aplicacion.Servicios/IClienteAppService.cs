using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public interface IClienteAppService
    {
        public List<ClienteDTO> ObtenerClientes();

        public ClienteDTO CrearCliente(CrearClienteRequest request);

        public ClienteDTO ModificarCliente(ModificarClienteRequest request);
    }
}
