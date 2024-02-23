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
            return Ok(new { mensaje = "Cliente Creado", cliente });
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

    }
}
