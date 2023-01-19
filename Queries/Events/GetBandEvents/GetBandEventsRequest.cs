using BandIT.Models.DTO;

namespace BandIT.Queries.Events.GetBandEvents
{
    public class GetBandEventsRequest : IQuery<List<EventDto>>
    {
        public int BandId { get; init; }
    }
}
