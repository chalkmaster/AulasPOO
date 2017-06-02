using System;
using System.Linq;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Top.Framework.Core.DomainObjects.Security;

namespace Top.Framework.Core.Infrastructure.Repository.NHibernate
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(ISession session) : base(session)
        {
        }

        public IList<User> FindByName(string name)
        {
            var query = Session.QueryOver<User>();
            query.Where(user => user.Name.IsInsensitiveLike('%' + name + '%')
                                && user.Deleted == false);
            return query.List();
        }

        public User FindByLogin(string login)
        {
            var query = Session.QueryOver<User>();
            return query.Where(user => user.Login.Equals(login, StringComparison.InvariantCultureIgnoreCase)
                                       && user.Deleted == false)
                                       .SingleOrDefault();

        }

        public IList<User> FindAll()
        {
            var query = Session.QueryOver<User>();
            return query.Where(user => user.Deleted == false).List();
        }
    }
}
