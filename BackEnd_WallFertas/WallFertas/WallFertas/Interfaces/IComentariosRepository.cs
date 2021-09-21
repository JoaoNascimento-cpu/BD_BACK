using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Domains;

namespace WallFertas.Interfaces
{
    interface IComentariosRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        List<Comentarios> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        Comentarios BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        void Cadastrar(Comentarios novoComentario);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>

        void Atualizar(int id, Comentarios comentarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        void Deletar(int id);
    }
}
