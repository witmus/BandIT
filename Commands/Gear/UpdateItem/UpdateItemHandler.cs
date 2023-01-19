using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Commands.Gear.UpdateItem
{
    public class UpdateItemHandler : ICommandHandler<UpdateItemRequest, GearItemDto>
    {
        private readonly IGearRepository _gearContext;

        public UpdateItemHandler(IGearRepository gearContext)
        {
            _gearContext = gearContext;
        }

        public async Task<GearItemDto> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
        {
            var item = await _gearContext.GetByIdAsync(request.Id);

            item.Update(new()
            {
                Name = request.Name,
                GearType = request.GearType,
                Weight = request.Weight,
            });

            item = _gearContext.Update(item);
            await _gearContext.CommitAsync();

            return new(item);
        }
    }
}
