using LiepaLimitedTest.Applicaion.Api.Models;
using LiepaLimitedTest.Domain.Contracts;
using LiepaLimitedTest.Domain.Entities;
using System.Threading.Tasks;

namespace LiepaLimitedTest.Applicaion.Api.Services
{
    public class GenericService<TEntity, TModel> : IGenericService<TEntity, TModel> where TEntity : BaseEntity where TModel : EntityModel
    {
        private readonly IRepository<TEntity> _repository;
        private readonly ICacheManager<TEntity> _cacheManager;
        private readonly IMapper _mapper;

        public GenericService(IRepository<TEntity> repository, ICacheManager<TEntity> cacheManager, IMapper mapper)
        {
            _repository = repository;
            _cacheManager = cacheManager;
            _mapper = mapper;
        }
        public async Task<TModel> GetByIdAsync(int id)
        {
            var entity = await _cacheManager.Get(id);

            return _mapper.Map<TEntity, TModel>(entity);
        }
        public async Task<TModel> CreateAsync(TModel item)
        {
            var entity = await _repository.CreateAsync(_mapper.Map<TModel, TEntity>(item));

            return _mapper.Map<TEntity, TModel>(entity);
        }

        public async Task<TModel> UpdateAsync(TModel item)
        {
            var entity = await _repository.UpdateAsync(_mapper.Map<TModel, TEntity>(item));

            return _mapper.Map<TEntity, TModel>(entity);
        }

        public async Task DeleteAsync(TModel item)
        {
            await _repository.DeleteAsync(_mapper.Map<TModel, TEntity>(item));
        }
    }
}
