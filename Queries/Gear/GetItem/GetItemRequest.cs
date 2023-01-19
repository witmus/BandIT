using BandIT.Models.DTO;

namespace BandIT.Queries.Gear.GetItem
{
    public class GetItemRequest : IQuery<GearItemDto>
    {
        public int ItemId { get; init; }
    }
}
