using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Domains;

namespace WallFertas.Interfaces
{
    interface IEmpresas
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        List<Empresa> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        Empresa BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        void Cadastrar(Empresa novaEmpresa);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>

        void Atualizar(int id, Empresa empresaAtualizada);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        void Deletar(int id);
    }
}
