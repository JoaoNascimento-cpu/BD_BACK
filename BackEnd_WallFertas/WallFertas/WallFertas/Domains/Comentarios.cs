using System;
using System.Collections.Generic;

#nullable disable

namespace WallFertas.Domains
{
    public partial class Comentarios
    {
        public int IdComentario { get; set; }
        public int? IdProduto { get; set; }
        public string Descricao { get; set; }

        public virtual Produtos IdProdutoNavigation { get; set; }
    }
}
