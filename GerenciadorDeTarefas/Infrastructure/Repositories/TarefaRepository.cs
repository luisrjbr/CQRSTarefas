using System;
using System.Threading.Tasks;
using GerenciadorDeTarefas.Domain.Entities;
using GerenciadorDeTarefas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Infrastructure.Repositories
{
    public class TarefaRepository: ITarefaRepository
    {
        private readonly Context _context;

        public TarefaRepository(Context context)
        {
            _context = context;
        }

        public async Task<Tarefa> Insere(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> ObtemPorId(Guid id)
            => await _context.Tarefas.FirstOrDefaultAsync(tarefa => tarefa.Id.Equals(id));

        public async Task<Tarefa> Atualiza(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }
    }
}