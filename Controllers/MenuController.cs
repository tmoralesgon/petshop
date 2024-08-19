//using GestorPetshop.Models;
using GestorPetshop.Models;
using GestorPetshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.WebSockets;

namespace GestorPetshop.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;

        private GestorPetshopContext context;

        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;

            context = new GestorPetshopContext();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(string title)
        //{
        //    return View();
        //}

        public IActionResult Comestibles()
        {
            ViewBag.tituloDeLacaja = "titulo de la caja";
            /* Select linq */
            //var listadoJuguetes = context.Juguetes.ToList();
            //var huesito = context.Juguetes.Where(j => j.Title == "Huesito").FirstOrDefault();

            /* Update linq */
            //var pelota = context.Juguetes.Where(j => j.Title == "Pelota").FirstOrDefault();
            //pelota.Precio = (decimal)45.56;
            //context.Juguetes.Update(pelota);
            //context.SaveChanges();
            //context.Juguetes.UpdateRange(listadoJuguetes);
            //context.SaveChangesAsync();

            /* delete linq */
            //context.Juguetes.Remove(pelota);

            /* insert linq */
            //Juguete nuevoJuguete = new Juguete("Palito",(decimal)0.87,5);
            //context.Juguetes.Add(nuevoJuguete);

            /* guarda todos las acciones de linq con Juguete */
            //context.SaveChanges();


            //try 
            //{

            //}
            //catch (Exception ex) 
            //{

            //}

            JuguetesViewModel vm = new JuguetesViewModel();
            vm.ListadoJuguetes = new List<Juguete> { new Juguete() };


            ViewBag.cosas = "hola";

            return View(vm);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{

        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
