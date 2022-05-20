using LiepaLimitedTest.Domain.Contracts;
using LiepaLimitedTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiepaLimitedTest.Applicaion.Services
{
    //may be should make mapper from model to entity
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly ICacheManager<T> _cacheManager;

        public GenericService(IRepository<T> repository, ICacheManager<T> cacheManager)
        {
            _repository = repository;
            _cacheManager = cacheManager;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _cacheManager.Get(id);
        }
        public Task<T> CreateAsync(T item)
        {
            return _repository.CreateAsync(item);
        }

        public Task<T> UpdateAsync(T item)
        {
            return _repository.UpdateAsync(item);
        }

        public Task DeleteAsync(T item)
        {
            return _repository.DeleteAsync(item);
        }
    }
}
