using BandIT.Models.DTO;

namespace BandIT.Queries.Gear.GetBandItems
{
    public class GetBandItemsRequest : IQuery<List<GearItemDto>>
    {
        public int BandId { get; init; }
    }
}
