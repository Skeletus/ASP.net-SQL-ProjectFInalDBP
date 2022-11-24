using MyLastBreath.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace MyLastBreath.Helpers
{
    public static class JSONListHelper
    {
        private static readonly bddefinitivaContext _context;
        public static string GetEventListJSONString(List<Models.Curso> events)
        {
            List<Event> eventList = new List<Event>();
            foreach (var model in events)
            {
                Event myevent = new Event()
                {
                    Id = model.Idcurso,
                    description = model.NombreCurso,
                    start = model.FechaInicio,
                    end = model.FechaFin,
                    title = model.NombreCurso
                    //idprofesor = model.ProfesorAsignado
                };
                eventList.Add(myevent);
            }
            return System.Text.Json.JsonSerializer.Serialize(eventList);
        }

        public static string GetEventJSONString(List<Models.Curso> events, int? idcurso)
        {
            List<Event> eventList = new List<Event>();
            foreach (var model in events)
            {
                if(model.Idcurso == idcurso)
                {
                    Event myevent = new Event()
                    {
                        Id = model.Idcurso,
                        description = model.NombreCurso,
                        start = model.FechaInicio,
                        end = model.FechaFin,
                        title = model.NombreCurso
                        //idprofesor = model.ProfesorAsignado
                    };
                    eventList.Add(myevent);
                }
                
            }
            return System.Text.Json.JsonSerializer.Serialize(eventList);
        }

        public static string GetListadoCursosString(List<Models.Cursousuario> cursosUsuarios, Models.Usuario userx)
        {
            List<Models.Cursousuario> cursosUsuarioList = new List<Models.Cursousuario>();
            foreach (var model in cursosUsuarios)
            {
                var ObjEncontrado =
                    (from TCursoUsuario in _context.Cursousuarios
                     where TCursoUsuario.Idusuariox == userx.Iduser
                     select TCursoUsuario).FirstOrDefault();
                cursosUsuarioList.Add(ObjEncontrado);
            }
            return System.Text.Json.JsonSerializer.Serialize(cursosUsuarioList);
        }
    }

    public class Event
    {
        public int Id { get; set; } 
        public string description { get; set; }
        //public int idprofesor { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string title { get; set; }
    }

}
