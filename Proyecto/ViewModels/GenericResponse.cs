namespace Proyecto.ViewModels
{
    public class GenericResponse<T> where T : class
    {
        public T entidad { get; set; }
        public int estatus { get; set; }
        public string mensaje { get; set; }
        public int idCreated { get; set; }
        public int idUpdated { get; set; }
        public int idDelete { get; set; }
    }
}
