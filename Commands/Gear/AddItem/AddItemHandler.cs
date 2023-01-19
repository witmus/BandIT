using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;
using BandIT.Models.Entities;

namespace BandIT.Commands.Gear.AddItem
{
    public class AddItemHandler : ICommandHandler<AddItemRequest, GearItemDto>
    {
        private readonly IGearRepository _gearContext;

        public AddItemHandler(IGearRepository gearContext)
        {
            _gearContext = gearContext;
        }

        public async Task<GearItemDto> Handle(AddItemRequest request, CancellationToken cancellationToken)
        {
            var item = new GearItem()
            {
                Name = request.Name,
                GearType = request.GearType,
                Weight = request.Weight,
                BandId = request.BandId,
            };

            item = await _gearContext.CreateAsync(item);
            await _gearContext.CommitAsync();

            return new(item);
        }
    }
}
