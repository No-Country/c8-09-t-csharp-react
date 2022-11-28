using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CohorteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthRoleTest : ControllerBase
    {
        [Authorize(Roles = "User")]
        [HttpGet("AsUser")]
        public string AsUser()
        {
            return "You are an user";
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("AsAdmin")]
        public string AsAdmin()
        {
            return "You are an admin";
        }

        [AllowAnonymous]
        [HttpGet("AsVisitor")]
        public string AsAnonymous()
        {
            return "You are a visitor";
        }

        [Authorize]
        [HttpGet("AsLoggedIn")]
        public string AsLoggedIn()
        {
            return "You are logged in";
        }
    }
}
