using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Queries.Gear.GetBandItems
{
    public class GetBandItemsHandler : IQueryHandler<GetBandItemsRequest, List<GearItemDto>>
    {
        private readonly IGearRepository _gearContext;

        public GetBandItemsHandler(IGearRepository gearContext)
        {
            _gearContext = gearContext;
        }

        public Task<List<GearItemDto>> Handle(GetBandItemsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_gearContext
                .GetByBandId(request.BandId)
                .ToList()
                .Select(i => new GearItemDto(i))
                .ToList());
        }
    }
}
