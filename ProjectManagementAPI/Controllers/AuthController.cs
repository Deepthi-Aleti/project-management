using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProjectManagementApplication.DTO;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    [Route("token")]
    public async Task<IActionResult> GenerateToken()
    {
        string tenantId = _configuration["AzureAd:TenantId"];
        string clientId = _configuration["AzureAd:ClientId"];
        string clientSecret = _configuration["AzureAd:ClientSecret"];
        string authority = $"{_configuration["AzureAd:Instance"]}{tenantId}";

        var app = ConfidentialClientApplicationBuilder.Create(clientId)
            .WithClientSecret(clientSecret)
            .WithAuthority(new Uri(authority))
            .Build();

        var scopes = new[] { $"{clientId}/.default" }; // Use `.default` to request all app-specific scopes

        try
        {
            var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
            return Ok(new { token = result.AccessToken });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
    }

    // User login using username and password
    [HttpPost]
    [Route("user")]
    public async Task<IActionResult> UserAuthentication([FromBody] UserLoginDto userLogin)
    {
        if (IsValidUser(userLogin))
        {
            return Ok(new { message = "User Authenticated Successfully" });
        }
        else
        {
            return Unauthorized(new { error = "Invalid credentials" });
        }
    }

    private bool IsValidUser(UserLoginDto userLogin)
    {
        var users = _configuration.GetSection("Users").Get<List<UserLoginDto>>();
        return users?.Any(u => u.Username == userLogin.Username && u.Password == userLogin.Password) ?? false;
    }
}
