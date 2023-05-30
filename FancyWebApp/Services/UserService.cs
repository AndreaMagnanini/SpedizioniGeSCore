using System.Security.Cryptography;
using FancyWebApp.Exceptions;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Interfaces.Services;
using FancyWebApp.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace FancyWebApp.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<PasswordVerificationResult> Login(string userName, string password)
    {
        var user = await this._userRepository.GetUserByUserName(userName);
        if (user == null)
        {
            throw new NotFoundException($"No user found with username: {userName}");
        }

        if (VerifyPassword(password, user.Salt, user.HashedPassword))
        {
            return PasswordVerificationResult.Success;
        }
        else return PasswordVerificationResult.Failed;
    }

    public async Task<User> Register(User user)
    {
        var existingUser = await this._userRepository.GetUserByUserName(user.UserName);
        if (existingUser != null)
        {
            throw new BadRequestException($"User {user.UserName} already exists.");
        }
        var hashSalt = EncryptPassword(user.HashedPassword);
        user.HashedPassword = hashSalt.Hash;
        user.Salt = hashSalt.Salt;
        await this._userRepository.Register(user);
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
            numBytesRequested: 256 / 8
        ));
        return new HashSalt() { Hash = hashedPassword, Salt = salt };
    }

    private bool VerifyPassword(string givenPassword, byte[] salt, string savedPassword)
    {
        string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: givenPassword,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 12000,
            numBytesRequested: 256 / 8
        ));
        return hashedPassword == givenPassword;
    }
}

public class HashSalt
{
    public string Hash { get; set; }
    public byte[] Salt { get; set; }
}