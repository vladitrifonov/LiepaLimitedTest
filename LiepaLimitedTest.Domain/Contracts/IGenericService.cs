using System.Threading.Tasks;

namespace LiepaLimitedTest.Domain.Contracts
{
    public interface IGenericService<TEntity, TModel>
    {
        Task<TModel> GetByIdAsync(int id);
        Task<TModel> CreateAsync(TModel item);
        Task<TModel> UpdateAsync(TModel item);
        Task DeleteAsync(TModel item);
    }
}
