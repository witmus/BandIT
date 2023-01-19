using BandIT.Models.Entities.Abstract;
using BandIT.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BandIT.Models.Entities
{
    public class Event : BandEntity<Event>
    {
        [MaxLength(30)]
        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string? Description { get; set; }
        public EventType EventType { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        [ForeignKey("ContactId")]
        [InverseProperty("Events")]
        public virtual Contact? Contact { get; set; }
        public int? ContactId { get; set; }

        public override void Update(Event entity)
        {
            base.Update(entity);

            Name = entity.Name;
            Description = entity.Description;
            EventType = entity.EventType;
            Start = entity.Start;
            End = entity.End;
            ContactId = entity.ContactId;
        }
    }
}
