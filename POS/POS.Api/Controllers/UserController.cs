using Microsoft.AspNetCore.Mvc;
using POS.Application.Dtos.Request;
using POS.Application.Interfaces;

namespace POS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserApplication _userApplication;

    public UserController(IUserApplication userApplication)
    {
        _userApplication = userApplication;
    }

    [HttpGet]
    [Route("Select")]
    public async Task<IActionResult> ListSelectUser()
    {
        var response = await _userApplication.ListSelectUser();
        return Ok(response);
    }

    [HttpGet]
    [Route("{userId:int}")]
    public async Task<IActionResult> UserById(int userId){
        var resposen = await _userApplication.UserById(userId);
        return Ok(resposen);
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto requestDto){
        var response = await _userApplication.RegisterUser(requestDto);
        return Ok(response);
    }

    [HttpPut]
    [Route("Edit/{userId:int}")]
    public async Task<IActionResult> EditUser(int userId,[FromBody] UserRequestDto requestDto){
        var response = await _userApplication.EditUser(userId, requestDto);
        return Ok(response);
    }

    [HttpPut]
    [Route("Remove/{userId:int}")]
    public async Task<IActionResult> RemoveUser(int userId){
        var response = await _userApplication.RemoveUser(userId);
        return Ok(response);
    }
}
