using Ecom_lib.Dtos;
using Ecom_lib.Dtos.Identity;

namespace ECom_udemy.Base
{
    public interface IAuthenticationService
    {
        Task<ResponseDto> CreateUser(CreateUser user);
        Task<LogInResponseDto> LogInUser(LogInUser user);
        Task<LogInResponseDto> RetriveToken(string refreshToken);
    }
}
