using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Services;
using Proyecto.ViewModels;

namespace Proyecto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ListaTareaController : ControllerBase
    {
        private readonly ListaTareaService _ListaTareaService;

        public ListaTareaController(ListaTareaService listaTareaService)
        {
            _ListaTareaService = listaTareaService;
        }

        [HttpGet]
        public ActionResult Listar(int IdUs, string nombre)
        {
            try
            {
                var result = _ListaTareaService.listListaTarea(IdUs, nombre);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
     
        }

        [HttpGet("Buscar")]
        public ActionResult BuscarListaTarea(int id)
        {
            try
            {
                var result = _ListaTareaService.DetalleListaTarea(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public ActionResult Guardar([FromBody] ListaTareaViewModel Lista)
        {
            try
            {
                var result = _ListaTareaService.AddListaTarea(Lista);

                return Ok(result);
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
          
        }
        [HttpDelete]
        public ActionResult Eliminar(int id)
        {
            try
            {
                var result = _ListaTareaService.DeleteListaTarea(id);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
         
        }
        [HttpPut]
        public ActionResult Editar(UpdateListaTareaViewModel Lista, int id)
        {
            try {
                var result = _ListaTareaService.UpdateListaTarea(Lista, id);

                return Ok(result);
            }
            catch(Exception ex) {return BadRequest(ex.Message); }
            
        }
        [HttpPut("FechaTermino")]
        public ActionResult EditarFechaTermino(UpdateFechaTerminoListaTareaViewModel Lista, int id)
        {
            try
            {
                var result = _ListaTareaService.UpdateFechaTermino(Lista, id);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
