using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Domains;

namespace WallFertas.Interfaces
{
    interface ITiposProdutoRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        List<TiposProduto> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        TiposProduto BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        void Cadastrar(TiposProduto novoTipoProduto);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>

        void Atualizar(int id, TiposProduto tipoProdutoAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        void Deletar(int id);
    }
}
