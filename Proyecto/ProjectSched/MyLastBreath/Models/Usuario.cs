using System;
using System.Collections.Generic;

namespace MyLastBreath.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cursousuarios = new HashSet<Cursousuario>();
        }

        public int Iduser { get; set; }
        public string Nickname { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Cursousuario> Cursousuarios { get; set; }
    }
}
