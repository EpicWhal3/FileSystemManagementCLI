using Itmo.ObjectOrientedProgramming.Contracts;

namespace Itmo.ObjectOrientedProgramming.Commands.Entities;

public class FileComponent : IFileSystemComponent
{
    public string Path { get; }

    public FileComponent(string path)
    {
        Path = path;
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        visitor.VisitFile(this);
    }
}