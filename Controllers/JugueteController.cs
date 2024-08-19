using GestorPetshop.Models;
using GestorPetshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GestorPetshop.Controllers
{
    public class JugueteController : Controller
    {
        private readonly ILogger<JugueteController> _logger;

        private GestorPetshopContext context;
        private readonly Dictionary<int, string> jugueteType;

        public JugueteController(ILogger<JugueteController> logger)
        {
            _logger = logger;

            context = new GestorPetshopContext();
            jugueteType = new Dictionary<int, string>();
        }
        [HttpGet]
        public IActionResult Index()
        {
            fillDictionary();
            JuguetesViewModel vm = new JuguetesViewModel();
            //vm.ListadoJuguetes = new List<Juguete> { new Juguete() };
            vm.ListadoJuguetes = context.Juguetes.ToList();

            return View(vm);
        }

        //[HttpPost]
        //public ActionResult Insertar(string title,decimal precio,int stock)
        //{
        //    return Json("Se ha insertado");
        //}

        [HttpPost]
        public ActionResult Insertar(Juguete jugueteInsertado)
        {
            try 
            {
                //Juguete newJ = new Juguete();
                //newJ.Title = jugueteInsertado.Title;
                //newJ.Precio = jugueteInsertado.Precio;
                //newJ.Stock = jugueteInsertado.Stock;


                context.Juguetes.Add(jugueteInsertado);
                context.SaveChanges();
            } 
            catch (Exception ex) 
            {
                
            }

            return Json(jugueteInsertado);
        }

        [HttpPost]
        public ActionResult Modificar(Juguete jugueteModificado)
        {
            try 
            { 
                context.Juguetes.Update(jugueteModificado);
                context.SaveChanges();
            } 
            catch (Exception ex) 
            { 

            }
            return Json(jugueteModificado);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try 
            {
                var test = context.Clientes.Where(c => c.Nombre == "Patata").Where(c => c.Nombre == "Patata").FirstOrDefault();


                var juguete = context.Juguetes.Where(j => j.Id == id).FirstOrDefault();
                context.Juguetes.Remove(juguete);
                context.SaveChanges();
            } 
            catch (Exception ex)
            { 

            }
            return Json("Se ha eliminado");
        }

        private void fillDictionary() 
        {
            jugueteType.Add(1,"Perro pequeño");
            jugueteType.Add(2, "Perro mediano");
            jugueteType.Add(3, "Perro grande");
        }
    }
}
