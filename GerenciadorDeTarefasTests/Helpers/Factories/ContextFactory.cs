using System;
using GerenciadorDeTarefas.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefasTests.Helpers.Factories
{
    public class ContextFactory
    {
        public static Context Create()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            return new Context(options);
        }
    }
}