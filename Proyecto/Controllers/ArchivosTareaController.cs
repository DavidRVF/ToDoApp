using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Services;
using Proyecto.ViewModels;

namespace Proyecto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArchivosTareaController : ControllerBase
    {
        private readonly ArchivosTareaService _ArchivosTareaService;

        public ArchivosTareaController(ArchivosTareaService archivosTareaService)
        {
            _ArchivosTareaService = archivosTareaService;
        }

        [HttpGet]
        public ActionResult Listar(int id, int idTarea)
        {
            try
            {
               var result = _ArchivosTareaService.listArchivoTarea(id, idTarea);
               return Ok(result);                
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost]
        public ActionResult Guardar([FromBody] ArchivoTareaViewModel Tarea)
        {
            try
            {
                var result = _ArchivosTareaService.AddArchivosTarea(Tarea);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public ActionResult Eliminar(int id)
        {
            try
            {
                var result = _ArchivosTareaService.DeleteArchivosTarea(id);

                return Ok(result);
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
            
        }
        [HttpPut]
        public ActionResult Editar(ArchivoTareaViewModel Archivo, int id)
        {
            try
            {
                var result = _ArchivosTareaService.UpdateArchivosTarea(Archivo, id);
              
                return Ok(result);


            }
            catch(Exception ex ) { return BadRequest(ex.Message); }
         
        }
    }
}
