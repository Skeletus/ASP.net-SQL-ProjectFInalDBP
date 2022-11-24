using System;
using System.Collections.Generic;

namespace ProyectoApi.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Cursousuarios = new HashSet<Cursousuario>();
        }

        public int Idcurso { get; set; }
        public int ProfesorAsignado { get; set; }
        public string NombreCurso { get; set; } = null!;
        public int Area { get; set; }
        public int Disponibilidad { get; set; }
        public int Dificultad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Tipocurso AreaNavigation { get; set; } = null!;
        public virtual Calificacion DificultadNavigation { get; set; } = null!;
        public virtual Disponibilidadcurso DisponibilidadNavigation { get; set; } = null!;
        public virtual Profesore ProfesorAsignadoNavigation { get; set; } = null!;
        public virtual ICollection<Cursousuario> Cursousuarios { get; set; }
    }
}
