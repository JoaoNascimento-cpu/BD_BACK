using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Domains;

namespace WallFertas.Interfaces
{
    interface IProdutos
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        List<Produto> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        Produto BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        void Cadastrar(Produto novoProduto);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>

        void Atualizar(int id, Produto produtoAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        void Deletar(int id);
    }
}
