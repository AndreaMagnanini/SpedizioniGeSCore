// <copyright file="UserController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Controllers
{
    using FancyWebApp.Exceptions;
    using FancyWebApp.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The user controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service instance.</param>
        /// <param name="userManager">The user manager instance.</param>
        public UserController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        /// <summary>
        /// Executes the POST Request to perform authentication for a user.
        /// </summary>
        /// <param name="user">The user data.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            try
            {
                var result = await this.userService.Login(user.UserName, user.HashedPassword);
                if (result == PasswordVerificationResult.Success ||
                    result == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    return this.Ok();
                }

                return this.Unauthorized();
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

        /// <summary>
        /// Executes the POST Request to perform a new user registrations.
        /// </summary>
        /// <param name="user">The new user data.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            try
            {
                var newUser = await this.userService.Register(user);
                if (user != null)
                {
                    return this.Ok(newUser);
                }

                return this.Unauthorized();
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
}