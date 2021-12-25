using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Core.Services
{
    public interface IService<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync(int id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        //Fİnd için bir expression almayı sağlar.catefory.sod(_=_.name="kalem") gibi.
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRangeAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}
