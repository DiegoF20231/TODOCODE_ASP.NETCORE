using BackendTodoCode.Interfaces;
using BackendTodoCode.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendTodoCode.Services
{
    public class ClienteService : ClienteRepository
    {
        private readonly TodoCodeContext _context;

        public ClienteService(TodoCodeContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> GetClientes()
        {
            List<Cliente> clientes = await _context.Clientes.ToListAsync();
            return clientes;
        }


        public Task<bool> ActualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> BuscarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CrearCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarCliente(int id)
        {
            throw new NotImplementedException();
        }


    }
}
