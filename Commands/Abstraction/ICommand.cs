using MediatR;

namespace BandIT.Commands
{
    public interface ICommand<out TOutput> : IRequest<TOutput>
    {

    }
}
