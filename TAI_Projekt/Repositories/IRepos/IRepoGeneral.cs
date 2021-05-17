using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAI_Projekt.Repositories.IRepos
{
    public interface IRepoGeneral<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> SaveAsync();
    }
}
