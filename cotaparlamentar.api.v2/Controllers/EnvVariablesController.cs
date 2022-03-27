using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cotaparlamentar.api.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvVariablesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Varaveis(string var)
        {
            try
            {
                var ApiUrl = Environment.GetEnvironmentVariable("ApiUrl");
                var Legislatura = Environment.GetEnvironmentVariable("Legislatura");
                return Ok($"ApiUrl = {ApiUrl}, Legislatura = {Legislatura}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
