using BandIT.Models.DTO;

namespace BandIT.Queries.Events.GetEvent
{
    public class GetEventRequest : IQuery<EventDto>
    {
        public int EventId { get; init; }
    }
}
