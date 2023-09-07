namespace Proyecto.ViewModels
{
    public class UpdateListaTareaViewModel
    {
        public string NombreLista { get; set; } = null!;

        public DateTime? FechaTermino { get; set; }

        public DateTime? FechaLimite { get; set; }
    }
}
