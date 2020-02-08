using System.Threading.Tasks;
using GerenciadorDeTarefas.Application.CommandSide.Commands.InserirTarefa;
using GerenciadorDeTarefas.Application.QuerySide.Queries.ObtemTodasAsTarefas;
using GerenciadorDeTarefas.REST.Payloads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.REST.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TarefaController: ControllerBase
    {
        private readonly IMediator _mediator;

        public TarefaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<ActionResult> Insere(InsereTarefaPayload request)
        {
            var command = new InserirTarefaCommand(request.Titulo, request.Descricao);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Completa()
        {
            return await Task.FromResult<ActionResult>(Ok());
        }

        [HttpGet]
        public async Task<ActionResult> ObtemTodas()
        {
            var result = await _mediator.Send(new ObtemTodasAsTarefasQuery());
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> ObtemAbertas()
        {
            return await Task.FromResult<ActionResult>(Ok());
        }
    }
}