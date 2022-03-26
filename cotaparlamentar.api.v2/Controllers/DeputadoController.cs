using cotaparlamentar.api.v2.AppService;
using Microsoft.AspNetCore.Mvc;

namespace cotaparlamentar.api.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeputadoController : ControllerBase
    {
        private readonly DeputadoService _deputadoService;
        public DeputadoController(DeputadoService deputadoService)
        {
            _deputadoService = deputadoService;
        }

        [HttpGet]
        [Route("BuscarTodosDeputadosNovos")]
        public async Task<IActionResult> BuscaTodosDeputadoNovosSite()
        {
            try
            {
                return Ok(await _deputadoService.BuscaTodosDeputadoNovosSite());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AtualizacaoDeputadosPost")]
        public IActionResult AtualizacaoDeputadosPost(int[] idperfis)
        {
            try
            {
                return Ok(_deputadoService.BuscaTodosDeputadosSiteCompletoPorIdPerfil(idperfis));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("AtualizacaoDeputadosGet")]
        public IActionResult AtualizacaoDeputadosGet(int idperfil)
        {
            try
            {
                return Ok(_deputadoService.BuscaTodosDeputadosSiteCompletoPorIdPerfil(new int[] {idperfil}));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
