using BandIT.Models.DTO;

namespace BandIT.Queries.Budget.GetBandPositions
{
    public class GetBandPositionsRequest : IQuery<List<BudgetPositionDto>>
    {
        public int Month { get; init; } = DateTime.UtcNow.Month;
        public int Year { get; init; } = DateTime.UtcNow.Year;
        public int BandId { get; init; }
    }
}
