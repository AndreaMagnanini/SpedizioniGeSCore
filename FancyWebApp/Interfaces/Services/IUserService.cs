// <copyright file="IUserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Interfaces.Services
{
    using FancyWebApp.Models;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The user service interface.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Performs the log in for a user given its username and its hashed pwd.
        /// </summary>
        /// <param name="userName">The required username.</param>
        /// <param name="password">The required associated password.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<PasswordVerificationResult> Login(string userName, string password);

        /// <summary>
        /// Performs the registration in the system for a new user.
        /// </summary>
        /// <param name="user">The new user data.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<User> Register(User user);
    }
}