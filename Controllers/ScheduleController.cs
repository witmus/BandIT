using BandIT.Commands.Events.AddEvent;
using BandIT.Commands.Events.DeleteEvent;
using BandIT.Commands.Events.UpdateEvent;
using BandIT.Models.DTO;
using BandIT.Queries.Events.GetBandEvents;
using BandIT.Queries.Events.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BandIT.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/schedule"), Produces("application/json")]
    public class ScheduleController : ControllerBase
    {
        private readonly ISender _sender;

        public ScheduleController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetEventAsync(int itemId, CancellationToken cancellationToken)
        {
            var request = new GetEventRequest()
            {
                EventId = itemId,
            };

            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpGet("list/{bandId}")]
        [ProducesResponseType(typeof(List<EventDto>), 200)]
        public async Task<IActionResult> GetBandEventsAsync(int bandId, CancellationToken cancellationToken)
        {
            var request = new GetBandEventsRequest()
            {
                BandId = bandId,
            };

            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddEventAsync([FromBody] AddEventRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEventAsync([FromBody] UpdateEventRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEventAsync([FromBody] DeleteEventRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }
    }
}
