using ECom_db.Base;
using ECom_db.Context;
using Ecom_lib.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Repos
{
    public class GenralRepo<T>(AppDbContext appDb) : IGenralRepo<T> where T : class
    {
        public async Task<int> AddAsync(T entity)
        {
            await appDb.Set<T>().AddAsync(entity);
            return await appDb.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity =await appDb.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new ItemNotFoundEx($"item {id} not found");
            }
            appDb.Set<T>().Remove(entity);
            return await  appDb.SaveChangesAsync() ;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await appDb.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByID(Guid id)
        {
            var item = await appDb.Set<T>().FindAsync( id);
            if (item == null)
            {
                throw new ItemNotFoundEx($"item {id} not found");
            }
            return item!;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            appDb.Set<T>().Update(entity);
            return await appDb.SaveChangesAsync();
        }
    }
}
