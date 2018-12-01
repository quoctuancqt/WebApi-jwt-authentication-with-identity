using JwtTokenServer.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DemoIdentity.Services
{
    public interface IAccountService : IAccountManager
    {
        Task<IdentityResult> RegisterAccountAsync(RegisterDto dto);

        Task LogoutAsync();

        Task<IdentityResult> GenerateAccountAsync();
    }
}
