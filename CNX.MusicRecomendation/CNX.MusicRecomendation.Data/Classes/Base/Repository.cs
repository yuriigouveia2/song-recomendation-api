

using CNX.MusicRecomendation.Data.DataContext;
using CNX.MusicRecomendation.Data.Interfaces.Base;
using CNX.MusicRecomendation.Model.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CNX.MusicRecomendation.Data.Classes.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly ApplicationContext _context;
        private readonly DbSet<T> _dbEntity;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbEntity = context.Set<T>();
        }


        public virtual void Create(T entity)
        {
            entity.Id = entity.Id.Equals(Guid.Empty) ? Guid.NewGuid() : entity.Id;
            entity.CreatedAt = DateTime.Now;
            entity.Deleted = false;
            _dbEntity.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            T entity = GetById(id);
            if (entity != null)
            {
                _dbEntity.Remove(entity);
                _context.SaveChanges();
            }
        }

        public virtual IEnumerable<T> Filter(Func<T, bool> predicate) => _dbEntity.AsNoTracking().Where(predicate);
        public virtual IQueryable<T> GetAll() => _dbEntity.AsNoTracking().OrderByDescending(c => c.CreatedAt);
        public virtual T GetById(Guid id) => _dbEntity.AsNoTracking().FirstOrDefault(prop => prop.Id.Equals(id));

        public virtual T Update(Guid id, T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.CreatedAt).IsModified = false;
            _context.Entry(entity).Property(x => x.Deleted).IsModified = false;
            _context.SaveChanges();

            return GetById(id);
        }
    }
}
