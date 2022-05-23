using LiepaLimitedTest.Domain.Entities;
using System.Collections.Generic;

namespace LiepaLimitedTest.Infrastructure.Dapper.Data
{
    public class UserHelper : CommonHelper
    {
        protected override IEnumerable<string> GetFields()
        {
            yield return nameof(UserEntity.Name);
            yield return nameof(UserEntity.Status);          
        }
    }
}
