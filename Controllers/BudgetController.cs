using BandIT.Commands.Budget.AddPosition;
using BandIT.Commands.Budget.DeletePosition;
using BandIT.Commands.Budget.UpdatePosition;
using BandIT.Models.DTO;
using BandIT.Queries.Budget.GetBandPositions;
using BandIT.Queries.Budget.GetBudgetReport;
using BandIT.Queries.Budget.GetPosition;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BandIT.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/budget"), Produces("application/json")]
    public class BudgetController : ControllerBase
    {
        private readonly ISender _sender;

        public BudgetController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{positionId}")]
        public async Task<IActionResult> GetPositionAsync(int positionId, CancellationToken cancellationToken)
        {
            var request = new GetPositionRequest()
            {
                PositionId = positionId,
            };

            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpGet("list/{bandId}")]
        [ProducesResponseType(typeof(List<BudgetPositionDto>), 200)]
        public async Task<IActionResult> GetBandPositionsAsync(int bandId, [FromQuery]int year, [FromQuery]int month, CancellationToken cancellationToken)
        {
            var request = new GetBandPositionsRequest()
            {
                Year = year,
                Month = month,
                BandId = bandId,
            };

            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddPositionAsync([FromBody] AddPositionRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePositionAsync([FromBody] UpdatePositionRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePositionAsync([FromBody] DeletePositionRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpGet("report")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> GetBudgetReportAsync(int bandId, [FromQuery] int year, [FromQuery] int month, CancellationToken cancellationToken)
        {
            var request = new GetBudgetReportRequest()
            {
                Year = year,
                Month = month,
                BandId = bandId,
            };

            return Ok(await _sender.Send(request));
        }
    }
}
