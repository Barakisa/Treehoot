using Microsoft.AspNetCore.Mvc;
using Treehoot.Api.Dtos;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<PostUserLoginResponse> Login([FromBody] PostUserLoginRequest userCredentials)
    {
        //validation
        if (String.IsNullOrEmpty(userCredentials.Email) 
            || String.IsNullOrEmpty(userCredentials.Password))
        {
            return new PostUserLoginResponse(){ Success = false,  Message = "Empty credentials" };
        }
        //service
        var loginResult = await _userService.LogIn(userCredentials.Email, userCredentials.Password);
        //maping
        return new PostUserLoginResponse(){Success = !String.IsNullOrEmpty(loginResult.Key), Username = loginResult.Key, Message = loginResult.Value};
    }

    [HttpPost("register")]
    public async Task<PostUserRegisterResponse> Register([FromBody] PostUserRegisterRequest userCredentials)
    {
        //validation
        
        if (String.IsNullOrEmpty(userCredentials.Username) 
            || String.IsNullOrEmpty(userCredentials.Password) 
            || String.IsNullOrEmpty(userCredentials.Email))
        {
            return new PostUserRegisterResponse() { Success = false, Message = "Empty credentials" };
        }
        //service
        var registerResult = await _userService.Register(userCredentials.Email, userCredentials.Username, userCredentials.Password);
        //maping
        return new PostUserRegisterResponse() { Success = registerResult.Key, Message = registerResult.Value };
    }
}
