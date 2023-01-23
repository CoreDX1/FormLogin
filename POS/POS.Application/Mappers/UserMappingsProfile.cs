using AutoMapper;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Doamin.Entities;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Utilities.Static;

namespace POS.Application.Mappers;

internal class UserMappingsProfile : Profile
{
    public UserMappingsProfile()
    {
        CreateMap<User, UserResponseDto>();
        CreateMap<BaseIntityResponse<User>, BaseIntityResponse<UserResponseDto>>().ReverseMap();
        CreateMap<UserRequestDto, User>();
        CreateMap<User, UserSelectResponseDto>();
    }
}
