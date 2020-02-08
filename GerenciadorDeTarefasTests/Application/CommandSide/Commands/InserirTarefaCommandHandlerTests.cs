using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GerenciadorDeTarefas.Application.CommandSide.Commands.InserirTarefa;
using GerenciadorDeTarefas.Domain.Repositories;
using GerenciadorDeTarefas.Infrastructure;
using GerenciadorDeTarefas.Infrastructure.Repositories;
using GerenciadorDeTarefasTests.Helpers.Factories;
using Xunit;

namespace GerenciadorDeTarefasTests.Application.CommandSide.Commands
{
    public class InserirTarefaCommandHandlerTests
    {
        private Context _context;
        private ITarefaRepository _repository;
        public InserirTarefaCommandHandlerTests()
        {
                _context = ContextFactory.Create();
                _repository = new TarefaRepository(_context);
        }
        
        [Fact]
        public async void Handle_DeveInserirTarefaComTituloEDescricao()
        {
            var titulo = "Webinar";
            var descricao = "Agora!";
            var command = new InserirTarefaCommand(titulo, descricao);
            var commandHandler = new InserirTarefaCommandHandler(_repository);

            await commandHandler.Handle(command, CancellationToken.None);

            _context.Tarefas.Should().HaveCount(1);
            var tarefa = _context.Tarefas.FirstOrDefault();
            tarefa.Titulo.Should().Be(titulo);
            tarefa.Descricao.Should().Be(descricao);
        }
        
        [Fact]
        public async void Handle_NaoDeveInserirTarefaQuandoTituloForVazio()
        {
            var command = new InserirTarefaCommand("", "");
            var commandHandler = new InserirTarefaCommandHandler(_repository);

            Func<Task> acao = () => commandHandler.Handle(command, CancellationToken.None);
            acao.Should().ThrowExactly<Exception>("Titulo deve possuir conteudo");
        }
        
        [Fact]
        public async void Handle_NaoDeveInserirTarefaQuandoDescricaoForVazio()
        {
            
        }
        
        [Fact]
        public async void Handle_NaoDeveInserirTarefaQuandoTituloForMaiorQue30Caracteres()
        {
            
        }
        
        [Fact]
        public async void Handle_NaoDeveInserirTarefaQuandoDescricaoForMaiorQue30Caracteres()
        {
            
        }
    }
}