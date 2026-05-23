namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface IFileSystemComponent
{
    void Accept(IFileSystemVisitor visitor);
}