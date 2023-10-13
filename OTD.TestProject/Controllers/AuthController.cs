using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTD.Business.Abstract;
using OTD.Core.Models;

namespace OTD.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly IAuthBusiness authBusiness;
        readonly IAuthBusiness authBusiness;

        public AuthController(IAuthBusiness authBusiness)
        {
            this.authBusiness = authBusiness;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task <ActionResult<UserLoginResponse>> LoginUserAsync([FromBody] UserLoginRequest request)
        {
            var result = await authBusiness.LoginUserAsync(request);
            return result;
        }

    }
}
