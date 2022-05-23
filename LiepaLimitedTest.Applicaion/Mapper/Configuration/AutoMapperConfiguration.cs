using AutoMapper;
using LiepaLimitedTest.Applicaion.Api.Models;
using LiepaLimitedTest.Domain.Entities;

namespace LiepaLimitedTest.Applicaion.Api.Mapper.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
