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
        public void Atualizar(int id, TiposProduto tipoProdutoAtualizado)
        {
            TiposProduto tipoProdutoBuscado = ctx.TipoProdutos.Find(id);

            if (tipoProdutoBuscado != null)
            {
                tipoProdutoBuscado.TituloTipoProduto = tipoProdutoAtualizado.TituloTipoProduto;
            }

            ctx.TipoProdutos.Update(tipoProdutoBuscado);
            ctx.SaveChanges();
        }

        public TiposProduto BuscarPorId(int id)
        {
            return ctx.TipoProdutos.FirstOrDefault(i => i.IdTipoProduto == id);
        }

        public void Cadastrar(TiposProduto novoTipoProduto)
        {
            ctx.Add(novoTipoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposProduto tipoProdutoBuscado = ctx.TipoProdutos.Find(id);
            ctx.TipoProdutos.Remove(tipoProdutoBuscado);
            ctx.SaveChanges();
        }

        public List<TiposProduto> Listar()
        {
            return ctx.TipoProdutos.ToList();
        }
    }
}
