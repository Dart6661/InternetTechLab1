using Microsoft.Extensions.DependencyInjection;
using Presentation.DI;
using Presentation.Dispatcher;

namespace Presentation;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            ServiceProvider serviceProvider = DIConfig.ConfigureServices();
            using var scope = serviceProvider.CreateAsyncScope();
            CommandDispatcher dispatcher = scope.ServiceProvider.GetRequiredService<CommandDispatcher>();
            await dispatcher.ProcessCommand(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
