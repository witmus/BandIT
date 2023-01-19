using BandIT.Models.DTO;

namespace BandIT.Queries.Events.GetBandEvents
{
    public class GetBandEventsRequest : IQuery<List<EventDto>>
    {
        public int Month { get; init; }
        public int Year { get; init; }
        public int BandId { get; init; }
    }
}
