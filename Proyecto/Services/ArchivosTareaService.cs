using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using Proyecto.ViewModels;
using System.Collections.Generic;

namespace Proyecto.Services
{
    public class ArchivosTareaService
    {
        private readonly BdintroContext _bdintroContext;

        public ArchivosTareaService(BdintroContext bdintroContext)
        {
            _bdintroContext = bdintroContext;
        }

        public List<ArchivosTarea> listArchivoTarea(int id, int idArc)
        {
            GenericResponse<ArchivosTarea> response = new GenericResponse<ArchivosTarea>();

            var listid = _bdintroContext.ArchivosTareas.Where(x => x.IdTarea == idArc || x.IdArchivo == id).Select(ID => new ArchivosTarea
            {

                IdArchivo = ID.IdArchivo,
                UrlArchivo = ID.UrlArchivo,
                FechaAlta = ID.FechaAlta,
                IdTarea = ID.IdTarea,

            }).ToList();


            return listid;

        }
        public GenericResponse<ArchivoTareaViewModel> AddArchivosTarea(ArchivoTareaViewModel archivo)
        {
            GenericResponse<ArchivoTareaViewModel> response = new GenericResponse<ArchivoTareaViewModel>();

            if (archivo.IdTarea == null || archivo.IdTarea == 0)
            {
                response.mensaje = "IdTarea invalida";
                response.estatus = 400;
            }
            else
            {
                var entidad = new ArchivosTarea
                {
                    UrlArchivo = archivo.UrlArchivo,
                    FechaAlta = archivo.FechaAlta,
                    IdTarea = archivo.IdTarea, 
                };

                var add = _bdintroContext.ArchivosTareas.Add(entidad);

                var addNew = _bdintroContext.SaveChanges();

                if(addNew == 1)
                {
                    response.estatus = 200;
                    response.idCreated = add.Entity.IdArchivo;
                }
            }

            return response;

        }
        public GenericResponse<ArchivoTareaViewModel> UpdateArchivosTarea([FromBody] ArchivoTareaViewModel archivos, int id)
        {
            ArchivosTarea arch = new ArchivosTarea();
            GenericResponse<ArchivoTareaViewModel> response = new GenericResponse<ArchivoTareaViewModel>();
            var contact = _bdintroContext.ArchivosTareas.Find(arch.IdArchivo = id);
            if (contact == null )
            {
                response.mensaje = "Id invalida";
                response.estatus = 400;

            }
            else
            {
                contact.UrlArchivo = archivos.UrlArchivo;
                contact.FechaAlta = archivos.FechaAlta;

                var add = _bdintroContext.ArchivosTareas.Update(contact);

                var addNew = _bdintroContext.SaveChanges();

                if (addNew == 1)
                {
                    response.estatus = 200;
                    response.idUpdated = add.Entity.IdArchivo;
                }
            }

            return response;
        }
        public GenericResponse<ArchivoTareaViewModel> DeleteArchivosTarea(int id)
        {
            ArchivosTarea arch = new ArchivosTarea();
            GenericResponse<ArchivoTareaViewModel> response = new GenericResponse<ArchivoTareaViewModel>();
            var contact = _bdintroContext.ArchivosTareas.Find(arch.IdArchivo = id);
            if (contact != null  )
            {
                var add = _bdintroContext.Remove(contact);
                var addNew = _bdintroContext.SaveChanges();

                if (addNew == 1)
                {
                    response.estatus = 200;
                    response.idDelete = add.Entity.IdArchivo;
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
