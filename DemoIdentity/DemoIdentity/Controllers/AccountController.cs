using DemoIdentity.Services;
using JwtTokenServer.Proxies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("ApiPolicy")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly OAuthClient _oAuthClient;

        public AccountController(IAccountService accountService, OAuthClient oAuthClient)
        {
            _accountService = accountService;
            _oAuthClient = oAuthClient;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _accountService.RegisterAccountAsync(dto);

            if (result.Succeeded) return Ok();

            return BadRequest(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            var result = await _oAuthClient.EnsureApiTokenAsync(dto.Username, dto.Password);

            if (result.Success) return Ok(result.Result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> LogoutAsync()
        {
            await _accountService.LogoutAsync();

            return Ok();
        }

        [HttpGet, Route("generate")]
        [AllowAnonymous]
        public async Task<IActionResult> Generate()
        {
            var result = await _accountService.GenerateAccountAsync();

            if (result.Succeeded) return Ok();

            return BadRequest(result);
        }
    }
}
