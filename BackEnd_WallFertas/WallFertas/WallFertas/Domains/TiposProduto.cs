using System;
using System.Collections.Generic;

#nullable disable

namespace WallFertas.Domains
{
    public partial class TiposProduto
    {
        public TiposProduto()
        {
            Produtos = new HashSet<Produtos>();
        }

        public int IdTipoProduto { get; set; }
        public string TituloTipoProduto { get; set; }

        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
