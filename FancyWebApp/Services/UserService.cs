// <copyright file="UserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Services
{
    using System.Security.Cryptography;
    using FancyWebApp.Exceptions;
    using FancyWebApp.Interfaces.Repositories;
    using FancyWebApp.Interfaces.Services;
    using FancyWebApp.Models;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The user service.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository instance.</param>
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <inheritdoc/>
        public async Task<PasswordVerificationResult> Login(string userName, string password)
        {
            var user = await this.userRepository.GetUserByUserName(userName);
            if (user == null)
            {
                throw new NotFoundException($"No user found with username: {userName}");
            }

            if (this.VerifyPassword(password, user.Salt))
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }

        /// <inheritdoc/>
        public async Task<User> Register(User user)
        {
            var existingUser = await this.userRepository.GetUserByUserName(user.UserName);
            if (existingUser != null)
            {
                throw new BadRequestException($"User {user.UserName} already exists.");
            }

            var hashSalt = this.EncryptPassword(user.HashedPassword);
            user.HashedPassword = hashSalt.Hash;
            user.Salt = hashSalt.Salt;
            await this.userRepository.Register(user);
            return user;
        }

        private HashSalt EncryptPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 12000,
                numBytesRequested: 256 / 8));
            return new HashSalt() { Hash = hashedPassword, Salt = salt };
        }

        private bool VerifyPassword(string givenPassword, byte[] salt)
        {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: givenPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 12000,
                numBytesRequested: 256 / 8));
            return hashedPassword == givenPassword;
        }
    }

    /// <summary>
    /// The hash salt class, used to perform hashing and hash-back.
    /// </summary>
#pragma warning disable SA1402 // File may only contain a single type
    public class HashSalt
#pragma warning restore SA1402 // File may only contain a single type
    {
        /// <summary>
        /// Gets or sets the hashed value.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Gets or sets the salt value.
        /// </summary>
        public byte[] Salt { get; set; }
    }
}
