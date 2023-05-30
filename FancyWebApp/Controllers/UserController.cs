using FancyWebApp.Exceptions;
using FancyWebApp.Interfaces.Services;
using FancyWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FancyWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;

    public UserController(IUserService userService, UserManager<User> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        try
        {
            var result = await this._userService.Login(user.UserName, user.HashedPassword);
            if (result == PasswordVerificationResult.Success ||
                result == PasswordVerificationResult.SuccessRehashNeeded)
                return this.Ok();
            else return this.Unauthorized();
        }
        catch (NotFoundException ex)
        {
            return this.NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return this.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(User user)
    {
        try
        {
            var newUser = await this._userService.Register(user);
            if (user != null)
            {
                return this.Ok();
            }
            else return this.Unauthorized();
        }
        catch (BadRequestException ex)
        {
            return this.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return this.Problem(ex.Message);
        }
    }
}