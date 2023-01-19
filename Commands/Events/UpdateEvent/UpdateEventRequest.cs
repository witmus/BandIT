using BandIT.Models.DTO;
using BandIT.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BandIT.Commands.Events.UpdateEvent
{
    public class UpdateEventRequest : ICommand<EventDto>
    {
        [Required(ErrorMessage = "NO_ID")]
        public int Id { get; init; }

        [Required(ErrorMessage = "NO_FIRST_NAME")]
        public string Name { get; init; }
        public string? Description { get; init; }
        public EventType EventType { get; init; }
        public DateTime Start { get; init; }
        public DateTime? End { get; init; }
        public int? ContactId { get; init; }

    }
}
