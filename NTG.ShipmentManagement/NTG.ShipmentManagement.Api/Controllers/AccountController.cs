using Microsoft.AspNetCore.Mvc;
using NTG.ShipmentManagement.Applicaiton.Contracts.Authentication;
using NTG.ShipmentManagement.Applicaiton.Models;
using NTG.ShipmentManagement.Applicaiton.UserLogin;

namespace NTG.ShipmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticatinService authentication;

        public AccountController(IAuthenticatinService authentication)
        {
            this.authentication = authentication;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(UserLoginDto request)
        {
            return Ok(await this.authentication.Login(request));
        }
    }
}
