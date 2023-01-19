using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Queries.Events.GetEvent
{
    public class GetEventHandler : IQueryHandler<GetEventRequest, EventDto>
    {
        private readonly IEventRepository _eventsContext;

        public GetEventHandler(IEventRepository eventsContext)
        {
            _eventsContext = eventsContext;
        }

        public async Task<EventDto> Handle(GetEventRequest request, CancellationToken cancellationToken)
        {
            return new(await _eventsContext.GetByIdAsync(request.EventId));
        }
    }
}
