using LiepaLimitedTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
