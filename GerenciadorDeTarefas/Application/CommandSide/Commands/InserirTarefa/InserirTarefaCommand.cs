using MediatR;

namespace GerenciadorDeTarefas.Application.CommandSide.Commands.InserirTarefa
{
    public class InserirTarefaCommand: IRequest
    {
        public InserirTarefaCommand(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        public string Titulo { get; }
        public string Descricao { get; }
    }
}