using LiepaLimitedTest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiepaLimitedTest.Domain.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
