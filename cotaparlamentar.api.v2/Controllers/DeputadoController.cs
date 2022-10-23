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
        public IActionResult BuscaTodosDeputadoNovosSite()
        {
            try
            {
                _deputadoService.BuscaTodosDeputadoNovosSite();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("AtualizacaoDeputados")]
        public IActionResult AtualizacaoDeputados()
        {
            try
            {
                _deputadoService.BuscaTodosDeputadosSiteCompletoPorIdPerfil();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("AtualizacaoDeputados/{idperfil:int}")]
        public IActionResult AtualizacaoDeputadosGet(int idperfil)
        {
            try
            {
                _deputadoService.BuscaTodosDeputadosSiteCompletoPorIdPerfil(idperfil);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
