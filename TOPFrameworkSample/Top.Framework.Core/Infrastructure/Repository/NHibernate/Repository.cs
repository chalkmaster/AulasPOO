using System;
using NHibernate;

namespace Top.Framework.Core.Infrastructure.Repository.NHibernate
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        #region Field
        protected ISession Session { get; set; }
        #endregion

        #region Constructors
        protected Repository(ISession session)
        {
            Session = session;
        }
        #endregion

        #region Methods
        public int CreateOrUpdate(T entity)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Save(entity);
                transaction.Commit();
            }
            return entity.Id;
        }

        public void Remove(T entity)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Delete(entity);
                transaction.Commit();
            }
        }

        public void LogicalRemove(T entity)
        {
            using (var transaction = Session.BeginTransaction())
            {
                entity.Deleted = true;
                Session.Save(entity);
                transaction.Commit();
            }
        }

        public T FindById(int id)
        {
            return FindByIdInternal(id, false);

        }

        public T FindRemovedById(int id)
        {
            return FindByIdInternal(id, true);
        }
        #endregion

        #region Private
        private T FindByIdInternal(int id, bool getDeleted)
        {
            return Session.QueryOver<T>()
                .Where(e => e.Id == id && e.Deleted == getDeleted)
                .SingleOrDefault();
        }
        #endregion

    }
}
