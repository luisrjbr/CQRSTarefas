using GerenciadorDeTarefas.Application.QuerySide.ViewModels;
using MediatR;

namespace GerenciadorDeTarefas.Application.QuerySide.Queries.ObtemTodasAsTarefas
{
    public class ObtemTodasAsTarefasQuery: IRequest<TarefaViewModel[]>
    { }
}