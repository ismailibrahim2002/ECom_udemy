using ECom_db.Base.Auth;
using ECom_db.Context;
using ECom_db.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ECom_db.Repos.AuthRepos
{
    public class UserManagement( IRoleManegment role, UserManager<AppUser> userManager, AppDbContext context) : IUserManagement
    {
        public async Task<bool> CreateUser(AppUser user)
        {
            var _user = await GetUserByEmail(user.Email!);
            if (_user == null)
            {
                return (await userManager.CreateAsync(user, user.PasswordHash!)).Succeeded;
                
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<AppUser?> GetUserByEmail(string userEmail)
        {
            return await userManager.FindByEmailAsync(userEmail);
        }

        public async Task<AppUser?> GetuserById(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            return user;
        }

        public async Task<List<Claim>> GetUserClaims(string userEmail)
        {
            var _user = await GetUserByEmail(userEmail);
            string? roleName = await role.GetUserRole(_user!.Email!);
            List<Claim> claims =
                [
                    new Claim("fullName", _user!.FullName!),
                    new Claim(ClaimTypes.NameIdentifier, _user.Id),
                    new Claim(ClaimTypes.Email, _user!.Email!),
                    new Claim(ClaimTypes.Role, roleName!)
                ];
            return claims;
        }

        public async Task<bool> LogInUser(AppUser user)
        {
            var _user = await GetUserByEmail(user!.Email!);
            if (_user == null) return false;
            var roleName = await role.GetUserRole(user!.Email!);
            if (string.IsNullOrEmpty(roleName)) return false;
            return await userManager.CheckPasswordAsync(_user, user.PasswordHash!);
        }

        public async Task<int> RemoveUserById(string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == userId);
            context.Users.Remove(user!);
            return await context.SaveChangesAsync();
        }
    }
}
