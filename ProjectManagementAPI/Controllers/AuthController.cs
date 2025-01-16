using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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
}
