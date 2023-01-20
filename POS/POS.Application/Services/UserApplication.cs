using AutoMapper;
using POS.Application.Commons.Base;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Application.Interfaces;
using POS.Application.Validators.User;
using POS.Doamin.Entities;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;

namespace POS.Application.Services;

internal class UserApplication : IUserApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserValidator _validationRules;

    public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, UserValidator validationRules)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validationRules = validationRules;
    }



    public async Task<BaseReponse<IEnumerable<UserSelectResponseDto>>> ListSelectUser()
    {
        var response = new BaseReponse<IEnumerable<UserSelectResponseDto>>();
        var user = await _unitOfWork.User.ListUser();
        if(user is not null)
        {
            response.IsSuccess = true;
            response.Data = _mapper.Map<IEnumerable<UserSelectResponseDto>>(user);
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }
        else
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMTY;
        }
        return response;
    }
    public async Task<BaseReponse<UserResponseDto>> UserById(int UserId)
    {
        var response = new BaseReponse<UserResponseDto>();
        var user = await _unitOfWork.User.UserById(UserId);
        if(user is not null)
        {
            response.IsSuccess = true;
            response.Data = _mapper.Map<UserResponseDto>(user);
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }
        else
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMTY;
        }
        return response;
    }

    public async Task<BaseReponse<bool>> RegisterUser(UserRequestDto requestDto)
    {
        var response = new BaseReponse<bool>();
        var validationResult = await _validationRules.ValidateAsync(requestDto);
        if (!validationResult.IsValid)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_VALIDATE;
            response.Errors = validationResult.Errors;
            return response;
        }
        var user = _mapper.Map<User>(requestDto);
        response.Data = await _unitOfWork.User.RegisterUser(user);
        if (response.Data)
        {
            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_SAVE;
        }
        else
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_FAILED;
        }
        return response;
    }
    public async Task<BaseReponse<bool>> EditUser(int UserId, UserRequestDto requestDto)
    {
        var response = new BaseReponse<bool>();
        var userEdit = await UserById(UserId);
        if(userEdit is not null)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMTY;
        }
        var user = _mapper.Map<User>(requestDto);
        user.UserId = UserId;
        response.Data = await _unitOfWork.User.editUser(user);
        if (response.Data)
        {
            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_UPDATE;
        }
        else
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_FAILED;
        }
        return response;
    }

    public async Task<BaseReponse<bool>> RemoveUser(int UserId)
    {
        var response = new BaseReponse<bool>();
        var user = await UserById(UserId);
        if(user.Data is not null)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMTY;
        }
        response.Data = await _unitOfWork.User.RemoveUser(UserId);
        if (response.Data)
        {
            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_DELETE;
        }
        else
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_QUERY_EMTY;
        }
        return response;
    }
}
