using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Services;
using Proyecto.ViewModels;

namespace Proyecto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly TareaService _TareaService;

        public TareaController(TareaService TareaService)
        {
            _TareaService = TareaService;
        }

        [HttpGet]
        public ActionResult Listar(int idlist, int idPadre, string tarea)
        {
            try
            {
                var result = _TareaService.ListTarea(idlist, idPadre, tarea);
                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

         
        }
        [HttpGet("Tarea")]
        public ActionResult DetallesTarea(int id)
        {
            try
            {
                var result = _TareaService.DetalleTarea(id);
                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }


        }
        [HttpPost]
        public ActionResult Guardar([FromBody] TareaViewModel Tarea)
        {
            try
            {
                var result = _TareaService.AddTarea(Tarea);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            
        }
        [HttpDelete]
        public ActionResult Eliminar(int id)
        {
            try
            {
                var result = _TareaService.DeleteTarea(id);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            
        }
        [HttpPut]
        public ActionResult Editar(UpdateTareaViewModel tarea, int id)
        {
            try
            {
                var result = _TareaService.UpdateTarea(tarea, id);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            
        }
    }
}
