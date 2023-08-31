using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Services;
using Proyecto.ViewModels;

namespace Proyecto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipoTareaController : ControllerBase
    {
        private readonly TipoTareaService _TipoTareaService;

        public TipoTareaController(TipoTareaService TipoTareaService)
        {
            _TipoTareaService = TipoTareaService;
        }

        [HttpGet]
        public ActionResult Listar(int id)
        {
            try
            {
                var result = _TipoTareaService.listTipoTarea(id);
                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
           
        }
        [HttpPost]
        public ActionResult Guardar([FromBody] TipoTareaViewModel Tarea)
        {
            try
            {
                var result = _TipoTareaService.AddTipoTarea(Tarea);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
        [HttpDelete]
        public ActionResult Eliminar(int id)
        {
            try
            {
                var result = _TipoTareaService.DeleteTipoTarea(id);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
           
        }
        [HttpPut]
        public ActionResult Editar(TipoTareaViewModel tarea, int id)
        {
            try
            {
                var result = _TipoTareaService.UpdateTipoTarea(tarea, id);

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
