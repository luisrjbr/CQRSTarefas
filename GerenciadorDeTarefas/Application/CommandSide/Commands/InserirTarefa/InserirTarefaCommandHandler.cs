using System.Threading;
using System.Threading.Tasks;
using GerenciadorDeTarefas.Domain.Entities;
using GerenciadorDeTarefas.Domain.Repositories;
using MediatR;

namespace GerenciadorDeTarefas.Application.CommandSide.Commands.InserirTarefa
{
    public class InserirTarefaCommandHandler: IRequestHandler<InserirTarefaCommand>
    {
        private readonly ITarefaRepository _repository;

        public InserirTarefaCommandHandler(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(InserirTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = new Tarefa(request.Titulo, request.Descricao);
            await _repository.Insere(tarefa);
            return  Unit.Value;
        }
    }
}