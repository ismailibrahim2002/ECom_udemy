using ECom_db.Base.Auth;
using ECom_db.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Repos.AuthRepos
{
    public class RoleManagment(UserManager<AppUser> userManager) : IRoleManegment
    {
        public async Task<bool> AddUserToRole(AppUser user, string roleName)
        {
            return (await userManager.AddToRoleAsync(user, roleName)).Succeeded;
            
        }

        public async Task<string?> GetUserRole(string userEmail)
        {
            var user = await userManager.FindByEmailAsync(userEmail);
            return (await userManager.GetRolesAsync(user!)).FirstOrDefault();
        }
    }

}
