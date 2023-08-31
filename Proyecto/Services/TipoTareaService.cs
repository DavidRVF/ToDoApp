using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.ViewModels;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Proyecto.Services
{
    public class TipoTareaService
    {
        private readonly BdintroContext _bdintroContext;

        public TipoTareaService(BdintroContext bdintroContext)
        {
            _bdintroContext = bdintroContext;
        }

        public List<TipoTarea>listTipoTarea(int id)
        {
            var list = _bdintroContext.TipoTareas.Where(x => x.IdTipoTarea == id).Select(ID => new TipoTarea
            {
                TipoTarea1 = ID.TipoTarea1
            }).ToList();

            return list;
        }
        public GenericResponse<TipoTareaViewModel> AddTipoTarea(TipoTareaViewModel tarea)
        {
            GenericResponse<TipoTareaViewModel> response = new GenericResponse<TipoTareaViewModel>();
            if (tarea != null ) 
            {
                var entidad = new TipoTarea
                {
                    TipoTarea1 = tarea.TipoTarea1
                };

                var add = _bdintroContext.TipoTareas.Add(entidad);

                var addnew = _bdintroContext.SaveChanges();
                if (addnew == 1)
                {
                    response.estatus = 200;
                    response.idCreated = add.Entity.IdTipoTarea;
                }
            }
            else
            {
                response.mensaje = "error";
                response.estatus = 400;
            }
           

            return response;

        }
        public GenericResponse<TipoTareaViewModel> UpdateTipoTarea([FromBody] TipoTareaViewModel tarea, int id)
        {
            TipoTarea tareas = new TipoTarea();
            GenericResponse<TipoTareaViewModel> response = new GenericResponse<TipoTareaViewModel>();
            var contact = _bdintroContext.TipoTareas.Find(tareas.IdTipoTarea=id);
            if (contact != null)
            {
                contact.TipoTarea1 = tarea.TipoTarea1;
                var add = _bdintroContext.TipoTareas.Update(contact);

                var addnew = _bdintroContext.SaveChanges();
                if (addnew == 1)
                {
                    response.estatus = 200;
                    response.idUpdated = add.Entity.IdTipoTarea;
                }
            }
            else 
            {
                response.mensaje = "IdTipoTarea Invalida";
                response.estatus = 400;
            }


            return response;
        }
        public GenericResponse<TipoTareaViewModel> DeleteTipoTarea(int id)
        {
            TipoTarea tareas = new TipoTarea();
            GenericResponse<TipoTareaViewModel> response = new GenericResponse<TipoTareaViewModel>();
            var contact = _bdintroContext.TipoTareas.Find(tareas.IdTipoTarea=id);
            if (contact != null)
            {
                var add = _bdintroContext.TipoTareas.Remove(contact);

                var addnew = _bdintroContext.SaveChanges();
                if (addnew == 1)
                {
                    response.estatus = 200;
                    response.idDelete = add.Entity.IdTipoTarea;
                }
            }
            else
            {
                response.mensaje = "IdTipoTarea Invalida";
                response.estatus = 400;
            }

            

            return response;
        }
    }
}
