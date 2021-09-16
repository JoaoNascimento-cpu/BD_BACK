using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Contexts;
using WallFertas.Domains;
using WallFertas.Interfaces;

namespace WallFertas.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        WallFertas_Context ctx = new WallFertas_Context();

        public void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            TiposUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioAtualizado.TituloTipoUsuario != null)
            {
                tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
