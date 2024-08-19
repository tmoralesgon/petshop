using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorPetshop.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }

    public string? Email { get; set; }

    public string Direccion { get; set; } = null!;

    public int CodigoPostal { get; set; }
}
