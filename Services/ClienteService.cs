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
        public async Task<bool> CrearCliente(Cliente cliente)
        {
            try
            {
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }

        public Task<bool> ActualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> BuscarCliente(int id)
        {
            try
            {
                Cliente c = await _context.Clientes.FindAsync(id);
                if (c == null)
                {
                    return null;
                }
                return c;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }



        public async Task<bool> EliminarCliente(int id)
        {
            try
            {
                Cliente c = await _context.Clientes.FindAsync(id);
                if (c == null)
                {
                    return false;
                }
                _context.Remove(c);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<Cliente> ActualizarCliente(Cliente cliente, int id)
        {
            try
            {
                Cliente c = await _context.Clientes.FindAsync(id);
                if (c == null)
                {
                    return null;
                }
                c.NombreCliente = cliente.NombreCliente;
                c.ApellidoCliente = cliente.ApellidoCliente;
                c.EmailCliente = cliente.EmailCliente;
                c.Dniempleado = cliente.Dniempleado;
                c.CelularCliente = cliente.CelularCliente;
                c.FechaNacimiento = cliente.FechaNacimiento;
                c.IdNacionalidad = cliente.IdNacionalidad;
                c.DireccionCliente = cliente.DireccionCliente;

                await _context.SaveChangesAsync();

                return c;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
