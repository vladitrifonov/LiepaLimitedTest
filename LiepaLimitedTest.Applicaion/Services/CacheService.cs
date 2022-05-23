using LiepaLimitedTest.Domain.Contracts;
using LiepaLimitedTest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace LiepaLimitedTest.Applicaion.Api.Services
{
    public abstract class CacheService<T> : ICacheManager<T> where T : BaseEntity
    {
        protected volatile Dictionary<int, T> cachedUsers = new Dictionary<int, T>();
        public Task<T> Get(int id)
        {
            if (cachedUsers.ContainsKey(id))
            {
                return Task.FromResult(cachedUsers[id]);
            }

            throw new ArgumentException("There is no entity with this id");
        }

        public Task UpdateCache(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (cachedUsers.ContainsKey(item.Id))
                {
                    if (IsApropriate(item))
                    {
                        cachedUsers[item.Id] = item;
                    }
                }
                else
                {
                    cachedUsers.Add(item.Id, item);
                }
            }

            return Task.CompletedTask;
        }

        public abstract bool IsApropriate(T item);
    }
}
