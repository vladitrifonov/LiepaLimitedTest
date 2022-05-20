using LiepaLimitedTest.Domain.Contracts;
using LiepaLimitedTest.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LiepaLimitedTest.Applicaion.Services
{
    public class SyncronizeService<T> : ISyncronizeManager<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly ICacheManager<T> _cacheManager;
        public SyncronizeService(IRepository<T> repository, ICacheManager<T> cacheManager)
        {
            _repository = repository;
            _cacheManager = cacheManager;
        }
        public async Task Synchronize()
        {
            var items = await _repository.GetAsync();

            await _cacheManager.UpdateCache(items);
        }
    }
}
