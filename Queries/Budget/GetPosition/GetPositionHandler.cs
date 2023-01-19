using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Queries.Budget.GetPosition
{
    public class GetPositionHandler : IQueryHandler<GetPositionRequest, BudgetPositionDto>
    {
        private readonly IBudgetRepository _budgetContext;

        public GetPositionHandler(IBudgetRepository budgetContext)
        {
            _budgetContext = budgetContext;
        }

        public async Task<BudgetPositionDto> Handle(GetPositionRequest request, CancellationToken cancellationToken)
        {
            return new(await _budgetContext.GetByIdAsync(request.PositionId));
        }
    }
}
