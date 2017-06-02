using Microsoft.VisualStudio.TestTools.UnitTesting;
using Top.Framework.Core.DomainObjects.Security;
using Top.Framework.Core.Infrastructure.Repository.NHibernate;
using Top.Framework.Core.Infrastructure.Repository.Helper;

namespace Top.Framework.Core.TestBase.DomainObjects.Security
{

    [TestClass]
    public class UserTest
    {
        
        [TestMethod]
        [ExpectedException(typeof(NHibernate.PropertyValueException))]
        public void NomeDeveSerInformado()
        {
            using (var session = PersistenceHelper.OpenSession())
            {
                var user = new User {Phone = "3353539", Login = "Top", Password = "123"};
                var userRepository = new UserRepository(session);
                userRepository.CreateOrUpdate(user);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NHibernate.PropertyValueException))]
        public void TelefoneFixoDeveSerInformado()
        {
            using (var session = PersistenceHelper.OpenSession())
            {
                var user = new User {Name = "Pedro", Login = "Top", Password = "123"};
                var userRepository = new UserRepository(session);
                userRepository.CreateOrUpdate(user);    
            }
            
        }

        [TestMethod]
        [ExpectedException(typeof(NHibernate.PropertyValueException))]
        public void LoginDeveSerInformado()
        {
            using (var session = PersistenceHelper.OpenSession())
            {
                var user = new User {Name = "Lourete", Phone = "24242424", Password = "2424"};
                var userRepository = new UserRepository(session);
                userRepository.CreateOrUpdate(user);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NHibernate.PropertyValueException))]
        public void SenhaDeveSerInformada()
        {
            using (var session = PersistenceHelper.OpenSession())
            {
                var user = new User {Name = "Saulete", Phone = "555", Login = "666"};
                var userRepository = new UserRepository(session);
                userRepository.CreateOrUpdate(user);

            }
        }

        [TestMethod]
        public void UsurioSalvaCorretamente()
        {
            using (var session = PersistenceHelper.OpenSession())
            {
                var user = new User { Name = "Saulete",
                                      Active = true,
                                      CellPhone = "123123123",
                                      Deleted = false,
                                      ExternalCode = "1234",
                                      Email = "asdsad@asdsadsa.com",
                                      Phone = "555", 
                                      Login = "666", 
                                      Password = "12345" 
                                    };

                var userRepository = new UserRepository(session);
                
                userRepository.CreateOrUpdate(user);

                Assert.AreNotEqual(0, user.Id);
            }
        }
    }
}
