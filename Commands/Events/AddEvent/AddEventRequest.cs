using BandIT.Models.DTO;
using BandIT.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BandIT.Commands.Events.AddEvent
{
    public class AddEventRequest : ICommand<EventDto>
    {
        [Required(ErrorMessage = "NO_NAME")]
        public string Name { get; init; }

        [Required(ErrorMessage = "NO_BAND_ID")]
        public int BandId { get; init; }
        public string? Description { get; init; }
        public EventType EventType { get; init; }
        public DateTime Start { get; init; }
        public DateTime? End { get; init; }
        public int? ContactId { get; init; }
    }
}
