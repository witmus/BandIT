using BandIT.Models.DTO;

namespace BandIT.Commands.Gear.DeleteItem
{
    public class DeleteItemRequest : ICommand<GearItemDto>
    {
        public int ItemId { get; init; }
    }
}
