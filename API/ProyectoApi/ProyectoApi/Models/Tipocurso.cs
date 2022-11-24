using System;
using System.Collections.Generic;

namespace ProyectoApi.Models
{
    public partial class Tipocurso
    {
        public Tipocurso()
        {
            Cursos = new HashSet<Curso>();
        }

        public int IdtipoCurso { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
