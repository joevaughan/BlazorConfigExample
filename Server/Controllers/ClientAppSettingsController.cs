using BlazorConfigExample.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BlazorConfigExample.Server.Controllers
{
    [ApiController]
    public class ClientAppSettingsController : ControllerBase
    {
        private readonly ClientAppOptions options;

        public ClientAppSettingsController(IOptions<ClientAppOptions> options)
        {
            this.options = options?.Value;
        }

        [HttpGet("/appsettings")]
        public IActionResult GetAppSettings() => Ok(options);
    }
}