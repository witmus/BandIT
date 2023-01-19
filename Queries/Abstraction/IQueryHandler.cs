using MediatR;

namespace BandIT.Queries
{
    public interface IQueryHandler<in TQuery, TOutput> : IRequestHandler<TQuery, TOutput> where TQuery : IQuery<TOutput>
    {

    }
}
