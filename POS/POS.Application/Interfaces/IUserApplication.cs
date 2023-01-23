using POS.Application.Commons.Base;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Infrastructure.Commons.Bases.Response;

namespace POS.Application.Interfaces;

public interface IUserApplication
{
    Task<BaseReponse<IEnumerable<UserSelectResponseDto>>> ListSelectUser();
    Task<BaseReponse<UserResponseDto>> UserById(int UserId);
    Task<BaseReponse<bool>> RegisterUser(UserRequestDto requestDto);
    Task<BaseReponse<bool>> EditUser(int UserId, UserRequestDto requestDto);
    Task<BaseReponse<bool>> RemoveUser(int UserId);
}
