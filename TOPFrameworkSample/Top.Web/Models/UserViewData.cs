using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Top.Framework.Core.DomainObjects.Security;
using Top.Framework.Core.DomainObjects.Security.Validation;
using Top.Infrastructure.Web.Helpers;

namespace Top.Web.Models
{
    [MatchLocalized("Password", "RepitedPassword", "Senha não confere")]
    public class UserViewData
    {
        #region Properties
        [DisplayName("Id")]
        [ReadOnly(true)]
        [DataType(DataType.Text)]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [DataType(DataType.Text)]
        [MaxLength(UserValidator.NameMaxSize)]
        [MinLength(UserValidator.NameMinSize)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Telefone Fixo")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Telefone Celular")]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [DisplayName("Login")]
        [DataType(DataType.Text)]
        [Required]
        [MaxLength(UserValidator.LoginMaxSize)]
        [MinLength(UserValidator.LoginMinSize)]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Repita sua senha")]
        [DataType(DataType.Password)]
        public string RepitedPassword { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DisplayName("Usuário Ativo")]
        public bool Active { get; set; }
        #endregion

        #region Constructors
        public UserViewData()
        {
        }

        public UserViewData(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Phone = user.Phone;
            CellPhone = user.CellPhone;
            Login = user.Login;
            Email = user.Email;
            Active = user.Active;
        }
        #endregion

        #region Methods
        public User GetUser()
        {
            var user = new User
                       {
                           Active = Active,
                           CellPhone = CellPhone,
                           Email = Email,
                           Login = Login,
                           Name = Name,
                           Id = Id,
                           Phone = Phone
                       };
            if (!string.IsNullOrWhiteSpace(Password))
                user.Password = Password;

            return user;
        }
        #endregion
    }
}