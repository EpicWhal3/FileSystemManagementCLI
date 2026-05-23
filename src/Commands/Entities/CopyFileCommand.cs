using Itmo.ObjectOrientedProgramming.Contracts;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Commands.Entities;

public class CopyFileCommand : ICommand
{
    private readonly NavigationFacade _navigationFacade;
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public CopyFileCommand(NavigationFacade navigationFacade, string sourcePath, string destinationPath)
    {
        _navigationFacade = navigationFacade;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute()
    {
        _navigationFacade.CopyFile(_sourcePath, _destinationPath);
    }
}