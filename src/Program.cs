using Itmo.ObjectOrientedProgramming.Entities;
using Itmo.ObjectOrientedProgramming.Facades;
using Itmo.ObjectOrientedProgramming.Factories;

namespace Itmo.ObjectOrientedProgramming;

public class Program
{
    public static void Main(string[] args)
    {
        var navigator = new LocalFileNavigator();
        var reader = new LocalFileReader(navigator);
        var connector = new LocalFileSystemConnection(navigator);

        var connectionFacade = new ConnectionFacade(connector);
        var navigationFacade = new NavigationFacade(navigator);
        var readFacade = new ReadFacade(reader, navigator);

        var commandHandlerFactory =
            new CommandHandlerFactory(connectionFacade, navigationFacade, readFacade);

        var commandParser = new CommandParser(commandHandlerFactory);

        var consoleInterface = new ConsoleInterface(commandParser);

        consoleInterface.Run();
    }
}