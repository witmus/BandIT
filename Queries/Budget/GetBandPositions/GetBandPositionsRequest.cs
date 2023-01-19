using BandIT.Models.DTO;

namespace BandIT.Queries.Budget.GetBandPositions
{
    public class GetBandPositionsRequest : IQuery<List<BudgetPositionDto>>
    {
        public int Month { get; init; }
        public int Year { get; init; }
        public int BandId { get; init; }
    }
}
