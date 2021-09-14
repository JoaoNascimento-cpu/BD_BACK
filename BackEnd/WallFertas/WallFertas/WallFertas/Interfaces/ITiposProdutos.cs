using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Domains;

namespace WallFertas.Interfaces
{
    interface ITiposProdutos
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        List<TipoProduto> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        TipoProduto BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        void Cadastrar(TipoProduto novoTipoProduto);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>

        void Atualizar(int id, TipoProduto tipoProdutoAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        void Deletar(int id);
    }
}
