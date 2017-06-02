using System;
using System.Collections.Generic;
using System.Linq;
using Top.Framework.Core.Extension;
using Top.Framework.Core.Infrastructure;

namespace Top.Framework.Core.DomainObjects.Security.Validation
{
    public class UserValidator: IValidator<User>
    {
        public const int NameMinSize = 1;
        public const int NameMaxSize = 150;
        public const int LoginMinSize = 3;
        public const int LoginMaxSize = 20;

        public bool Validate(User entityToValidate, out IList<string> brokenRoles)
        {
            brokenRoles = new List<string>();

            if (String.IsNullOrWhiteSpace(entityToValidate.Name))
                brokenRoles.Add("Favor informar um nome");
            else if (entityToValidate.Name.Length < NameMinSize)
                brokenRoles.Add("O nome deve ter pelo menos {0} caracteres".FormatWith(NameMinSize));
            else if (entityToValidate.Name.Length > NameMaxSize)
                brokenRoles.Add("O nome deve ter no maximo {0} caracteres".FormatWith(NameMaxSize));

            if (String.IsNullOrWhiteSpace(entityToValidate.Login))
                brokenRoles.Add("Favor informar um login");
            else if (entityToValidate.Login.Length < LoginMinSize)
                brokenRoles.Add("O login deve ter pelo menos {0} caracteres".FormatWith(LoginMinSize));
            else if (entityToValidate.Login.Length > LoginMaxSize)
                brokenRoles.Add("O login deve ter no maximo {0} caracteres".FormatWith(LoginMaxSize));

            if (!entityToValidate.Email.IsEmail())
                brokenRoles.Add("O e-mail informado não é valido");

            if(String.IsNullOrWhiteSpace(entityToValidate.Password))
                brokenRoles.Add("Você deve informar uma senha");

            return brokenRoles.Any();
        }
    }
}
