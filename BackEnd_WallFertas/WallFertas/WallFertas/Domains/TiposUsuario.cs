using System;
using System.Collections.Generic;

#nullable disable

namespace WallFertas.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoUsuario { get; set; }
        public string TituloTipoUsuario { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
