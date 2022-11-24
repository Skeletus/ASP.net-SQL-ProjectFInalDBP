using System;
using System.Collections.Generic;
#nullable disable
namespace MyLastBreath.Models
{
    public partial class Cursousuario
    {
        public int Idregistro { get; set; }
        public int? Idusuariox { get; set; }
        public int? Idcursox { get; set; }

        public virtual Curso IdcursoxNavigation { get; set; }
        public virtual Usuario IdusuarioxNavigation { get; set; }
    }
}
