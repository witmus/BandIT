using BandIT.Models.DTO;

namespace BandIT.Commands.Budget.DeletePosition
{
    public class DeletePositionRequest : ICommand<BudgetPositionDto>
    {
        public int PositionId { get; init; }
    }
}
