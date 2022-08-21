using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        IEnumerable<TEntity> GetAllWithQuestionAndIncludes(Expression<Func<TEntity, bool>> voorwaarde, params Expression<Func<TEntity, object>>[] includes);

        TEntity GetbyQuestionWithIncludes(Expression<Func<TEntity, bool>> voorwaarde,
            params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAllWithIncludes(params Expression<Func<TEntity, object>>[] includes);

        TEntity GetByIdWithQuestion(Expression<Func<TEntity, bool>> voorwaarde);
    }
}
