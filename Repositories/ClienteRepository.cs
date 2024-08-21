using GestorPetshop.Controllers;
using GestorPetshop.Models;
using Microsoft.Extensions.Logging;

namespace GestorPetshop.Repositories
{
    public class ClienteRepository
    {
        public static GestorPetshopContext context = new GestorPetshopContext();
        public static List<Cliente> GetClientes()
        {
            var clientes = context.Clientes.ToList();
            return clientes;
        }

        public static Cliente? GetCliente(int id)
        {
            return context.Clientes.Where(c => c.Id == id).FirstOrDefault();
        }

        public static Cliente? UpdateCliente(Cliente cliente)
        {
            try
            {
                var clienteFromDb = context.Clientes.Where(c => c.Id == cliente.Id).First();
                clienteFromDb.Nombre = cliente.Nombre;
                clienteFromDb.Apellido = cliente.Apellido;
                clienteFromDb.Email = cliente.Email;
                clienteFromDb.Direccion = cliente.Direccion;
                clienteFromDb.CodigoPostal = cliente.CodigoPostal;
                context.Clientes.Update(clienteFromDb);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error al actualizar el cliente: " + e.Message);
            }
            return cliente;
        }

        public static Cliente? InsertCliente(Cliente cliente)
        {
            try
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error al insertar el cliente: " + e.Message);
            }
            return cliente;
        }

        public static int RemoveCliente(int id)
        {
            try
            {
                var cliente = context.Clientes.Where(c => c.Id == id).First();
                context.Clientes.Remove(cliente);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error al eliminar el cliente: " + e.Message);
            }
            return id;
        }
    }
}
