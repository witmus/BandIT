using MediatR;

namespace BandIT.Commands
{
    public interface ICommandHandler<in TCommand, TOutput> : IRequestHandler<TCommand, TOutput> where TCommand : ICommand<TOutput>
    {

    }
}
