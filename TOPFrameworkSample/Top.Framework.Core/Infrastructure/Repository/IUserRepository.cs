using System.Collections.Generic;
using Top.Framework.Core.DomainObjects.Security;

namespace Top.Framework.Core.Infrastructure.Repository
{
    /// <summary>
    /// Interface de contrato para o repositório de usuário
    /// </summary>
    public interface IUserRepository: IRepository<User>
    {
        /// <summary>
        /// Permite localizar um usuário pelo seu nome
        /// </summary>
        /// <param name="name">nome do usuário</param>
        /// <returns>lista de usuário cujo nome contem parte do nome informado (ex.: Para "Jo" serão retornados "João" e "Joana", etc)</returns>
        IList<User> FindByName(string name);

        /// <summary>
        /// Localiza um usuário pelo seu login
        /// </summary>
        /// <param name="login">login do usuário a ser localizado</param>
        /// <returns>usuário que possui o login exatamente conforme informado</returns>
        User FindByLogin(string login);

        /// <summary>
        /// Retorna todos os usuários do sistema
        /// </summary>
        /// <returns>Lista de usuário</returns>
        IList<User> FindAll();
    }
}
