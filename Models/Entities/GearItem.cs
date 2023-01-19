using BandIT.Models.Entities.Abstract;
using BandIT.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BandIT.Models.Entities
{
    public class GearItem : BandEntity<GearItem>
    {
        [MaxLength(30)]
        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;

        [DefaultValue(0)]
        public GearType GearType { get; set; }

        [DefaultValue(0)]
        public int Weight { get; set; }

        [ForeignKey("RentalId")]
        public virtual Event? Rental { get; set; }
        public int? RentalId { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Event? Service { get; set; }
        public int? ServiceId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User? Owner { get; set; }
        public string? OwnerId { get; set; }

        public override void Update(GearItem entity)
        {
            base.Update(entity);

            Name = entity.Name;
            GearType = entity.GearType;
            Weight = entity.Weight;
            RentalId = entity.RentalId;
            ServiceId = entity.ServiceId;
            OwnerId = entity.OwnerId;
        }
    }
}
