using System;
using System.Collections.Generic;

namespace GestorPetshop.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public DateTime FechaCreacion { get; set; }

    public decimal Total { get; set; }

    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
