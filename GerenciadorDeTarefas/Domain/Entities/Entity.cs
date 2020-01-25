using System;

namespace GerenciadorDeTarefas.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            Id = new Guid();
            DataCriacao = DateTime.Now;
        }

        public Guid Id { get; }
        public DateTime DataCriacao { get; }
    }
}