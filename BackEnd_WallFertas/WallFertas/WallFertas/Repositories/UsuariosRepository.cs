using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Contexts;
using WallFertas.Domains;
using WallFertas.Interfaces;

namespace WallFertas.Repositories
{
        public class UsuariosRepository : IUsuariosRepository
        {
            WallFertas_Context ctx = new WallFertas_Context();

            public void Atualizar(int id, Usuarios usuarioAtualizado)
            {
                
                Usuarios usuarioBuscado = ctx.Usuarios.Find(id);

               
                if (usuarioAtualizado.Nome != null)
                {                   
                    usuarioBuscado.Nome = usuarioAtualizado.Nome;
                }

                
                if (usuarioAtualizado.Email != null)
                {
                    usuarioBuscado.Email = usuarioAtualizado.Email;
                }

              
                if (usuarioAtualizado.Senha != null)
                {
                    usuarioBuscado.Senha = usuarioAtualizado.Senha;
                }

                ctx.Usuarios.Update(usuarioBuscado);

                ctx.SaveChanges();
            }

            public Usuarios BuscarPorId(int id)
            {
                return ctx.Usuarios
                .Select(u => new Usuarios()
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,

                    IdTipoUsuarioNavigation = new TiposUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                    }
                })
                .FirstOrDefault(u => u.IdUsuario == id);
            }

            public void Cadastrar(Usuarios novoUsuario)
            {
                ctx.Usuarios.Add(novoUsuario);

                ctx.SaveChanges();
            }

            public void Deletar(int id)
            {
                ctx.Usuarios.Remove(BuscarPorId(id));

                ctx.SaveChanges();
            }

            public List<Usuarios> Listar()
            {
                return ctx.Usuarios
                .Select(u => new Usuarios()
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,

                    IdTipoUsuarioNavigation = new TiposUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                    }
                })
                .ToList();
            }

            public Usuarios Login(string email, string senha)
            {
                return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            }
        }
}