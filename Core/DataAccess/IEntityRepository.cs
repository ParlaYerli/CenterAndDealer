using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    { 
       // T Login(Expression<Func<T, bool>> filter);
        T GetUser(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void UpdateUser(T entity);
        void CreateUser(T entity);
    }
}
