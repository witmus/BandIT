using BandIT.Commands.Gear.AddItem;
using BandIT.Commands.Gear.DeleteItem;
using BandIT.Commands.Gear.UpdateItem;
using BandIT.Models.DTO;
using BandIT.Queries.Gear.GetBandItems;
using BandIT.Queries.Gear.GetItem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BandIT.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/gear"), Produces("application/json")]
    public class GearController : ControllerBase
    {
        private readonly ISender _sender;

        public GearController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetItemAsync(int itemId, CancellationToken cancellationToken)
        {
            var request = new GetItemRequest()
            {
                ItemId = itemId,
            };

            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpGet("list/{bandId}")]
        [ProducesResponseType(typeof(List<GearItemDto>), 200)]
        public async Task<IActionResult> GetBandItemsAsync(int bandId, CancellationToken cancellationToken)
        {
            var request = new GetBandItemsRequest()
            {
                BandId = bandId,
            };

            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync([FromBody] AddItemRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemAsync([FromBody] UpdateItemRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItemAsync([FromBody] DeleteItemRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }
    }
}
