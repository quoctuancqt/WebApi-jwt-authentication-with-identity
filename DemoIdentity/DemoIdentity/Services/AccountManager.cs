using JwtTokenServer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DemoIdentity.Services
{
    public class AccountManager : IAccountService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountManager(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> GenerateAccountAsync()
        {
            var user = new ApplicationUser { UserName = "admin@a.com", Email = "admin@a.com" };

            var result = await _userManager.CreateAsync(user, "Admin@123");

            if (result.Succeeded)
            {
                return await _userManager.AddToRoleAsync(user, "Admin");
            }

            return result;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAccountAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Username
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                return await _userManager.AddToRoleAsync(user, "User");
            }

            return result;
        }

        public async Task<AccountResult> VerifyAccountAsync(string username, string password, TokenRequest tokenRequest)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

            if (!result.Succeeded) return new AccountResult(new { error = "Invalid usesrname or password" });

            var user = await _userManager.FindByNameAsync(username);

            var userRoles = await _userManager.GetRolesAsync(user);

            tokenRequest.Claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

            tokenRequest.Claims.Add(new Claim(ClaimTypes.Name, username));

            tokenRequest.Claims.Add(new Claim(ClaimTypes.Role, userRoles.FirstOrDefault()));

            return new AccountResult(tokenRequest);
        }
    }
}
