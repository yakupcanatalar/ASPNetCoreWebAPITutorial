using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity:class //TEnitiy bir clas olmak zorunda yapmak için
    {

        //Tüm modeller için oluşturulmuştur.
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync(int id);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        //Fİnd için bir expression almayı sağlar.catefory.sod(_=_.name="kalem") gibi.
        Task <TEntity>SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRangeAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);

    }
}
