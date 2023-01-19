using MediatR;

namespace BandIT.Queries
{
    public interface IQuery<out TOutput> : IRequest<TOutput>
    {

    }
}
