using System;

namespace GerenciadorDeTarefas.Domain.Entities
{
    public class Tarefa
    {
        public Tarefa(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        public string Titulo { get; }
        public string Descricao { get; }
        public DateTime DataDeConclusao { get; }

        public Tarefa Atualizar(string novaDescricao)
        {
            throw new System.NotImplementedException();
        }

        public void Completar()
        {
            throw new System.NotImplementedException();
        }
    }
}