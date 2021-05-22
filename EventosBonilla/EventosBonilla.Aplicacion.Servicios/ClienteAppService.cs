using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using EventosBonilla.EventosBonilla.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Aplicacion.Servicios
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClientesRepositorio _clienteRepositorio;
        public ClienteAppService(IClientesRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public ClienteDTO CrearCliente(CrearClienteRequest request)
        {
            ClienteDTO clienteNuevo = new ClienteDTO
            {
                Nombre = request.Nombre,
                FechaNacimiento = request.FechaNacimiento,
                NoTelefono = request.NoTelefono,
                Estado = request.Estado
            };
            ClienteDTO response = _clienteRepositorio.CrearCliente(clienteNuevo);
            return response;
        }

        public ClienteDTO ModificarCliente(ModificarClienteRequest request)
        {
            ClienteDTO clienteNuevo = new ClienteDTO
            {
                IdClientes = request.IdClientes,
                Nombre = request.Nombre,
                FechaNacimiento = request.FechaNacimiento,
                NoTelefono = request.NoTelefono,
                Estado = request.Estado
            };
            ClienteDTO response = _clienteRepositorio.ModificarCliente(clienteNuevo);
            return response;
        }

        public List<ClienteDTO> ObtenerClientes()
        {
            List<ClienteDTO> response = _clienteRepositorio.ObtenerCliente();
            return response;
        }
    }
}
