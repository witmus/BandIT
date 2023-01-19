using BandIT.Models.Entities.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BandIT.Models.Entities
{
    public class Band : Entity<Band>
    {
        [MaxLength(50)]
        [DefaultValue("")]
        public string Name { get; set; } = "";

        [MaxLength(20)]
        public string? TaxIdentificationNumber { get; set; }

        [MaxLength(10)]
        public string? AccessCode { get; set; }

        public override void Update(Band entity)
        {
            base.Update(entity);

            Name = entity.Name;
            TaxIdentificationNumber = entity.TaxIdentificationNumber;
            AccessCode = entity.AccessCode;
        }
    }
}
