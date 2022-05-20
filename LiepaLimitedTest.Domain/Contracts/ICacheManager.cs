using LiepaLimitedTest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiepaLimitedTest.Domain.Contracts
{
    public interface ICacheManager<T> 
    {
        Task<T> Get(int id);

        Task UpdateCache(IEnumerable<T> entities);
    }
}
