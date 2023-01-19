using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Commands.Events.UpdateEvent
{
    public class UpdateEventHandler : ICommandHandler<UpdateEventRequest, EventDto>
    {
        private readonly IEventRepository _eventContext;

        public UpdateEventHandler(IEventRepository eventContext)
        {
            _eventContext = eventContext;
        }

        public async Task<EventDto> Handle(UpdateEventRequest request, CancellationToken cancellationToken)
        {
            var updatedEvent = await _eventContext.GetByIdAsync(request.Id);

            updatedEvent.Update(new()
            {
                Name = request.Name,
                Description = request.Description,
                EventType = request.EventType,
                Start = request.Start,
                End = request.End,
                ContactId = request.ContactId
            });

            updatedEvent = _eventContext.Update(updatedEvent);
            await _eventContext.CommitAsync();

            return new(updatedEvent);
        }
    }
}
