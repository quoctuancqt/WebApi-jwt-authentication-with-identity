using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("AdminPolicy")]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;

            return Ok("Admin Controller");
        }
    }
}
