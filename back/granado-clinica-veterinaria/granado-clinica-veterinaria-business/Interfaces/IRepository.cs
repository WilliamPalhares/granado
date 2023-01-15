using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace granado_clinica_veterinaria_business.Interfaces
{
    public interface IRepository<T> where T : new()
    {
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetObjectAsync(Int64 Id);
        Task SaveChangesAsync();
        Task<long> InsertAsync(T obj);
        Task UpdateAsync(T obj);
        Task RemoveAsync(T obj);
        int Count();
    }
}
