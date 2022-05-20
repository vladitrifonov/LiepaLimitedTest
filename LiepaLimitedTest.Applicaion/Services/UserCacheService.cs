using LiepaLimitedTest.Domain.Contracts;
using LiepaLimitedTest.Domain.Entities;

namespace LiepaLimitedTest.Applicaion.Services
{
    public class UserCacheService : CacheService<UserEntity>
    {
        public override bool IsApropriate(UserEntity item)
        {
            return cachedUsers[item.Id].Name != item.Name || cachedUsers[item.Id].Status != item.Status;
        }
    }
}
