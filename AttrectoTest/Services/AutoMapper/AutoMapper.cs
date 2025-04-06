using System.Linq.Expressions;
using AttrectoTest.Models.DTOs;
using AttrectoTest.Models.Entities;
using AutoMapper;

namespace AttrectoTest.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserSaveDTO, User>().ForMember(dest => dest.Password,
                opt => opt.MapFrom(src => HashHelper.HashPassword(src.Password)))
                                            .ForMember(dest => dest.Id, opt => opt.AllowNull());
        }
    }
}
