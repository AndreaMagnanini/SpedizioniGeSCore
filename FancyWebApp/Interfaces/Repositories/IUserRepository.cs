// <copyright file="IUserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Interfaces.Repositories
{
    using FancyWebApp.Models;

    /// <summary>
    /// The user repository interface.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Fetches all user data given its user name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<User?> GetUserByUserName(string userName);

        /// <summary>
        /// Posts a new user entry.
        /// </summary>
        /// <param name="user">The new user data.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task Register(User user);
    }
}