using Itmo.ObjectOrientedProgramming.Contracts;

namespace Itmo.ObjectOrientedProgramming.Commands.Entities;

public class DirectoryComponent : IFileSystemComponent
{
    private readonly List<IFileSystemComponent> _components = new();

    public string Path { get; }

    public DirectoryComponent(string path)
    {
        Path = path;
    }

    public void AddComponent(IFileSystemComponent component)
    {
        _components.Add(component);
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        visitor.VisitDirectory(this);
        foreach (IFileSystemComponent component in _components)
        {
            component.Accept(visitor);
        }
    }
}