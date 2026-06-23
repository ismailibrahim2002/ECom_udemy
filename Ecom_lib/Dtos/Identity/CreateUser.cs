using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Dtos.Identity
{
    public class CreateUser : BaseUser
    {
        public required string FullName { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
