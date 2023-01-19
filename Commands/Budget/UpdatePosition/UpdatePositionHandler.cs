using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Commands.Budget.UpdatePosition
{
    public class UpdatePositionHandler : ICommandHandler<UpdatePositionRequest, BudgetPositionDto>
    {
        private readonly IBudgetRepository _budgetContext;

        public UpdatePositionHandler(IBudgetRepository budgetContext)
        {
            _budgetContext = budgetContext;
        }

        public async Task<BudgetPositionDto> Handle(UpdatePositionRequest request, CancellationToken cancellationToken)
        {
            var position = await _budgetContext.GetByIdAsync(request.Id);

            position.Update(new()
            {
                Name = request.Name,
                Amount = request.Amount,
                Date = request.Date,
                PositionType = request.PositionType,
                Description = request.Description,
                EventId = request.EventId
            });

            position = _budgetContext.Update(position);

            await _budgetContext.CommitAsync();

            return new(position);
        }
    }
}
