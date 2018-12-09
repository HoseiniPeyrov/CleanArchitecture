using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRepository
    {
        TEntity GetById<TEntity>(int id) where TEntity : BaseEntity;
        List<TEntity> List<TEntity>() where TEntity : BaseEntity;
        TEntity Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }
}
