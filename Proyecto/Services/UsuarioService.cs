using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using Proyecto.ViewModels;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Proyecto.Services
{
    public class UsuarioService
    {
        private readonly BdintroContext _bdintroContext;

        public UsuarioService(BdintroContext bdintroContext)
        {
            _bdintroContext = bdintroContext;
        }

        public List<Usuario> listusuario(string sexo)
        {
            Expression<Func<Usuario, bool>> query;

            if (string.IsNullOrEmpty(sexo))
                query = usuario => usuario.Sexo != sexo;
            else
                query = usuario => usuario.Sexo == sexo.ToUpper();

            var list = _bdintroContext.Usuarios.Where(query).Select(usuario => new Usuario
            {
                Id = usuario.Id,
                NombreCompleto = usuario.NombreCompleto,
                Sexo = usuario.Sexo,
                Usuario1 = usuario.Usuario1,
                FechaAlta = usuario.FechaAlta
            }).ToList();

            return list;
        }
        public GenericResponse<UsuarioViewModel> Addusuario(UsuarioViewModel usuario)
        {
            GenericResponse<UsuarioViewModel> response = new GenericResponse<UsuarioViewModel>();
            if (usuario != null) 
            {
                var entidad = new Usuario
                {

                    NombreCompleto = usuario.NombreCompleto,
                    FechaAlta = usuario.FechaAlta,
                    Sexo = usuario.Sexo.ToUpper(),
                    Usuario1 = usuario.Usuario1
                };

                using (var hash = new HMACSHA512())
                {
                    entidad.Contraseña = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(usuario.Contraseña));
                }

                var add = _bdintroContext.Usuarios.Add(entidad);

                var addnew = _bdintroContext.SaveChanges();
                if (addnew == 1)
                {
                    response.estatus = 200;
                    response.idCreated = add.Entity.Id;
                }
            }
            else 
            {
                response.mensaje = "error";
                response.estatus = 400;
            }

            return response;
        
        }
        public GenericResponse<UpdateUsuarioViewModel>  Updateusuario([FromBody]UpdateUsuarioViewModel usuario, int id)
        {
            GenericResponse<UpdateUsuarioViewModel> response = new GenericResponse<UpdateUsuarioViewModel>();
            var contact = _bdintroContext.Usuarios.Find(id);
            if (contact != null)
            {
                contact.Usuario1 = usuario.Usuario1;
                contact.NombreCompleto = usuario.NombreCompleto;
                contact.Sexo = usuario.Sexo;
                using (var hash = new HMACSHA512())
                {
                    contact.Contraseña = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(usuario.Contraseña));
                }
                var add = _bdintroContext.Usuarios.Update(contact);


                var addnew = _bdintroContext.SaveChanges();
                if (addnew == 1)
                {
                    response.estatus = 200;
                    response.idUpdated = add.Entity.Id;
                }
            }
            else
            {
                response.mensaje = "id invalido";
                response.estatus = 400;
            }

        

            return response;
        }
        public GenericResponse<UsuarioViewModel> Deleteusuario( int id)
        {
            GenericResponse<UsuarioViewModel> response = new GenericResponse<UsuarioViewModel>();
            var contact = _bdintroContext.Usuarios.Find(id);
            if (contact != null) 
            {
               
               var add = _bdintroContext.Usuarios.Remove(contact);

                var addnew = _bdintroContext.SaveChanges();
                if (addnew == 1)
                {
                    response.estatus = 200;
                    response.idDelete = add.Entity.Id;
                }
            }else
            {
                response.mensaje = "Id invalido";
                response.estatus = 400;
            }
      
        
            return response;
        }
    }
}
