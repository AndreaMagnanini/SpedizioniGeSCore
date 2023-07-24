// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>using FancyWebApp.DataBase;

namespace FancyWebApp.Repositories
{
    using FancyWebApp.DataBase;
    using FancyWebApp.Interfaces.Repositories;
    using FancyWebApp.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The repository linked to User entity.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The database instance.
        /// </summary>
        private readonly ShipmentDb db;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="db">The database instance.</param>
        public UserRepository(ShipmentDb db)
        {
            this.db = db;
        }

        /// <summary>
        /// Fetches an user given its name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<User?> GetUserByUserName(string userName) =>
            await this.db.Users.FirstOrDefaultAsync(u => u.UserName == userName);

        /// <summary>
        /// Registers a user.
        /// </summary>
        /// <param name="user">The given user.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Register(User user)
        {
            await this.db.Users.AddAsync(user);
            await this.db.SaveChangesAsync();
        }
    }
}