using EventosBonilla.EventosBonilla.Aplicacion.Servicios;
using EventosBonilla.EventosBonilla.DTOs;
using EventosBonilla.EventosBonilla.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosBonilla.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;
        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        public List<ClienteDTO> ObtenerClientes()
        {
            List<ClienteDTO> response = _clienteAppService.ObtenerClientes();
            return response;
        }

        [HttpPost]
        public ClienteDTO CrearCliente([FromBody] CrearClienteRequest request)
        {
            ClienteDTO response = _clienteAppService.CrearCliente(request);
            return response;
        }

        [HttpPut]
        public ClienteDTO ModificarCliente([FromBody] ModificarClienteRequest request)
        {
            ClienteDTO response = _clienteAppService.ModificarCliente(request);
            return response;
        }
    }
}
