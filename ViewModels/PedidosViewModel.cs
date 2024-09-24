using GestorPetshop.Models;

namespace GestorPetshop.ViewModels
{

    public class PedidosViewModel
    {
        public PedidosViewModel()
        {
            ListadoPedidos = new List<Pedido>();
        }

        public List<Pedido> ListadoPedidos { get; set; }
    }
}
