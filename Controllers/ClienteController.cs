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
        return View();
    }
    public async Task<IActionResult> Clientes_Read([DataSourceRequest] DataSourceRequest request)
    {
        var clientesList = ClienteRepository.GetClientes();

        return Json(await clientesList.ToDataSourceResultAsync(request));

    }

    [HttpGet]
    public IActionResult Ficha(int clienteId)
    {
        var cliente = new Cliente();
        try
        {
            if (clienteId != 0)
            {
                //ViewBag.pedidos = PedidoRepository.GetPedidos(token);
                cliente = ClienteRepository.GetCliente(clienteId);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ha habido un error: '{e}'");
        }

        return View(cliente);
    }

    [HttpPost]
    public IActionResult FileUpload(IFormFile file)
    {
        var serializer = new XmlSerializer(typeof(Cliente));
        var cliente = serializer.Deserialize(file.OpenReadStream()) as Cliente;
        DateFormat dateFormat = new DateFormat();
        cliente.FechaNacimiento = cliente.FechaNacimiento;

        return View("Index", cliente);
    } 
}