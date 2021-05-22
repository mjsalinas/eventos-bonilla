using EventosBonilla.EventosBonilla.Dominio.Modelos;
using EventosBonilla.EventosBonilla.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.EventosBonilla.Infraestructura
{
    
    public class ClientesRepositorio : IClientesRepositorio
    {
        private readonly eventos_bonillaContext db;
        public ClienteDTO CrearCliente(ClienteDTO clienteNuevo)
        {
            Clientes clientes = new Clientes
            {
                 Nombre = clienteNuevo.Nombre,
                  NoTelefono = clienteNuevo.NoTelefono,
                   FechaNacimiento =clienteNuevo.FechaNacimiento,
                    Estado = clienteNuevo.Estado
            };
            db.Clientes.Add(clientes);
            db.SaveChanges();
            return clienteNuevo;
        }

        public ClienteDTO ModificarCliente(ClienteDTO clienteNuevo)
        {
            Clientes clienteRegistrado = db.Clientes.FirstOrDefault(cliente => cliente.IdClientes == clienteNuevo.IdClientes);
            if (clienteRegistrado == null)
            {
                return new ClienteDTO
                {
                    MensajeError = "Cliente no existe"
                };
            }
            clienteRegistrado.Nombre = clienteNuevo.Nombre;
            clienteRegistrado.NoTelefono = clienteNuevo.NoTelefono;
            clienteRegistrado.FechaNacimiento = clienteNuevo.FechaNacimiento;
            clienteRegistrado.Estado = clienteNuevo.Estado;
            db.SaveChanges();
            return clienteNuevo;
        }

        public List<ClienteDTO> ObtenerCliente()
        {
            List<ClienteDTO> clientesDTO = new List<ClienteDTO>();
            List<Clientes> clientesEntidad = db.Clientes.ToList();
            foreach (var cliente in clientesEntidad)
            {
                clientesDTO.Add(new ClienteDTO
                {
                    Nombre = cliente.Nombre,
                    NoTelefono = cliente.NoTelefono,
                    FechaNacimiento = cliente.FechaNacimiento,
                    Estado = cliente.Estado
                });
            }
            return clientesDTO;
        }

        public ClienteDTO ObtenerClientePorId(int idCliente)
        {
            Clientes clienteRegistrado = db.Clientes.FirstOrDefault(cliente => cliente.IdClientes == idCliente);
            return new ClienteDTO
            {
                Nombre = clienteRegistrado.Nombre,
                NoTelefono = clienteRegistrado.NoTelefono,
                FechaNacimiento = clienteRegistrado.FechaNacimiento,
                Estado = clienteRegistrado.Estado
            };
        }
    }
}
