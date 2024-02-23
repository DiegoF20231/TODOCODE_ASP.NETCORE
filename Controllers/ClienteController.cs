using BackendTodoCode.Interfaces;
using BackendTodoCode.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendTodoCode.Controllers
{

    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteRepository service;


        public ClienteController(ClienteRepository service)
        {
            this.service = service;

        }



        [HttpGet("api/[controller]")]
        public async Task<IActionResult> GetClientes()
        {
            List<Cliente> clientes = await service.GetClientes();
            return Ok(clientes);
        }

        [HttpPost("/api/[controller]")]
        public async Task<IActionResult> CrearCliente(Cliente cliente)
        {
            bool creado = await service.CrearCliente(cliente);


            if (!creado)
            {
                return BadRequest();
            }
            return Ok(new { mensaje = "Cliente Creadooo", cliente });
        }

        [HttpDelete("/api/[controller]/{id:int}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            bool eliminado = await service.EliminarCliente(id);
            if (!eliminado)
            {
                return BadRequest(new { mensaje = $"No existe un cliente con id {id}" });
            }
            return Ok(new { mensaje = "Cliente eliminado" });
        }

        [HttpGet("/api/[controller]/{id:int}")]
        public async Task<IActionResult> BuscarCliente(int id)
        {
            Cliente c = await service.BuscarCliente(id);
            if (c == null)
            {
                return BadRequest(new { mensaje = $"No existe un cliente con id {id}" });
            }
            return Ok(new { cliente = c });
        }

        [HttpPut("api/[controller]/{id:int}")]
        public async Task<IActionResult> ActualizarCliente(Cliente cliente, int id)
        {
            Cliente c = await service.ActualizarCliente(cliente, id);
            if (c == null)
            {
                return BadRequest(new { mensaje = $"No existe un cliente con id {id}" });
            }
            return Ok(new { mensaje = "Cliente actualizado", cliente = c });
        }

    }
}
