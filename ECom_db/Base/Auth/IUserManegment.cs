using ECom_db.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ECom_db.Base.Auth
{
    //كانه الريبوز بتاع اليوزر
    public interface IUserManagement
    {
        Task<bool> CreateUser(AppUser user);
        Task<bool> LogInUser(AppUser user);
        Task<AppUser?> GetUserByEmail(string userEmail);
        Task<AppUser?> GetuserById(string userId);
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<int> RemoveUserById(string userId);
        Task<List<Claim>> GetUserClaims(string userEmail);
    }
}
