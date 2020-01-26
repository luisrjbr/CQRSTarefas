using System;

namespace GerenciadorDeTarefas.Domain.Entities
{
    public class Tarefa: Entity
    {
        private const int QuantidadeMaximaDeCaracteresDoTitulo = 30;
        private const int QuantidadeMaximaDeCaracteresDaDescricao = 100;

        public Tarefa(string titulo, string descricao)
        {
            ValidaTitulo(titulo);
            ValidaDescricao(descricao);
            
            Titulo = titulo;
            Descricao = descricao;
        }

        public string Titulo { get; private set;  }
        public string Descricao { get; private set;  }
        public DateTime DataDeConclusao { get; private set;  }

        public Tarefa Atualizar(string novaDescricao)
        {
            ValidaDescricao(novaDescricao);
            
            Descricao = novaDescricao;
            return this;
        }

        public Tarefa Completar()
        {
            DataDeConclusao = DateTime.Now;
            return this;
        }
        
        public static void ValidaTitulo(string titulo)
        {
            if (String.IsNullOrEmpty(titulo))
                throw new Exception("Titulo deve possuir conteudo");

            if (titulo.Length > QuantidadeMaximaDeCaracteresDoTitulo)
                throw new Exception("Titulo deve possuir no maximo 30 caracteres");
        }

        public static void ValidaDescricao(string descricao)
        {
            if (String.IsNullOrEmpty(descricao))
                throw new Exception("Descricao deve possuir conteudo");

            if (descricao.Length > QuantidadeMaximaDeCaracteresDaDescricao)
                throw new Exception("Descricao deve possuir no maximo 100 caracteres");
        }
    }
}