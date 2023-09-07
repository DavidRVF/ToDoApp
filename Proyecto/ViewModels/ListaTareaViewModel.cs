

namespace Proyecto.ViewModels
{
    public class ListaTareaViewModel
    {
        public string NombreLista { get; set; } = null!;
        public int IdUsuario { get; set; }
        public DateTime? FechaAlta { get; set; }

        public DateTime? FechaTermino { get; set; }

        public DateTime? FechaLimite { get; set; }
    }
}
