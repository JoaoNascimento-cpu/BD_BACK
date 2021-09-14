using System;
using System.Collections.Generic;

#nullable disable

namespace WallFertas.Domains
{
    public partial class TipoProduto
    {
        public TipoProduto()
        {
            Produtos = new HashSet<Produto>();
        }

        public int IdTipoProduto { get; set; }
        public string TituloTipoProduto { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
