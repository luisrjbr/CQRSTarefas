using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GerenciadorDeTarefas.Application.QuerySide.ViewModels;
using GerenciadorDeTarefas.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Application.QuerySide.Queries.ObtemTodasAsTarefas
{
    public class ObtemTodasAsTarefasQueryHandler
        : IRequestHandler<ObtemTodasAsTarefasQuery, TarefaViewModel[]>
    {
        private readonly Context _context;

        public ObtemTodasAsTarefasQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<TarefaViewModel[]> Handle(ObtemTodasAsTarefasQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tarefas.Select(tarefa => new TarefaViewModel()
            {
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao
            }).ToArrayAsync();
        }
    }
}