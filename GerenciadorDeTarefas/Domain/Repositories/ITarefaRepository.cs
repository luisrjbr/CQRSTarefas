using System;
using System.Threading.Tasks;
using GerenciadorDeTarefas.Domain.Entities;

namespace GerenciadorDeTarefas.Domain.Repositories
{
    public interface ITarefaRepository
    {
        Task<Tarefa> Insere(Tarefa tarefa);
        Task<Tarefa> ObtemPorId(Guid id);
        Task<Tarefa> Atualiza(Tarefa tarefa);
    }
}