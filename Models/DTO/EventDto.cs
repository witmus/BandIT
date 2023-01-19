using BandIT.Models.Entities;
using BandIT.Models.Enums;

namespace BandIT.Models.DTO
{
    public class EventDto : BandEntityDto<Event>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public EventType EventType { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public ContactDto? Contact { get; set; }

        public EventDto(Event entity) : base(entity)
        {
            Name = entity.Name;
            Description = entity.Description;
            EventType = entity.EventType;
            Start = entity.Start;
            End = entity.End;

            if(entity?.Contact is not null)
            {
                Contact = new ContactDto(entity.Contact);
            }
        }
    }
}
