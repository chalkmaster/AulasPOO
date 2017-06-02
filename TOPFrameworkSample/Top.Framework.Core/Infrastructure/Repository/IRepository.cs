namespace Top.Framework.Core.Infrastructure.Repository
{
    public interface IRepository<T> where T : Entity
    {
        int CreateOrUpdate(T entity);
        void Remove(T entity);
        void LogicalRemove(T entity);
        T FindById(int id);
        T FindRemovedById(int id);        
    }
}
