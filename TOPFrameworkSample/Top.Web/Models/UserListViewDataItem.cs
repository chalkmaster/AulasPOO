using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Top.Web.Models
{
    public class UserListViewDataItem
    {
        [DisplayName("Id")]
        [ReadOnly(true)]
        [DataType(DataType.Text)]
        public int Id { get; set; }

        
        [DisplayName("Nome")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DisplayName("Login")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Usuário Ativo")]
        public bool Active { get; set; }        
    }
}