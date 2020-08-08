using CNX.MusicRecomendation.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CNX.MusicRecomendation.Data.Interfaces.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        IQueryable<T> GetAll();
        IEnumerable<T> Filter(Func<T, bool> predicate);
        void Create(T entity);
        T Update(Guid id, T entity);
        void Delete(Guid id);
    }
}
