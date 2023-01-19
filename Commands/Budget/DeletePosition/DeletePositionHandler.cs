using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Commands.Budget.DeletePosition
{
    public class DeletePositionHandler : ICommandHandler<DeletePositionRequest, BudgetPositionDto>
    {
        private readonly IBudgetRepository _budgetContext;

        public DeletePositionHandler(IBudgetRepository budgetContext)
        {
            _budgetContext = budgetContext;
        }

        public async Task<BudgetPositionDto> Handle(DeletePositionRequest request, CancellationToken cancellationToken)
        {
            var position = await _budgetContext.GetByIdAsync(request.PositionId);

            position = _budgetContext.Delete(position);

            await _budgetContext.CommitAsync();

            return new(position);
        }
    }
}
