namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface IConnectFileSystem
{
    public void Connect(string address, string? mode);

    public void Disconnect();
}