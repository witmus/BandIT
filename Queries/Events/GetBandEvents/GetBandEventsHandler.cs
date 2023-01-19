using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Queries.Events.GetBandEvents
{
    public class GetBandEventsHandler : IQueryHandler<GetBandEventsRequest, List<EventDto>>
    {
        private readonly IEventRepository _eventsContext;

        public GetBandEventsHandler(IEventRepository eventsContext)
        {
            _eventsContext = eventsContext;
        }

        public Task<List<EventDto>> Handle(GetBandEventsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_eventsContext
                .GetByBandId(request.BandId)
                .ToList()
                .Select(e => new EventDto(e))
                .ToList());
        }
    }
}
