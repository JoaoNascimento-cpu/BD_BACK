using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Contexts;
using WallFertas.Domains;
using WallFertas.Interfaces;

namespace WallFertas.Repositories
{
    public class ComentariosRepository : IComentariosRepository
    {
        WallFertas_Context ctx = new WallFertas_Context();

        public void Atualizar(int id, Comentarios comentarioAtualizado)
        {
            Comentarios comentarioBuscado = ctx.Comentarios.Find(id);

            if (comentarioAtualizado.Descricao != null)
            {
                comentarioBuscado.Descricao = comentarioAtualizado.Descricao;
            }

            ctx.Comentarios.Update(comentarioBuscado);

            ctx.SaveChanges();

        }

        public Comentarios BuscarPorId(int id)
        {
            return ctx.Comentarios.FirstOrDefault(tu => tu.IdComentario == id);
        }

        public void Cadastrar(Comentarios novoComentario)
        {
            ctx.Comentarios.Add(novoComentario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Comentarios.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<Comentarios> Listar()
        {
            return ctx.Comentarios.ToList();
                //.Include(e => e.IdProdutosNavigation)
                //.ToList();
        }
    }
}
