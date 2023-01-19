using BandIT.Models.Entities;

namespace BandIT.Models.DTO
{
    public class BandDto : BaseDto<Band>
    {
        public string Name { get; init; }
        public string TaxIdentificationNumber { get; init; }
        public string AccessCode { get; init; }


        public BandDto(Band entity) : base(entity)
        {
            Name = entity.Name;
            TaxIdentificationNumber = entity.TaxIdentificationNumber ?? string.Empty;
            AccessCode = entity.AccessCode ?? string.Empty;
        }
    }
}
