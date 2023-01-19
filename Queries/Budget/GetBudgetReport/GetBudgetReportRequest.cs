namespace BandIT.Queries.Budget.GetBudgetReport
{
    public class GetBudgetReportRequest : IQuery<string>
    {
        public int Month { get; init; } = DateTime.UtcNow.Month;
        public int Year { get; init; } = DateTime.UtcNow.Year;
        public int BandId { get; init; }
    }
}
