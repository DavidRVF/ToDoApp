using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.ViewModels;
using System.Threading;

namespace Proyecto.Services
{
    public class TareaService
    {
        private readonly BdintroContext _bdintroContext;

        public TareaService(BdintroContext bdintroContext)
        {
            _bdintroContext = bdintroContext;
        }

        public List<Tarea> ListTarea(int id, int idlist, int idPadre)
        {
            var list = _bdintroContext.Tareas.Where(x => x.IdTarea == id || x.IdListaTarea == idlist || x.IdTareaPadre == idPadre).Select(ID => new Tarea
            {
                IdTarea = ID.IdTarea,
                IdListaTarea = ID.IdListaTarea,
                Tarea1 = ID.Tarea1,
                Descripcion = ID.Descripcion,
                FechaLimite = ID.FechaLimite,
                IdTareaPadre = ID.IdTareaPadre,
                Terminada = ID.Terminada,
                FechaAlta = ID.FechaAlta,
                FechaTermino = ID.FechaTermino,
                Prioridad = ID.Prioridad,

            }).ToList();

            return list;
        }
        public GenericResponse<TareaViewModel> AddTarea(TareaViewModel tarea)
        {
            GenericResponse<TareaViewModel> response = new GenericResponse<TareaViewModel>();   
            if(tarea.IdListaTarea == null || tarea.IdListaTarea == 0) 
            {
                response.mensaje = "IdListaTarea invalida";
                response.estatus = 400;
            }
            else
            {
                var entidad = new Tarea
                {
                    IdListaTarea = tarea.IdListaTarea,
                    Tarea1 = tarea.Tarea1,
                    Descripcion = tarea.Descripcion,
                    FechaLimite = tarea.FechaLimite,
                    IdTareaPadre = tarea.IdTareaPadre,
                    Terminada = tarea.Terminada,
                    FechaAlta = tarea.FechaAlta,
                    FechaTermino = tarea.FechaTermino,
                    Prioridad = tarea.Prioridad
                };
                if (entidad.FechaLimite < tarea.FechaAlta) 
                {
                    response.mensaje = "la FechaLimite no puede ser antes de la FechaAlta";
                }
                else if(entidad.FechaLimite == tarea.FechaAlta)
                {
                    response.mensaje = "La fecha alta y la fecha limite no pueden ser iguales";
                }
                else 
                {
                    var add = _bdintroContext.Tareas.Add(entidad);

                    var addnew = _bdintroContext.SaveChanges();
                    if (addnew == 1)
                    {
                        response.estatus = 200;
                        response.idCreated = add.Entity.IdTarea;
                    }
                }

               
            }


            return response;

        }
        public GenericResponse<UpdateTareaViewModel> UpdateTarea([FromBody] UpdateTareaViewModel tarea, int id)
        {
            Tarea tareas = new Tarea();
            GenericResponse<UpdateTareaViewModel> response = new GenericResponse<UpdateTareaViewModel>();
            var contact = _bdintroContext.Tareas.Find(tareas.IdTarea = id);
            if (contact != null)
            {
                contact.Tarea1 = tarea.Tarea1;
                contact.Descripcion = tarea.Descripcion;
                contact.FechaLimite = tarea.FechaLimite;
                contact.Prioridad = tarea.Prioridad;
                var add = _bdintroContext.Tareas.Update(contact);

                var addnew = _bdintroContext.SaveChanges();
                if (addnew == 1)
                {
                    response.estatus = 200;
                    response.idUpdated = add.Entity.IdTarea;
                }

            }
            else
            {
                response.mensaje = "IdTarea invalida";
                response.estatus = 400;
            }

     

            return response;
        }
        public GenericResponse<TareaViewModel> DeleteTarea(int id)
        {
            Tarea tarea = new Tarea();
            GenericResponse<TareaViewModel> response = new GenericResponse<TareaViewModel>();
            var contact = _bdintroContext.Tareas.Find(tarea.IdTarea = id);
            if (contact != null)
            {
                var add = _bdintroContext.Tareas.Remove(contact);

                var addnew = _bdintroContext.SaveChanges();
                if (addnew == 1)
                {
                    response.estatus = 200;
                    response.idDelete = add.Entity.IdTarea;
                }
            }
            else
            {
                response.mensaje = "IdTarea invalida";
                response.estatus = 400;
            }


            return response;
        }
    }
}
