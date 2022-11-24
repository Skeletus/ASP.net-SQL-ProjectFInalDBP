using System;
using System.Collections.Generic;

namespace MyLastBreath.Models
{
    public partial class Disponibilidadcurso
    {
        public Disponibilidadcurso()
        {
            Cursos = new HashSet<Curso>();
        }

        public int Iddisponibilidad { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
