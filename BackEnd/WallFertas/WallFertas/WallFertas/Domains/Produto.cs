using System;
using System.Collections.Generic;

#nullable disable

namespace WallFertas.Domains
{
    public partial class Produto
    {
        public Produto()
        {
            Comentarios = new HashSet<Comentario>();
        }

        public int IdProduto { get; set; }
        public int? IdTipoProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public int Preco { get; set; }
        public DateTime Validade { get; set; }

        public virtual TipoProduto IdTipoProdutoNavigation { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
