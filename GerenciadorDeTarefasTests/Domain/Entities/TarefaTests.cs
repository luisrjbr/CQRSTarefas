using System;
using FluentAssertions;
using GerenciadorDeTarefas.Domain.Entities;
using Xunit;

namespace GerenciadorDeTarefasTests.Domain.Entities
{
    public class TarefaTests
    {
        [Fact]
        public void Tarefa_DeveIniciarComTituloEDescricao()
        {
            //Given
            var novoTitulo = "Implementar testes";
            var novaDescricao = "TDD <3";
            //When
            var novaTarefa = new Tarefa(novoTitulo, novaDescricao);

            //Then
            novaTarefa.Titulo.Should().Be(novoTitulo);
            novaTarefa.Descricao.Should().Be(novaDescricao);
        }

        [Fact]
        public void Tarefa_DeveDispararExcessaoQuandoTituloMaiorQue30Caracteres()
        {
            //Given
            var novoTitulo = "Implementar testes, teste com mais de 30";
            var novaDescricao = "TDD <3";

            //When
            Action acao = () => new Tarefa(novoTitulo, novaDescricao);

            //Then
            acao.Should()
                .Throw<Exception>()
                .WithMessage("Titulo deve possuir no maximo 30 caracteres");
        }

        [Fact]
        public void Tarefa_DeveDispararExcessaoQuandoDescricaoMaiorQue100Caracteres()
        {
            //Given
            var novoTitulo = "Implementar testes";
            var novaDescricao = "TDD <3, Descrição com mais de 100 caracteres, Descrição com mais de 100 caracteres, Descrição com mais de 100 caracteres";

            //When
            Action acao = () => new Tarefa(novoTitulo, novaDescricao);

            //Then
            acao.Should()
                .Throw<Exception>()
                .WithMessage("Descricao deve possuir no maximo 100 caracteres");
        }

        [Fact]
        public void Tarefa_DeveDispararErroQuandoTituloForNullOuEmpty()
        {
            //Given
            var novaDescricao = "TDD <3, Descrição com mais de 100 caracteres, Descrição com mais de 100 caracteres, Descrição com mais de 100 caracteres";

            //When
            Action acao = () => new Tarefa(null, novaDescricao);

            //Then
            acao.Should()
                .Throw<Exception>()
                .WithMessage("Titulo deve possuir conteudo");
        }

        [Fact]
        public void Tarefa_DeveDispararErroQuandoDescricaoForNullOuEmpty()
        {
            var novoTitulo = "Implementar testes";

            //When
            Action acao = () => new Tarefa(novoTitulo, null);

            //Then
            acao.Should()
                .Throw<Exception>()
                .WithMessage("Descricao deve possuir conteudo");
        }

        [Fact]
        public void Atualizar_DeveAlterarADescricao()
        {
            //Given
            var titulo = "Implementar testes";
            var description = "TDD <3";
            var tarefa = new Tarefa(titulo, description);
            var novaDescricao = "CQRS <3";

            //When
            tarefa.Atualizar(novaDescricao);

            //Then
            tarefa.Descricao.Should().Be(novaDescricao);
        }

        [Fact]
        public void Update_DeveDispararErroQuandoNovaDescricaoForMaiorDoQue100Caracteres()
        {
            //Given
            var titulo = "Implementar testes";
            var descricao = "Descricao";
            var tarefa = new Tarefa(titulo, descricao);
            var novaDescricao = "TDD <3, Descrição com mais de 100 caracteres, Descrição com mais de 100 caracteres, Descrição com mais de 100 caracteres";

            //When
            Action acao = () => tarefa.Atualizar(novaDescricao);

            //Then
            acao.Should()
                .Throw<Exception>()
                .WithMessage("Descricao deve possuir no maximo 100 caracteres");
        }

        [Fact]
        public void Update_DeveDispararErroQuandoNovaDescricaoForNullOuEmpty()
        {
            //Given
            var titulo = "Implementar testes";
            var descricao = "Descricao";
            var tarefa = new Tarefa(titulo, descricao);
            //When
            Action acao = () => tarefa.Atualizar(null);
            //Then
            acao.Should()
                .Throw<Exception>()
                .WithMessage("Descricao deve possuir conteudo");
        }

        [Fact]
        public void Complete_DeveAdicionarDataDaAcaoEmDateOfConclusion()
        {
            //Given
            var tarefa = new Tarefa("Title", "Description");

            //When
            tarefa.Completar();

            //Then
            tarefa.DataDeConclusao.Should().BeCloseTo(DateTime.Now);
        }
    }
}