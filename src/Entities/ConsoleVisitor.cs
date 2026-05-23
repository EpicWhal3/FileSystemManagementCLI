using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Contracts;

namespace Itmo.ObjectOrientedProgramming.Entities;

public class ConsoleVisitor : IFileSystemVisitor
{
    public void VisitFile(FileComponent file)
    {
        Console.WriteLine($"[F] {file.Path}");
    }

    public void VisitDirectory(DirectoryComponent directory)
    {
        Console.WriteLine($"[D] {directory.Path}");
    }
}