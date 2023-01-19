using BandIT.Models.DTO;

namespace BandIT.Queries.Budget.GetPosition
{
    public class GetPositionRequest : IQuery<BudgetPositionDto>
    {
        public int PositionId { get; init; }
    }
}
