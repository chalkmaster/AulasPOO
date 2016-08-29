using AplicacaoModelo.Core.DomainObjects;
using AplicacaoModelo.Core.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoModelo.Core.Services
{
    public class UserService
    {
        private static UserRepository _userRepository = new UserRepository();
        public void Save(User userToSave)
        {
            _userRepository.InsertOrUpdate(userToSave);
        }
        public User GetById(int id)
        {
            return _userRepository.FindById(id);
        }

        public void Remove(User userToRemove)
        {
            _userRepository.Delete(userToRemove);
        }

        public bool Login(User userToLogin)
        {
            var findedUser = _userRepository
                              .FindByEmail(userToLogin.Email);

            if (findedUser == null)
                return false;

            if (findedUser.Password == userToLogin.Password)
                return true;
            else
                return false;

        }
    }
}
