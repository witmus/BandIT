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
            var start = new DateTime(request.Year, request.Month, 1);
            var end = start.AddDays(DateTime.DaysInMonth(request.Year, request.Month));

            return Task.FromResult(_eventsContext
                .GetByBandId(request.BandId)
                .Where(p => 
                    (p.Start >= start && p.End <= end) ||
                    (p.Start <= start && p.End >= end) ||
                    (p.End >= start && p.End <= end) ||
                    (p.Start >= start && p.Start <= end)
                )
                .OrderBy(p => p.Start)
                .ToList()
                .Select(e => new EventDto(e))
                .ToList());
        }
    }
}
