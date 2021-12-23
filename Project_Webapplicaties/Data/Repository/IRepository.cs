using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Data.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IQueryable<TEntity> Getall();
        Task<TEntity> GetById(int id);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
