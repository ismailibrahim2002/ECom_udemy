using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Entities.Identity
{
    public class AppUser:IdentityUser   
    {
        public string FullName { get; set; }
    }
}
