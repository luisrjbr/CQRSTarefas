using System.Linq;
using System.Threading;
using FluentAssertions;
using GerenciadorDeTarefas.Application.QuerySide.Queries.ObtemTodasAsTarefas;
using GerenciadorDeTarefas.Domain.Entities;
using GerenciadorDeTarefas.Infrastructure;
using GerenciadorDeTarefasTests.Helpers.Factories;
using Xunit;

namespace GerenciadorDeTarefasTests.Application.QuerySide.Queries
{
    public class ObtemTodasAsTarefasQueryHandlerTests
    {
        private Context _context;

        public ObtemTodasAsTarefasQueryHandlerTests()
        {
            _context = ContextFactory.Create();
        }

        [Fact]
        public async void Handle_DeveRetornarTodosAsTarefas()
        {
            var tarefa1 = new Tarefa("titulo1", "descricao1");
            var tarefa2 = new Tarefa("titulo2", "descricao2");
            var tarefa3 = new Tarefa("titulo3", "descricao3");
            _context.Tarefas.AddRange(tarefa1, tarefa2, tarefa3);
            _context.SaveChanges();
            
            var query = new ObtemTodasAsTarefasQuery();
            var queryHandler = new ObtemTodasAsTarefasQueryHandler(_context);

            var result = await queryHandler.Handle(query, CancellationToken.None);

            result.Should().HaveCount(3);
            var tarefa = result.FirstOrDefault(tarefaResult => tarefaResult.Titulo == tarefa1.Titulo);
            tarefa.Titulo.Should().Be(tarefa1.Titulo);
            tarefa.Descricao.Should().Be(tarefa1.Descricao);
        }
    }
}