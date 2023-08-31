namespace Proyecto.ViewModels
{
    public class TareaViewModel
    {
        public string? Tarea1 { get; set; }

        public int IdListaTarea { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? FechaLimite { get; set; }

        public int? IdTareaPadre { get; set; }

        public bool? Terminada { get; set; }

        public DateTime? FechaAlta { get; set; }

        public DateTime? FechaTermino { get; set; }

        public int? Prioridad { get; set; }

    }
}
