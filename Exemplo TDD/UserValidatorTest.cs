using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nextel.Core.DomainObjects.Foundation;
using Nextel.Core.DomainObjects.Security;
using Nextel.Core.DomainObjects;
using Nextel.Core.DomainObjects.Security.Validation;
using Nextel.Core.Repository.Security;
using Nextel.Core.Test.Helper;

namespace Nextel.Core.Test.DomainObjects.Security.Validator
{
    [TestClass]
    public class UserValidatorTest
    {
        #region Test Methods

        [TestMethod]
        public void BrokenRulesShouldReturnCorrect()
        {
            User user = GetValidUser();

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 0);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnNullCompanyError()
        {
            User user = GetValidUser();
            user.Company = null;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 1);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnNullProfileError()
        {
            User user = GetValidUser();
            user.Profile = null;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 1);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnNullUserGroupError()
        {
            User user = GetValidUser();
            user.Group = null;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 1);
        }

        #region Name
        [TestMethod]
        public void BrokenRulesShouldReturnEmptyNameError()
        {
            User user = GetValidUser();
            user.Name = string.Empty;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(2, brokenRules.Count());
        }

        [TestMethod]
        public void BrokenRulesShouldReturnWithWhiteSpacesNameError()
        {
            User user = GetValidUser();
            user.Name = "   ";

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 1);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnNullNameError()
        {
            User user = GetValidUser();
            user.Name = null;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(2, brokenRules.Count());
        }
        
        [TestMethod]
        public void BrokenRulesShouldReturnCorrectNameSize()
        {
            User user = GetValidUser();
            user.Name = new string('a', UserValidator.NameMaxSize);

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 0);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnNameTooBigError()
        {
            User user = GetValidUser();
            user.Name = new string('a', UserValidator.NameMaxSize + 1);

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 1);
        }
        #endregion

        #region Login
        [TestMethod]
        public void BrokenRulesShouldReturnEmptyLoginError()
        {
            User user = GetValidUser();
            user.Login = string.Empty;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(2, brokenRules.Count());
        }

        [TestMethod]
        public void BrokenRulesShouldReturnWithWhiteSpacesLoginError()
        {
            User user = GetValidUser();
            user.Login = "   ";

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 1);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnNullLoginError()
        {
            User user = GetValidUser();
            user.Login = null;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(2, brokenRules.Count());
        }

        [TestMethod]
        public void BrokenRulesShouldReturnCorrectLoginSize()
        {
            User user = GetValidUser();
            user.Login = new string('a', UserValidator.LoginMaxSize);

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 0);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnLoginTooBigError()
        {
            User user = GetValidUser();
            user.Login = new string('a', UserValidator.LoginMaxSize + 1);

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 1);
        }
        #endregion

        #region Password
        [TestMethod]
        public void BrokenRulesShouldReturnEmptyPasswordError()
        {
            User user = GetValidUser();
            user.Password = string.Empty;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(3, brokenRules.Count());
        }

        [TestMethod]
        public void BrokenRulesShouldReturnWithWhiteSpacesPasswordError()
        {
            User user = GetValidUser();
            user.Password = "        ";

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(1, brokenRules.Count());
        }

        [TestMethod]
        public void BrokenRulesShouldReturnNullPasswordError()
        {
            User user = GetValidUser();
            user.Password = null;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(2, brokenRules.Count());
        }

        [TestMethod]
        public void BrokenRulesShouldReturnCorrectPasswordMaxSize()
        {
            User user = GetValidUser();
            user.Password = new string('a', UserValidator.PasswordMaxSize);

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 0);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnCorrectPasswordMinSize()
        {
            User user = GetValidUser();
            user.Password = new string('a', UserValidator.PasswordMinSize);

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 0);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnPasswordTooBigError()
        {
            User user = GetValidUser();
            user.Password = new string('a', UserValidator.PasswordMaxSize + 1);

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 1);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnPasswordTooShortError()
        {
            User user = GetValidUser();
            user.Password = new string('a', UserValidator.PasswordMinSize - 1);

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 1);
        }
        #endregion

        #region Email
        [TestMethod]
        public void BrokenRulesShouldReturnEmptyEmailError()
        {
            User user = GetValidUser();
            user.Email = string.Empty;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(3, brokenRules.Count());
        }

        [TestMethod]
        public void BrokenRulesShouldReturnWithWhiteSpacesEmailError()
        {
            User user = GetValidUser();
            user.Email = "   ";

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(2, brokenRules.Count());
        }

        [TestMethod]
        public void BrokenRulesShouldReturnNullEmailError()
        {
            User user = GetValidUser();
            user.Email = null;

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(3, brokenRules.Count());
        }

        [TestMethod]
        public void BrokenRulesShouldReturnCorrectEmailSize()
        {
            User user = GetValidUser();
            user.Email = "user@" + new string('a', UserValidator.EmailMaxSize - 9) + ".com";

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 0);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnEmailTooBigError()
        {
            User user = GetValidUser();
            user.Email = "user@" + new string('a', UserValidator.EmailMaxSize) + ".com";

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.IsTrue(brokenRules.Count() == 1);
        }

        [TestMethod]
        public void BrokenRulesShouldReturnInvalidEmailError()
        {
            User user = GetValidUser();
            user.Email = new string('a', UserValidator.EmailMaxSize);

            var brokenRules = GetUserValidator().BrokenRules(user);

            Assert.IsNotNull(brokenRules);
            Assert.AreEqual(1, brokenRules.Count());
        }

        #endregion

        #endregion

        #region Static Methods

        public static User GetValidUser()
        {
            var company = TestHelper.GetDefaultCompany();
            company.Id = 1;

            const string email = "usuario@empresa.com";
            var group = TestHelper.GetDefaultUserGroup();
            const string login = "sa";
            const string password = "12345678";
            const string name = "usuario da silva";
            var profile = TestHelper.GetDefaultProfile();

            return DomainObjectsFactory.Security.CreateUser(company, name, login, password, group, profile, email);
        }

        public static UserValidator GetUserValidator()
        {
            return new UserValidator(GetUserRepositoryMock());
        }

        private static IUserRepository GetUserRepositoryMock()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var user = GetValidUser();
            userRepositoryMock.Setup(m => m.FindAllByCompany(It.IsAny<Company>())).Returns(user);
            return userRepositoryMock.Object;
        }


        #endregion

    }
}
