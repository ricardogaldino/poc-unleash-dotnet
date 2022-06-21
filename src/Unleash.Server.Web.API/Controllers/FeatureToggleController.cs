using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Unleash.Server.Web.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("v1/feature-toggle")]
public class FeatureToggleController : ControllerBase
{
    private readonly IUnleash _unleash;

    public FeatureToggleController(IUnleash unleash)
    {
        _unleash = unleash;
    }

    [HttpGet("{id}/status")]
    public IActionResult GetStatus(string id)
    {
        return Ok(_unleash.IsEnabled(id));
    }
}