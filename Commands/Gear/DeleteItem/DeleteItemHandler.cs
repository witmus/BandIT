using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Commands.Gear.DeleteItem
{
    public class DeleteItemHandler : ICommandHandler<DeleteItemRequest, GearItemDto>
    {
        private readonly IGearRepository _gearContext;

        public DeleteItemHandler(IGearRepository gearContext)
        {
            _gearContext = gearContext;
        }

        public async Task<GearItemDto> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
        {
            var item = await _gearContext.GetByIdAsync(request.ItemId);
            item = _gearContext.Delete(item);
            await _gearContext.CommitAsync();
            return new(item);
        }
    }
}
