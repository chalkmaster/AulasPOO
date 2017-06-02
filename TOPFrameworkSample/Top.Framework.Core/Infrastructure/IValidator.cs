using System.Collections.Generic;

namespace Top.Framework.Core.Infrastructure
{
    /// <summary>
    /// Interface de um validador de entidades
    /// </summary>
    /// <typeparam name="T">Tipo da entidade a ser validado</typeparam>
    public interface IValidator<in T> where T : Entity
    {
        /// <summary>
        /// Valida a entidade
        /// </summary>
        /// <param name="entityToValidate">entidade a ser validada</param>
        /// <param name="brokenRoles">lista de regras quebradas</param>
        /// <returns>se a entidade é válida ou não</returns>
        bool Validate(T entityToValidate, out IList<string> brokenRoles);
    }
}
