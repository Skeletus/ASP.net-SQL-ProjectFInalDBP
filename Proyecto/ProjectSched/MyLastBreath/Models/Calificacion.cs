using System;
using System.Collections.Generic;

namespace MyLastBreath.Models
{
    public partial class Calificacion
    {
        public Calificacion()
        {
            Cursos = new HashSet<Curso>();
        }

        public int Idcalificacion { get; set; }
        public string Nivel { get; set; } = null!;

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
