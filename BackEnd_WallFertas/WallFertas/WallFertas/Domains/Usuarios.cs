using System;
using System.Collections.Generic;

#nullable disable

namespace WallFertas.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
