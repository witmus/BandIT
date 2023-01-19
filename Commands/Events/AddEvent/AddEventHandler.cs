using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;
using BandIT.Models.Entities;

namespace BandIT.Commands.Events.AddEvent
{
    public class AddEventHandler : ICommandHandler<AddEventRequest, EventDto>
    {
        private readonly IEventRepository _eventContext;

        public AddEventHandler(IEventRepository eventContext)
        {
            _eventContext = eventContext;
        }

        public async Task<EventDto> Handle(AddEventRequest request, CancellationToken cancellationToken)
        {
            var addedEvent = new Event()
            {
                Name = request.Name,
                Description = request.Description,
                EventType = request.EventType,
                Start = request.Start,
                End = request.End,
                BandId = request.BandId,
                ContactId = request.ContactId,
            };
            
            addedEvent = await _eventContext.CreateAsync(addedEvent);
            await _eventContext.CommitAsync();

            return new(addedEvent);
        }
    }
}
