namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface IFileSystemComponent
{
    public void Accept(IFileSystemVisitor visitor);
}