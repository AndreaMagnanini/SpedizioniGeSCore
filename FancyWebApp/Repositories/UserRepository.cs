using FancyWebApp.DataBase;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FancyWebApp.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ShipmentDB _db;

    public UserRepository(ShipmentDB db)
    {
        _db = db;
    }

    public async Task<User?> GetUserByUserName(string userName) =>
        await this._db.Users.FirstOrDefaultAsync(u => u.UserName == userName);

    public async Task Register(User user)
    {
        await this._db.Users.AddAsync(user);
        await this._db.SaveChangesAsync();
    }
}
    