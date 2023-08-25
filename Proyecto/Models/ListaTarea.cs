using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class ListaTarea
{
    public int IdListaTarea { get; set; }

    public string NombreLista { get; set; } = null!;

    public int IdUsuario { get; set; }

    public DateTime? FechaAlta { get; set; }

    public DateTime? FecahTermino { get; set; }

    public DateTime? FechaLimite { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
