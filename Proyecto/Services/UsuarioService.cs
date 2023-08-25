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
        public UsuarioViewModel Addusuario(UsuarioViewModel usuario)
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

            _bdintroContext.Usuarios.Add(entidad);

            _bdintroContext.SaveChanges();

            return usuario;
        
        }
        public UpdateUsuarioViewModel Updateusuario([FromBody]UpdateUsuarioViewModel usuario, int id)
        {
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
            }

            _bdintroContext.Usuarios.Update(contact);

            _bdintroContext.SaveChanges();

            return usuario;
        }
        public int Deleteusuario( int id)
        {
            var contact = _bdintroContext.Usuarios.Find(id);
            _bdintroContext.Usuarios.Remove(contact);

            _bdintroContext.SaveChanges();
        
            return id;
        }
    }
}
