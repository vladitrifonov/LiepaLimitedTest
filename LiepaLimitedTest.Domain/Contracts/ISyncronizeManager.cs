using LiepaLimitedTest.Domain.Entities;
using System.Threading.Tasks;

namespace LiepaLimitedTest.Domain.Contracts
{
    public interface ISyncronizeManager<T>
    {
        Task Synchronize();
    }
}
