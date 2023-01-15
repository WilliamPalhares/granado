using granado_clinica_veterinaria_domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace granado_clinica_veterinaria_business.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly DbSet<T> dbSet;
        protected readonly ApplicationContext context;
        //protected readonly ILogger logger;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            //this.logger = logger;
        }

        public virtual async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetListAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                //logger.LogError($"Erro ao consultar: {ex.Message}");
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }

        public virtual async Task<T> GetObjectAsync(Int64 Id)
        {
            try
            {
                return await dbSet.FindAsync(Id);
            }
            catch (Exception ex)
            {
                //logger.LogError($"Erro ao consultar: {ex.Message}");
                throw new Exception($"Erro ao consultar: {ex.Message}");
            }
        }

        public virtual async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public virtual async Task<long> InsertAsync(T obj)
        {
            try
            {
                dbSet.Add(obj);
                await SaveChangesAsync();
                return obj.Id;
            }
            catch (Exception ex)
            {
                //logger.LogError($"Erro ao inserir: {ex.Message}");
                throw new Exception($"Erro ao inserir: {ex.Message}");
            }
        }

        public virtual async Task UpdateAsync(T obj)
        {
            try
            {
                var entry = dbSet.Update(obj);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //logger.LogError($"Erro ao atualizar: {ex.Message}");
                throw new Exception($"Erro ao atualizar: {ex.Message}");
            }
        }

        public virtual async Task RemoveAsync(T obj)
        {
            try
            {
                dbSet.Attach(obj);
                dbSet.Remove(obj);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //logger.LogError($"Erro ao remover: {ex.Message}");
                throw new Exception($"Erro ao remover: {ex.Message}");
            }
        }

        public virtual int Count()
        {
            var TaskResult = GetListAsync();
            TaskResult.Wait();
            var result = TaskResult.Result;

            return result.Count();
        }
    }
}
