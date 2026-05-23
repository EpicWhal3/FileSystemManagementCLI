using Itmo.ObjectOrientedProgramming.Commands.Entities;

namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface IFileSystemVisitor
{
    void VisitFile(FileComponent file);

    void VisitDirectory(DirectoryComponent directory);
}