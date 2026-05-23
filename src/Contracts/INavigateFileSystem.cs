namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface INavigateFileSystem
{
    public string? CurrentPath { get; set; }

    public void ChangeDirectory(string path);

    public void MoveFile(string sourcePath, string destinationPath);

    public void CopyFile(string sourcePath, string destinationPath);

    public void DeleteFile(string path);

    public void RenameFile(string path, string newName);
}