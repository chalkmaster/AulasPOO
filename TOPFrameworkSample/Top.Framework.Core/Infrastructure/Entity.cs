using System.Collections.Generic;

namespace Top.Framework.Core.Infrastructure
{
    /// <summary>
    /// Representa uma entidade persistível do sistema
    /// </summary>
    public abstract class Entity: IValidatable
    {
        /// <summary>
        /// Identificador da entidade no banco de dados
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Codico da entidade em sistemas externos: Utilizado para integração de dados
        /// </summary>
        public virtual string ExternalCode { get; set; }

        /// <summary>
        /// Informa se a entidade foi deletada (exclusão lógica)
        /// </summary>
        public virtual bool Deleted { get; set; }

        /// <summary>
        /// Retorna se uma entidade possui informações validas para serem persistedas
        /// </summary>
        /// <param name="brokenRoles">lista de regras quebradas</param>
        /// <returns>se a entidade é válida ou não</returns>
        public abstract bool IsValid(out IList<string> brokenRoles);
    }
}
