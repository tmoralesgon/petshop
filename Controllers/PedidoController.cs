using GestorPetshop.Models;
using GestorPetshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Telerik.SvgIcons;

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
            PedidosViewModel vm = new PedidosViewModel();
            vm.ListadoPedidos = context.Pedidos.ToList();
            return View(vm);
        }

        [HttpGet]
        public IActionResult Ficha()
        {
            ItemsViewModel vm = new ItemsViewModel();
            vm.ListadoJuguetes = context.Juguetes.ToList();
            vm.ListadoComestibles = context.Comestibles.ToList();
            return View(vm);
        }

        //[HttpPost]
        //public ActionResult Modificar(Pedido pedidoModificado)
        //{
        //    try
        //    {
        //        var i = 0;
        //        context.Pedidos.Update(pedidoModificado);
        //        context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return Json(pedidoModificado);
        //}

        [HttpPost]
        public ActionResult Calcular(string productos, string oferta) 
        {
            if (string.IsNullOrEmpty(productos))
            {
                return Json("0");
            }
            decimal total = 0;
            int of = Convert.ToInt32(oferta);
            string[] array = productos.Split(',');
            Dictionary<string, string> keyValueDict = new Dictionary<string, string>();
            for (int i = 0; i < array.Length; i++)
            {
                string[] parts = array[i].Split('_');
                string value = parts[0];
                string key = parts[1] + value[0];
                keyValueDict.Add(key, value);
            }
            foreach (var kvp in keyValueDict)
            {
                var newKey = kvp.Key.Substring(0, kvp.Key.Length - 1);
                if (kvp.Value == "Juguete") 
                {
                    total = (decimal)total + (context.Juguetes.First(c => c.Id == Convert.ToInt32(newKey)).Precio);
                }
                else 
                {
                    total = (decimal)total + (context.Comestibles.First(c => c.Id == Convert.ToInt32(newKey)).Precio);
                }
            }
            if (of > 0) 
            {
                var descuento = total * of / 100;
                total = total - descuento;
            }
            return Json(total);
        }

        [HttpPost]
        public ActionResult Insertar(decimal total)
        {
            if (total <= 0) {
                throw new Exception("No hay elementos seleccionados!");
            }
            Pedido pedidoNuevo = new Pedido();
            pedidoNuevo.Total = total;
            pedidoNuevo.Cliente = context.Clientes.Where(j => j.Id == 2).First(); //TODO: Fix getting Cliente
            DateTime now = DateTime.Now;
            pedidoNuevo.FechaCreacion = now;
            context.Pedidos.Add(pedidoNuevo);
            context.SaveChanges();

            return Json(pedidoNuevo);
        }
    }
}
