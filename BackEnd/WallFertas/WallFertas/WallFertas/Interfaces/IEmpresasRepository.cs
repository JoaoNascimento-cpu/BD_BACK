using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Domains;

namespace WallFertas.Interfaces
{
    interface IEmpresasRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        List<Empresas> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        Empresas BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        void Cadastrar(Empresas novaEmpresa);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>

        void Atualizar(int id, Empresas empresaAtualizada);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        void Deletar(int id);
    }
}
