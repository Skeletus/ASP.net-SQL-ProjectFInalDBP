using System;
using System.Collections.Generic;

namespace ProyectoApi.Models
{
    public partial class Cursousuario
    {
        public int Idregistro { get; set; }
        public int Idusuariox { get; set; }
        public int Idcursox { get; set; }

        public virtual Curso IdcursoxNavigation { get; set; } = null!;
        public virtual Usuario IdusuarioxNavigation { get; set; } = null!;
    }
}
