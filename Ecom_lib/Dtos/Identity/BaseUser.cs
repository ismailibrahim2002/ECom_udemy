using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Dtos.Identity
{
    public class BaseUser
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
