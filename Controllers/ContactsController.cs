using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MediatR;
using BandIT.Queries.Contacts.GetBandContacts;
using BandIT.Queries.Contacts.GetContact;
using BandIT.Commands.Contacts.AddContact;
using BandIT.Commands.Contacts.UpdateContact;
using BandIT.Commands.Contacts.DeleteContact;
using BandIT.Models.DTO;

namespace BandIT.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/contacts"), Produces("application/json")]
    public class ContactsController : ControllerBase
    {
        private readonly ISender _sender;

        public ContactsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetContactAsync(int contactId, CancellationToken cancellationToken)
        {
            var request = new GetContactRequest()
            {
                ContactId = contactId,
            };

            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpGet("list/{bandId}")]
        [ProducesResponseType(typeof(List<ContactDto>), 200)]
        public async Task<IActionResult> GetBandContactsAsync(int bandId, CancellationToken cancellationToken)
        {
            var request = new GetBandContactsRequest()
            {
                BandId = bandId
            };

            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddContactAsync([FromBody]AddContactRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactAsync([FromBody] UpdateContactRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContactAsync([FromBody] DeleteContactRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _sender.Send(request, cancellationToken));
        }
    }
}
