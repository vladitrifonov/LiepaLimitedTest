using AutoMapper;
using LiepaLimitedTest.Applicaion.Models;
using LiepaLimitedTest.Domain.Entities;

namespace LiepaLimitedTest.Applicaion.Mapper.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
