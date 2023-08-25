using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Proyecto.Models;
using Proyecto.Services;
using Proyecto.ViewModels;

namespace Proyecto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
           _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult Listar(string? sexo) 
        { 
            var result = _usuarioService.listusuario(sexo);
            return Ok(result); 
        }
        [HttpPost]
        public ActionResult Guardar([FromBody] UsuarioViewModel usuario) 
        { 
            var result = _usuarioService.Addusuario(usuario);

            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Eliminar(int id)
        {
            var result = _usuarioService.Deleteusuario(id);

            return Ok(result);
        }
        [HttpPut]
        public ActionResult Editar(UpdateUsuarioViewModel usuario, int id)
        {
            var result = _usuarioService.Updateusuario(usuario, id);

            return Ok(result);
        }
    }
}
