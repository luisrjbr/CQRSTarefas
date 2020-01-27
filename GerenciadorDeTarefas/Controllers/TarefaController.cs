using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TarefaController: ControllerBase
    {
        private readonly Mediator _mediator;

        public TarefaController(Mediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<ActionResult> Insere()
        {
            return await Task.FromResult(Ok());
        }

        [HttpPost]
        public async Task<ActionResult> Completa()
        {
            return await Task.FromResult<ActionResult>(Ok());
        }

        [HttpGet]
        public async Task<ActionResult> ObtemTodas()
        {
            return await Task.FromResult<ActionResult>(Ok());
        }

        [HttpGet]
        public async Task<ActionResult> ObtemAbertas()
        {
            return await Task.FromResult<ActionResult>(Ok());
        }
    }
}