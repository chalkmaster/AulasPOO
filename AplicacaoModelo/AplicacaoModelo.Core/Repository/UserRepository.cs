using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoModelo.Core.DomainObjects;

namespace AplicacaoModelo.Core.Repository
{
    public class UserRepository
    {
        private List<User> _db = new List<User>();

        public void InsertOrUpdate(User user)
        {
            _db.Add(user);
        }

        public User FindById(int id)
        {
            return _db.Where(usr => usr.Id == id).FirstOrDefault();
        }

        public User FindByEmail(string email)
        {
            return _db.Where(usr => usr.Email == email).FirstOrDefault();
        }
        public void Delete(User user)
        {
            _db.Remove(user);
        }
    }
}
