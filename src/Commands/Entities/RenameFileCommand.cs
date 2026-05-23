using Itmo.ObjectOrientedProgramming.Contracts;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Commands.Entities;

public class RenameFileCommand : ICommand
{
    private readonly NavigationFacade _navigationFacade;
    private readonly string _path;
    private readonly string _newName;

    public RenameFileCommand(
        NavigationFacade navigationFacade,
        string path,
        string newName)
    {
        _navigationFacade = navigationFacade;
        _path = path;
        _newName = newName;
    }

    public void Execute()
    {
        if (string.IsNullOrWhiteSpace(_path) || string.IsNullOrWhiteSpace(_newName)) return;
        _navigationFacade.RenameFile(_path, _newName);
    }
}