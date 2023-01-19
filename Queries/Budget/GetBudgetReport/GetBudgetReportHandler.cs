using BandIT.Models.DTO;
using BandIT.Models.Entities;
using BandIT.Queries.Budget.GetBandPositions;
using MediatR;
using System.Text;

namespace BandIT.Queries.Budget.GetBudgetReport
{
    public class GetBudgetReportHandler : IQueryHandler<GetBudgetReportRequest, string>
    {
        private readonly ISender _sender;

        public GetBudgetReportHandler(ISender sender)
        {
            _sender = sender;
        }

        public async Task<string> Handle(GetBudgetReportRequest request, CancellationToken cancellationToken)
        {
            var getPositionsRequest = new GetBandPositionsRequest()
            {
                Year = request.Year,
                Month = request.Month,
                BandId = request.BandId,
            };

            var positions = await _sender.Send(getPositionsRequest);

            if(positions is not null && positions.Count > 0)
            {
                return GetReportFromPositions(positions);
            }

            return string.Empty;
        }

        private string GetReportFromPositions(List<BudgetPositionDto> positions)
        {
            var csv = new StringBuilder();
            csv.AppendLine("nazwa,kwota,data,typ,opis");

            foreach(var position in positions)
            {
                csv.AppendLine($"{position.Name},{position.Amount},{position.Date},{position.PositionType},{position.Description}");
            }

            return csv.ToString();
        }
    }
}
