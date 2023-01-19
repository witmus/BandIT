using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Queries.Budget.GetBandPositions
{
    public class GetBandPositionsHandler : IQueryHandler<GetBandPositionsRequest, List<BudgetPositionDto>>
    {
        private readonly IBudgetRepository _budgetContext;

        public GetBandPositionsHandler(IBudgetRepository budgetContext)
        {
            _budgetContext = budgetContext;
        }

        public Task<List<BudgetPositionDto>> Handle(GetBandPositionsRequest request, CancellationToken cancellationToken)
        {
            var start = new DateTime(request.Year, request.Month, 1);
            var end = start.AddDays(DateTime.DaysInMonth(request.Year, request.Month));

            return Task.FromResult(_budgetContext
                .GetByBandId(request.BandId)
                .Where(p => p.Date >= start && p.Date <= end)
                .OrderBy(p => p.Date)
                .ToList()
                .Select(p => new BudgetPositionDto(p))
                .ToList());
        }
    }
}
