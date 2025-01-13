using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenAcquisition _tokenAcquisition;
        public AuthController(ITokenAcquisition tokenAcquisition)
        {
            _tokenAcquisition = tokenAcquisition;
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetAuthToken()
        {
            try
            {
                string[] scopes = { "openid", "profile" };
                string accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scopes);
                return Ok(new { accessToken });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
