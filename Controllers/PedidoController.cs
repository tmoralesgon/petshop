using GestorPetshop.Models;
using GestorPetshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

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

        [HttpPost]
        public ActionResult Modificar(Pedido pedidoModificado)
        {
            try
            {
                var i = 0;
                //context.Pedidos.Update(pedidoModificado);
                //context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Json(pedidoModificado);
        }

        [HttpPost]
        public ActionResult Insertar(string productos) 
        {
            if (string.IsNullOrEmpty(productos))
            {
                return Json("No se recibieron productos");
            }
            decimal total = 0;
            string[] array = productos.Split(',');
            Dictionary<string, string> keyValueDict = new Dictionary<string, string>();
            for (int i = 0; i < array.Length; i++)
            {
                string[] parts = array[i].Split('_');
                string key = parts[1];
                string value = parts[0];
                keyValueDict[key] = value;
            }
            foreach (var kvp in keyValueDict)
            {
                if (kvp.Value == "Juguete") 
                {
                    total = (decimal)total + (context.Juguetes.First(c => c.Id == Convert.ToInt32(kvp.Key)).Precio);
                }
                else 
                {
                    total = (decimal)total + (context.Comestibles.First(c => c.Id == Convert.ToInt32(kvp.Key)).Precio);
                }
                //Crear nuevo Pedido
                //Pedido pedidoNuevo = new Pedido();
                //pedidoNuevo.Total = total;
                //pedidoNuevo.Cliente = context.Clientes.Where(j => j.Id == 2).First(); //TODO: Fix getting Cliente
                //DateTime now = DateTime.Now;
                //pedidoNuevo.FechaCreacion = now;
                //context.Pedidos.Add(pedidoNuevo);
                //context.SaveChanges();
            }
            return Json(total);
        }
    }
}
