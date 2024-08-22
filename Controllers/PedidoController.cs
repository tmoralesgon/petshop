using GestorPetshop.Models;
using GestorPetshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GestorPetshop.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;

        private GestorPetshopContext context;

        public PedidoController(ILogger<PedidoController> logger)
        {
            _logger = logger;

            context = new GestorPetshopContext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            ItemsViewModel vm = new ItemsViewModel();
            vm.ListadoJuguetes = context.Juguetes.ToList();
            vm.ListadoComestibles = context.Comestibles.ToList();
            return View(vm);
        }
    }
}
