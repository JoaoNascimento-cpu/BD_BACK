using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Domains;

namespace WallFertas.Interfaces
{
    interface IProdutosRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        List<Produtos> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        Produtos BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        void Cadastrar(Produtos novoProduto);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>

        void Atualizar(int id, Produtos produtoAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        void Deletar(int id);
    }
}
