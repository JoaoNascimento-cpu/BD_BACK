using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Domains;

namespace WallFertas.Interfaces
{
    interface IComentario
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        List<Comentario> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        Comentario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        void Cadastrar(Comentario novoComentario);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>

        void Atualizar(int id, Comentario comentarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        void Deletar(int id);
    }
}
