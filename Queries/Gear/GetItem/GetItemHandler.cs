using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Queries.Gear.GetItem
{
    public class GetItemHandler : IQueryHandler<GetItemRequest, GearItemDto>
    {
        private readonly IGearRepository _gearContext;

        public GetItemHandler(IGearRepository gearContext)
        {
            _gearContext = gearContext;
        }

        public async Task<GearItemDto> Handle(GetItemRequest request, CancellationToken cancellationToken)
        {
            return new(await _gearContext.GetByIdAsync(request.ItemId));
        }
    }
}
