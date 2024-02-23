﻿using BackendTodoCode.Models;

namespace BackendTodoCode.Interfaces
{
    public interface ClienteRepository
    {
        public Task<List<Cliente>> GetClientes();
        public Task<bool> CrearCliente(Cliente cliente);
        public Task<bool> EliminarCliente(int id);
        public Task<Cliente> BuscarCliente(int id);
        public Task<Cliente> ActualizarCliente(Cliente cliente, int id);


    }

}
