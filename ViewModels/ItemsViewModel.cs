using Microsoft.AspNetCore.Mvc.Rendering;
using GestorPetshop.Models;

namespace GestorPetshop.ViewModels
{
    public class ItemsViewModel
    {
        public ItemsViewModel()
        {
            ListadoJuguetes = new List<Juguete>();
            ListadoComestibles = new List<Comestible>();
        }

        public List<Juguete> ListadoJuguetes { get; set; }
        public List<Comestible> ListadoComestibles { get; set; }
    }
}
