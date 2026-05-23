using Itmo.ObjectOrientedProgramming.Contracts;
using Itmo.ObjectOrientedProgramming.Entities;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Commands.Entities;

public class ListCommand : ICommand
{
    private readonly IFileSystemVisitor _visitor;
    private readonly ReadFacade _readFacade;
    private readonly int _depth;

    public ListCommand(
        IFileSystemVisitor visitor,
        ReadFacade readFacade,
        int depth)
    {
        _visitor = visitor;
        _readFacade = readFacade;
        _depth = depth;
    }

    public void Execute()
    {
        string? rootPath = _readFacade.GetCurrentPath();

        if (string.IsNullOrEmpty(rootPath) || !Directory.Exists(rootPath))
        {
            Console.WriteLine("Directory does not exist.");
            return;
        }

        var builder = new FileSystemBuilder();
        IFileSystemComponent? root = builder.Build(rootPath, _depth);

        root?.Accept(_visitor);
    }
}