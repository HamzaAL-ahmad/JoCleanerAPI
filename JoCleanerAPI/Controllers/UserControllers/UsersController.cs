using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JoCleanerAPI.Controllers.UserControllers
{
    [ApiController()]
    //[Authorize]
    public class UsersController : Controller
    {
        [HttpGet("tests")]
        public async Task<IActionResult> test()
        {
            return Ok("This is protected data");
        }
    }
}
