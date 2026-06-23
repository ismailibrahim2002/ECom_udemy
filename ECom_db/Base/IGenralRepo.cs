using System;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Base
{
    public interface IGenralRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByID(Guid id);
        Task<int> AddAsync(T entiny);
        Task<int> UpdateAsync(T entiny);
        Task<int> DeleteAsync(Guid id);

    }
}
