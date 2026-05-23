namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface IConnectFileSystem
{
    void Connect(string address, string? mode);

    void Disconnect();
}