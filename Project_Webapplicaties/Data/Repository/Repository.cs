using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private readonly BitHeroesContext _context;

        public Repository(BitHeroesContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Getall()
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public IEnumerable<TEntity> GetAllWithQuestionAndIncludes(Expression<Func<TEntity, bool>> voorwaarde, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (voorwaarde != null)
            {
                query = query.Where(voorwaarde);
            }
            return query.ToList();
        }

        public TEntity GetbyQuestionWithIncludes(Expression<Func<TEntity, bool>> voorwaarde, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (voorwaarde != null)
            {
                query = query.Where(voorwaarde);
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAllWithIncludes(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }

        public TEntity GetByIdWithQuestion(Expression<Func<TEntity, bool>> voorwaarde)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (voorwaarde != null)
            {
                query = query.Where(voorwaarde);
            }
            return query.FirstOrDefault();
        }
    }
}
