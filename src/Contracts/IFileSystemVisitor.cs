using Itmo.ObjectOrientedProgramming.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface IFileSystemVisitor
{
    public void VisitFile(FileComponent file);

    public void VisitDirectory(DirectoryComponent directory);
}