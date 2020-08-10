using Microsoft.EntityFrameworkCore;
using CNX.LogService.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNX.LogService.Data.Interfaces.Base;
using CNX.LogService.Model.Entities.Base;

namespace CNX.LogService.Data.Classes.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly LogContext _context;
        private readonly DbSet<T> _dbEntity;

        public Repository(LogContext context)
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
    }
}
