using GestorPetshop.Models;

namespace GestorPetshop.ViewModels
{
    public class ClientesViewModel
    {
        public ClientesViewModel()
        {
            ListadoClientes = new List<Cliente>();
        }

        public List<Cliente> ListadoClientes { get; set; }

    }
}
