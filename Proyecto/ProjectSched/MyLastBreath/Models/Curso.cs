using System;
using System.Collections.Generic;
#nullable disable
namespace MyLastBreath.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Cursousuarios = new HashSet<Cursousuario>();
        }

        public int Idcurso { get; set; }
        public int ProfesorAsignado { get; set; }
        public string NombreCurso { get; set; }
        public int Area { get; set; }
        public int Disponibilidad { get; set; }
        public int Dificultad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Tipocurso AreaNavigation { get; set; }
        public virtual Calificacion DificultadNavigation { get; set; }
        public virtual Disponibilidadcurso DisponibilidadNavigation { get; set; }
        public virtual Profesore ProfesorAsignadoNavigation { get; set; }
        public virtual ICollection<Cursousuario> Cursousuarios { get; set; }
    }
}
