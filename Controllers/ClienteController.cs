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



        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetClientes()
        {
            List<Cliente> clientes = await service.GetClientes();
            return Ok(clientes);
        }



    }
}
