using BandIT.Models.Entities;
using BandIT.Models.Enums;

namespace BandIT.Models.DTO
{
    public class GearItemDto : BandEntityDto<GearItem>
    {
        public string Name { get; init; } = string.Empty;
        public GearType GearType { get; init; }
        public int Weight { get; init; }

        public EventDto? Rental { get; init; }
        public EventDto? Service { get; init; }
        public UserDto? Owner { get; init; }

        public GearItemDto(GearItem entity) : base(entity)
        {
            Name = entity.Name;
            GearType = entity.GearType;
            Weight = entity.Weight;

            if(entity.Rental is not null)
            {
                Rental = new(entity.Rental);
            }

            if (entity.Service is not null)
            {
                Service = new(entity.Service);
            }

            if(entity.Owner is not null)
            {
                Owner = new(entity.Owner);
            }
        }
    }
}
