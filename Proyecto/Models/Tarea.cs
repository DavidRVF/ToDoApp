using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public int? IdListaTarea { get; set; }

    public string? Tarea1 { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaLimite { get; set; }

    public int? IdTareaPadre { get; set; }

    public bool? Terminada { get; set; }

    public DateTime? FechaAlta { get; set; }

    public DateTime? FechaTermino { get; set; }

    public int? Prioridad { get; set; }

    public virtual ICollection<ArchivosTarea> ArchivosTareas { get; set; } = new List<ArchivosTarea>();

    public virtual ListaTarea? IdListaTareaNavigation { get; set; }

    public virtual Tarea? IdTareaPadreNavigation { get; set; }

    public virtual ICollection<Tarea> InverseIdTareaPadreNavigation { get; set; } = new List<Tarea>();
}
