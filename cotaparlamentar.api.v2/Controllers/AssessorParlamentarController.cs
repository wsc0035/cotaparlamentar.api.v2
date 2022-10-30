using cotaparlamentar.api.v2.AppService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace cotaparlamentar.api.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessorParlamentarController : ControllerBase
    {
        private readonly AssessorParlamentarService _contextAccessor;
        public AssessorParlamentarController(AssessorParlamentarService contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public IActionResult GetAsessorParlamentar(int nuDeputadoId, int idperfil)
        {
            try
            {
                return Ok(_contextAccessor.BuscarAssessorParlamentar(nuDeputadoId, idperfil));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Atualizar")]
        public string Atualizar()
        {
            var watch = Stopwatch.StartNew();
            var retorno = _contextAccessor.AtualizarAssessor();
            watch.Stop();
            return $"{retorno} Tempo: {watch.ElapsedMilliseconds / 1000}s";
        }
    }
}
