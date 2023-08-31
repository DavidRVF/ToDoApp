using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class ArchivosTarea
{
    public int IdArchivo { get; set; }

    public string UrlArchivo { get; set; } = null!;

    public DateTime? FechaAlta { get; set; }

    public int? IdTarea { get; set; }

    public virtual Tarea? IdTareaNavigation { get; set; }
}
