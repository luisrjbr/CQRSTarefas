using System;
using FluentAssertions;
using GerenciadorDeTarefas.Domain.Entities;
using Xunit;

namespace GerenciadorDeTarefasTests.Domain.Entities
{
    public class EntityTests
    {
        [Fact]
        public void Entity_DeveAdicionarNovoGuidEDataCriacao()
        {
            //Given
            var entity = new Entity();

            //Then
            entity.DataCriacao.Should().BeCloseTo(DateTime.Now);
            entity.Id.Should().NotBeEmpty();
        }
    }
}