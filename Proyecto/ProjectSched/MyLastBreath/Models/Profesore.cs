using System;
using System.Collections.Generic;

namespace MyLastBreath.Models
{
    public partial class Profesore
    {
        public Profesore()
        {
            Cursos = new HashSet<Curso>();
        }

        public int Idprofesor { get; set; }
        public string Name { get; set; } = null!;
        public string Apellido { get; set; } = null!;

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
