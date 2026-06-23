using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Dtos
{
    public class LogInResponseDto
    {
        public LogInResponseDto(bool _success = false, string _msessage = "", string token = "", string refreshToken = "")
        {
            success = _success;
            msessage = _msessage;
            Token = token;
            RefreshToken = refreshToken;
        }

        public bool success { get; set; }
        public string msessage { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
