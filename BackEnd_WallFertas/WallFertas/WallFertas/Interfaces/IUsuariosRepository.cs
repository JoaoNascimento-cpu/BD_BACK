using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WallFertas.Domains;

namespace WallFertas.Interfaces
{
    interface IUsuariosRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<Usuarios> Listar();

        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        Usuarios BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        void Cadastrar(Usuarios novoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        void Atualizar(int id, Usuarios usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário 
        /// </summary>
        void Deletar(int id);

        /// <summary>
        /// Valida o usuário
        /// </summary>
        Usuarios Login(string email, string senha);
    }
}
