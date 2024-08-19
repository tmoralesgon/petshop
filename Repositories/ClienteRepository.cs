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
    }
}
