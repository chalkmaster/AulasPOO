using System.Collections.Generic;
using Top.Framework.Core.DomainObjects.Security.Validation;
using Top.Framework.Core.Infrastructure;

namespace Top.Framework.Core.DomainObjects.Security
{
    /// <summary>
    /// Classe que representa um usuário do sistema
    /// </summary>
    public class User : Entity  
    {
        /// <summary>
        /// Nome
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Telefone Fixo
        /// </summary>
        public virtual string Phone { get; set; }

        /// <summary>
        /// Telefone Celular
        /// </summary>
        public virtual string CellPhone { get; set; }

        /// <summary>
        /// Login de acesso ao sistema
        /// </summary>
        public virtual string Login { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Indica se o usuário está ou não ativo
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        /// Retorna se o usuário possui informações validas para serem persistedas
        /// </summary>
        /// <param name="brokenRoles">lista de regras quebradas</param>
        /// <returns>se a entidade é válida ou não</returns>
        public override bool IsValid(out IList<string> brokenRoles)
        {
            return new UserValidator().Validate(this, out brokenRoles);
        }
    }
}
