using Azure.Core;
using GestorPetshop.Models;
using GestorPetshop.ViewModels;
using GestorPetshop.Repositories;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Xml.Linq;
using System.Xml.Serialization;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Security.Claims;

public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;

    private GestorPetshopContext context;

    public ClienteController(ILogger<ClienteController> logger)
    {
        _logger = logger;

        context = new GestorPetshopContext();
    }
    [HttpGet]
    public IActionResult Index()
    {
        //Cliente newCliente = new Cliente();
        //ClientesViewModel vm = new ClientesViewModel();
        //vm.ListadoClientes = ClienteRepository.GetClientes();
        return View(/*vm*/);

        //return View();
    }

    [HttpPost]
    public IActionResult Index(Cliente cliente)
    {
        //Cliente newCliente = new Cliente();
        //newCliente.Nombre = cliente.Nombre;
        //newCliente.Apellido = cliente.Apellido;
        //newCliente.FechaNacimiento = cliente.FechaNacimiento;
        //newCliente.Email = cliente.Email;
        //newCliente.Direccion = cliente.Direccion;
        //newCliente.CodigoPostal = cliente.CodigoPostal;

        //context.Clientes.Add(cliente);

        //try 
        //{
        //    context.SaveChanges();
        //}
        //catch(Exception ex) 
        //{
        //    var i = 0;
        //}

        return View(/*cliente*/);
    }
    public async Task<IActionResult> Clientes_Read([DataSourceRequest] DataSourceRequest request)
    {
        var clientesList = ClienteRepository.GetClientes();

        return Json(await clientesList.ToDataSourceResultAsync(request));

    }

    [HttpPost]
    public IActionResult FileUpload(IFormFile file)
    {
        var serializer = new XmlSerializer(typeof(Cliente));
        var cliente = serializer.Deserialize(file.OpenReadStream()) as Cliente;
        DateFormat dateFormat = new DateFormat();
        cliente.FechaNacimiento = cliente.FechaNacimiento;

        //var clientes = context.Clientes.Where(c => c.Nombre == "Pere").FirstOrDefault(); Ejemplo CON lambda expression

        //var clientes2 = (from c in context.Clientes where c.Nombre == "Pere" select c).FirstOrDefault(); Ejemplo SIN lambda expression

        //XDocument

        //return Json(new { Result = "true" });

        return View("Index", cliente);
    } 
}