using cotaparlamentar.api.v2.AppService;
using Microsoft.AspNetCore.Mvc;

namespace cotaparlamentar.api.v2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CotaParlamentarController : ControllerBase
{
    private readonly CotaParlamentarService _cotaParlamentarService;
    public CotaParlamentarController(CotaParlamentarService cotaParlamentarService)
    {
        _cotaParlamentarService = cotaParlamentarService;
    }

    [HttpGet]
    public IActionResult ObterCotaParlamentarPorData(string data)
    {
        try
        {
            return Ok(_cotaParlamentarService.BuscarCotaParlamentarPorData(data));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ObterCotaParlamentarPorDataId")]
    public IActionResult ObterCotaParlamentarPorDataId(string data, int nuDeputadoId)
    {
        try
        {                
            return Ok(_cotaParlamentarService.BuscarCotaParlamentarPorDataId(data, nuDeputadoId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
