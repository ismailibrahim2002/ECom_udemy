using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ECom_db.Base.Auth
{
    public interface ITokenManegment
    {
        string GetRefreshToken();
        List<Claim> GetUserClamesFromToken(string email);
        Task<bool> ValidateRefreshToken(string refreshToken);
        Task<string> GetUserIdByRefreshToken(string refreshToken);
        Task<int> AddRefreshToken(string userId, string refreshToken);
        Task<int> UpdateRefreshToken(string userId, string refreshToken);
        Task<bool> UserHasRefreshToken(string userId);
        string GenrateToken(List<Claim> claims);
    }
}
