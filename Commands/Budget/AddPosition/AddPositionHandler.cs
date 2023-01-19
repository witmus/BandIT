using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;
using BandIT.Models.Entities;

namespace BandIT.Commands.Budget.AddPosition
{
    public class AddPositionHandler : ICommandHandler<AddPositionRequest, BudgetPositionDto>
    {
        private readonly IBudgetRepository _budgetContext;

        public AddPositionHandler(IBudgetRepository budgetContext)
        {
            _budgetContext = budgetContext;
        }

        public async Task<BudgetPositionDto> Handle(AddPositionRequest request, CancellationToken cancellationToken)
        {
            var position = new BudgetPosition()
            {
                Name = request.Name,
                Amount = request.Amount,
                Date = request.Date,
                PositionType = request.PositionType,
                Description = request.Description,
                EventId = request.EventId,
                BandId = request.BandId,
            };

            position = await _budgetContext.CreateAsync(position);
            await _budgetContext.CommitAsync();

            return new(position);
        }
    }
}
