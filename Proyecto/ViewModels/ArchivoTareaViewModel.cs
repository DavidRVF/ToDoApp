using Proyecto.Models;

namespace Proyecto.ViewModels
{
    public class ArchivoTareaViewModel
    {

        public string UrlArchivo { get; set; } = null!;
        public int? IdTarea { get; set; }

        public DateTime? FechaAlta { get; set; }

    }
}
