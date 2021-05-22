using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    public interface IClientesRepositorio
    {
        public List<ClienteDTO> ObtenerCliente();

        public ClienteDTO ObtenerClientePorId(int idCliente);

        public ClienteDTO CrearCliente(ClienteDTO clienteNuevo);

        public ClienteDTO ModificarCliente(ClienteDTO clienteNuevo);

    }
}
