using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Contexts;
using WallFertas.Domains;
using WallFertas.Interfaces;

namespace WallFertas.Repositories
{
    public class EmpresasRepository : IEmpresasRepository
    {
        WallFertas_Context ctx = new WallFertas_Context();

        /// <summary>
        /// método utilizado para atualizar a empresa, é nescessário atualizar só o nome
        /// </summary>
        /// <param name="id">id da  empresa </param>
        /// <param name="empresaAtualizada">objeto que irá carregar as novas informações da empresa</param>
        public void Atualizar(int id, Empresas empresaAtualizada)
        {
            Empresas empresaBuscada = ctx.Empresas.Find(id);

            if (empresaBuscada != null)
            {
                empresaBuscada.Nome = empresaAtualizada.Nome;
            }

            ctx.Empresas.Update(empresaBuscada);
            ctx.SaveChanges();
        }

        public Empresas BuscarPorId(int id)
        {
            return ctx.Empresas.FirstOrDefault(i => i.IdEmpresa == id);
        }

        public void Cadastrar(Empresas novaEmpresa)
        {
            ctx.Empresas.Add(novaEmpresa);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Empresas empresaBuscada = ctx.Empresas.Find(id);
            ctx.Remove(empresaBuscada);
            ctx.SaveChanges();
        }

        public List<Empresas> Listar()
        {
            return ctx.Empresas.ToList();
        }
    }
}
