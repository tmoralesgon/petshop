using GestorPetshop.Models;

namespace GestorPetshop.ViewModels
{

    public class JuguetesViewModel
    {
        public JuguetesViewModel() 
        {
            ListadoJuguetes = new List<Juguete>();
        }

        public List<Juguete> ListadoJuguetes { get; set; }
    }
}
