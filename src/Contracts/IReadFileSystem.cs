namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface IReadFileSystem
{
    public IEnumerable<string> ListDirectory(string path, int depth);

    public void ShowFile(string path, string? mode = null);
}