using BandIT.Models.DTO;

namespace BandIT.Commands.Events.DeleteEvent
{
    public class DeleteEventRequest : ICommand<EventDto>
    {
        public int EventId { get; init; }
    }
}
