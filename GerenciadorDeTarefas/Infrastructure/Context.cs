using GerenciadorDeTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Infrastructure
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options){}
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tarefa>().HasKey(tarefa => tarefa.Id);
            base.OnModelCreating(builder);
        }
    }
}