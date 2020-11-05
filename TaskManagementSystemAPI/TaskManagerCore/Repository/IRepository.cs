using System;
using System.Linq;
using System.Linq.Expressions;

namespace TaskManagerCore.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
        T GetById(Guid entityId);
        Guid Add(T entity);
        void Update();
        void Delete(T entity);

    }
}
