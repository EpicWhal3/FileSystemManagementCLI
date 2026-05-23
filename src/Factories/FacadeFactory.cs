using Itmo.ObjectOrientedProgramming.Entities;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Factories;

public class FacadeFactory
{
    public ConnectionFacade CreateConnectionFacade()
    {
        var navigator = new LocalFileNavigator();
        var fileSystemConnection = new LocalFileSystemConnection(navigator);
        return new ConnectionFacade(fileSystemConnection);
    }

    public NavigationFacade CreateNavigationFacade()
    {
        var navigator = new LocalFileNavigator();
        return new NavigationFacade(navigator);
    }

    public ReadFacade CreateReadFacade()
    {
        var navigator = new LocalFileNavigator();
        var fileReader = new LocalFileReader(navigator);
        return new ReadFacade(fileReader, navigator);
    }

    public LocalFileNavigator CreateNavigator()
    {
        return new LocalFileNavigator();
    }
}