using System;
using System.Collections.Generic;

#nullable disable

namespace WallFertas.Domains
{
    public partial class Produtos
    {
        public Produtos()
        {
            Comentarios = new HashSet<Comentarios>();
        }

        public int IdProduto { get; set; }
        public int? IdTipoProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public int Preco { get; set; }
        public DateTime Validade { get; set; }

        public virtual TiposProduto IdTipoProdutoNavigation { get; set; }
        public virtual ICollection<Comentarios> Comentarios { get; set; }
    }
}
