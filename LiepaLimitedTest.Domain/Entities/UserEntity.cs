using LiepaLimitedTest.Domain.DataTypes;

namespace LiepaLimitedTest.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }     
        public Status Status { get; set; }
    }
}
