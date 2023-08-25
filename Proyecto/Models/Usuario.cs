using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string Usuario1 { get; set; } = null!;

    public byte[] Contraseña { get; set; } = null!;

    public DateTime FechaAlta { get; set; }

    public virtual ICollection<ListaTarea> ListaTareas { get; set; } = new List<ListaTarea>();
}
