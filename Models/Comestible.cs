using System;
using System.Collections.Generic;

namespace GestorPetshop.Models;

public partial class Comestible
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Tipo { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }
}
