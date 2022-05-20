using System.Threading.Tasks;

namespace LiepaLimitedTest.Domain.Contracts
{
    public interface IGenericService<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
