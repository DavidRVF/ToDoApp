namespace Proyecto.ViewModels
{
    public class UpdateListaTareaViewModel
    {
        public int IdListaTarea { get; set; }
        public string NombreLista { get; set; } = null!;

        public DateTime? FechaLimite { get; set; }
    }
}
