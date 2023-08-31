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
        public ActionResult Listar(int id, int IdUs)
        {
            try
            {
                var result = _ListaTareaService.listListaTarea(id, IdUs);
                return Ok(result);
            }
            catch(Exception ex)
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
        public ActionResult Editar(ListaTareaViewModel Lista, int id)
        {
            try {
                var result = _ListaTareaService.UpdateListaTarea(Lista, id);

                return Ok(result);
            }
            catch(Exception ex) {return BadRequest(ex.Message); }
            
        }
    }
}
