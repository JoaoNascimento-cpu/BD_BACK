using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Contexts;
using WallFertas.Domains;
using WallFertas.Interfaces;

namespace WallFertas.Repositories
{
    public class TiposProdutosRepository : ITiposProdutoRepository
    {
        WallFertas_Context ctx = new WallFertas_Context();
        public void Atualizar(int id, TipoProduto tipoProdutoAtualizado)
        {
            TipoProduto tipoProdutoBuscado = ctx.TipoProdutos.Find(id);

            if (tipoProdutoBuscado != null)
            {
                tipoProdutoBuscado.TituloTipoProduto = tipoProdutoAtualizado.TituloTipoProduto;
            }

            ctx.TipoProdutos.Update(tipoProdutoBuscado);
            ctx.SaveChanges();
        }

        public TipoProduto BuscarPorId(int id)
        {
           return ctx.TipoProdutos.FirstOrDefault(i => i.IdTipoProduto == id);
        }

        public void Cadastrar(TipoProduto novoTipoProduto)
        {
            ctx.Add(novoTipoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoProduto tipoProdutoBuscado = ctx.TipoProdutos.Find(id);
            ctx.TipoProdutos.Remove(tipoProdutoBuscado);
            ctx.SaveChanges();
        }

        public List<TipoProduto> Listar()
        {
            return ctx.TipoProdutos.ToList();
        }
    }
}
