using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Contracts;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Commands.Builders;

public class ListCommandBuilder
{
    private IFileSystemVisitor? _visitor;
    private ReadFacade? _readFacade;
    private int _depth;

    public ListCommandBuilder WithVisitor(IFileSystemVisitor visitor)
    {
        _visitor = visitor;
        return this;
    }

    public ListCommandBuilder WithReadFacade(ReadFacade readFacade)
    {
        _readFacade = readFacade;
        return this;
    }

    public ListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public ListCommand Build()
    {
        return new ListCommand(
            _visitor ?? throw new ArgumentNullException(nameof(_visitor)),
            _readFacade ?? throw new ArgumentNullException(nameof(_readFacade)),
            _depth);
    }
}