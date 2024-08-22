using System;
using System.Collections.Generic;

namespace GestorPetshop.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string? Email { get; set; }

    public string Direccion { get; set; } = null!;

    public int CodigoPostal { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
