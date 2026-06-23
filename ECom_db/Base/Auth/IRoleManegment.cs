using ECom_db.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Base.Auth
{
    //عشان اجيب الرول بتاع اليوزر   2 و اضيف الرول ليوزر
    public interface IRoleManegment
    {
        Task<string> GetUserRole(string UserEmail);
        Task<bool> AddUserToRole(AppUser appUser,string RoleName);
    }
}
