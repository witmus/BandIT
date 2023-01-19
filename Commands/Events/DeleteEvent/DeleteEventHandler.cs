using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Commands.Events.DeleteEvent
{
    public class DeleteEventHandler : ICommandHandler<DeleteEventRequest, EventDto>
    {
        private readonly IEventRepository _eventContext;

        public DeleteEventHandler(IEventRepository eventContext)
        {
            _eventContext = eventContext;
        }

        public async Task<EventDto> Handle(DeleteEventRequest request, CancellationToken cancellationToken)
        {
            var deletedEvent = await _eventContext.GetByIdAsync(request.EventId);
            deletedEvent = _eventContext.Delete(deletedEvent);
            await _eventContext.CommitAsync();
            return new(deletedEvent);
        }
    }
}
