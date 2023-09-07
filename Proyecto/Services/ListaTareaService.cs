using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using Proyecto.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Proyecto.Services
{
    public class ListaTareaService
    {
        private readonly BdintroContext _bdintroContext;


        public ListaTareaService(BdintroContext bdintroContext)
        {
            _bdintroContext = bdintroContext;
        }
        public List<ListaTarea> BuscarLista(string buscar)
        {
            var filtrar = _bdintroContext.ListaTareas.Where(x => x.NombreLista.Contains(buscar)).OrderBy(x => x.NombreLista ).Select(Nombre => new ListaTarea
            {
                NombreLista = Nombre.NombreLista,
            }).ToList();
            return filtrar;
        }
        public List<ListaTarea> listListaTarea(int id, int idUs)
        {
           
            var list = _bdintroContext.ListaTareas.Where(x => x.IdUsuario == idUs || x.IdListaTarea == id).Select(ID => new ListaTarea
            {
                NombreLista = ID.NombreLista,
                FechaAlta = ID.FechaAlta,
                FechaTermino = ID.FechaTermino,
                FechaLimite = ID.FechaLimite

            }).ToList();

            return list;
        }
        public GenericResponse<ListaTareaViewModel> AddListaTarea(ListaTareaViewModel lista)
        {
            GenericResponse<ListaTareaViewModel> response = new GenericResponse<ListaTareaViewModel>();
            if (lista.IdUsuario == null || lista.IdUsuario == 0) 
            {
                response.mensaje = "IdUsuario invalida";
                response.estatus = 400;
            }
            else 
            {
               

                var entidad = new ListaTarea
                {
                    NombreLista = lista.NombreLista, 
                    IdUsuario = lista.IdUsuario,
                    FechaAlta = lista.FechaAlta,
                    FechaTermino = lista.FechaTermino,
                    FechaLimite = lista.FechaLimite
                   
                };
                if (entidad.FechaLimite == lista.FechaAlta)
                {
                    response.mensaje = "La fecha alta y la fecha limite no pueden ser iguales";   
                }
                else if (entidad.FechaLimite < lista.FechaAlta)
                {
                    response.mensaje = "la FechaLimite no puede ser antes de la FechaAlta";
                }
                else
                {

                    var add = _bdintroContext.ListaTareas.Add(entidad);

                    var addnew = _bdintroContext.SaveChanges();
                    if (addnew == 1)
                    {
                        response.estatus = 200;
                        response.idCreated = add.Entity.IdListaTarea;
                    }
                }    

            }
            return response;
        }
        public GenericResponse<UpdateListaTareaViewModel> UpdateListaTarea([FromBody] UpdateListaTareaViewModel lista, int id)
        {
            ListaTarea list = new ListaTarea();
            GenericResponse<UpdateListaTareaViewModel> response = new GenericResponse<UpdateListaTareaViewModel>();

            var contact = _bdintroContext.ListaTareas.Find(list.IdListaTarea = id);
            if (contact != null)
            {
                contact.NombreLista = lista.NombreLista;
                contact.FechaLimite = lista.FechaLimite;
                contact.FechaTermino = lista.FechaTermino;
                var add = _bdintroContext.ListaTareas.Update(contact);
                var addnew = _bdintroContext.SaveChanges();
                if (addnew == 1)
                {
                    response.estatus = 200;
                    response.idUpdated = add.Entity.IdListaTarea;
                }
            }
            else
            {
                response.mensaje = "IdListaTarea° invalida";
                response.estatus = 400;
            }

            return response;
        }
        public GenericResponse<UpdateListaTareaViewModel> UpdateFechaTermino([FromBody] UpdateListaTareaViewModel lista, int id)
        {
            ListaTarea list = new ListaTarea();
            GenericResponse<UpdateListaTareaViewModel> response = new GenericResponse<UpdateListaTareaViewModel>();
            var contact = _bdintroContext.ListaTareas.Find(list.IdListaTarea = id);
            if (contact != null)
            {
                contact.FechaTermino = lista.FechaTermino;
                var add = _bdintroContext.ListaTareas.Update(contact);
                var addnew = _bdintroContext.SaveChanges();
                if (addnew == 1)
                {
                    response.estatus = 200;
                    response.idUpdated = add.Entity.IdListaTarea;
                }
            }
            else
            {
                response.mensaje = "IdListaTarea° invalida";
                response.estatus = 400;
            }

            return response;
        }
        public GenericResponse<ListaTareaViewModel> DeleteListaTarea(int id)
        {
            ListaTarea list = new ListaTarea();
            GenericResponse<ListaTareaViewModel> response = new GenericResponse<ListaTareaViewModel>();
            var contact = _bdintroContext.ListaTareas.Find(list.IdListaTarea = id);
            if (contact != null)
            {
                var add = _bdintroContext.Remove(contact);
                var addNew = _bdintroContext.SaveChanges();

                if (addNew == 1)
                {
                    response.idDelete = add.Entity.IdListaTarea;
                    response.estatus = 200;
                }
            }
            else
            {
                response.mensaje = "Id invalida";
                response.estatus = 400;
            }
            return response;
        }
    }
}
