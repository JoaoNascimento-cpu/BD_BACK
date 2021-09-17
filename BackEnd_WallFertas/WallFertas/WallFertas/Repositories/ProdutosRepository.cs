using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Contexts;
using WallFertas.Domains;
using WallFertas.Interfaces;

namespace WallFertas.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        WallFertas_Context ctx = new WallFertas_Context();
        public void Atualizar(int id, Produtos produtoAtualizado)
        {
            Produtos produtoBuscado = ctx.Produtos.Find(id);

            if (produtoBuscado != null)
            {
                produtoBuscado.Descricao = produtoAtualizado.Descricao;
            }

            ctx.Produtos.Update(produtoBuscado);
            ctx.SaveChanges();
        }

        public Produtos BuscarPorId(int id)
        {
            return ctx.Produtos.FirstOrDefault(i => i.IdProduto == id);
        }

        public void Cadastrar(Produtos novoProduto)
        {
            ctx.Add(novoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Produtos produtoBuscado = ctx.Produtos.Find(id);
            ctx.Produtos.Remove(produtoBuscado);
            ctx.SaveChanges();
        }

        public List<Produtos> Listar()
        {
            return ctx.Produtos.ToList();
        }
    }
}
