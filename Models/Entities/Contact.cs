using BandIT.Models.Entities.Abstract;
using BandIT.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BandIT.Models.Entities
{
    public class Contact : BandEntity<Contact>
    {
        [MaxLength(30)]
        [DefaultValue("")]
        public string FirstName { get; set; } = string.Empty;
        public ContactType ContactType { get; set; }

        [MaxLength(30)]
        public string? LastName { get; set; }
        
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        
        [MaxLength(50)]
        public string? EmailAddress { get; set; }
        
        [MaxLength(200)]
        public string? Description { get; set; }

        [InverseProperty("Contact")]
        public virtual ICollection<Event>? Events { get; set; }

        public override void Update(Contact entity)
        {
            base.Update(entity);

            FirstName = entity.FirstName;
            ContactType = entity.ContactType;
            LastName = entity.LastName;
            PhoneNumber = entity.PhoneNumber;
            EmailAddress = entity.EmailAddress;
            Description = entity.Description;
        }
    }
}
