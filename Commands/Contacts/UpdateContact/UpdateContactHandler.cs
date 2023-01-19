using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;

namespace BandIT.Commands.Contacts.UpdateContact
{
    public class UpdateContactHandler : ICommandHandler<UpdateContactRequest, ContactDto>
    {
        private readonly IContactRepository _contactsContext;

        public UpdateContactHandler(IContactRepository contactsContext)
        {
            _contactsContext = contactsContext;
        }

        public async Task<ContactDto> Handle(UpdateContactRequest request, CancellationToken cancellationToken)
        {
            var contact = await _contactsContext.GetByIdAsync(request.Id);

            contact.Update(new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ContactType = request.ContactType,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress,
                Description = request.Description
            });

            contact = _contactsContext.Update(contact);

            await _contactsContext.CommitAsync();

            return new(contact);
        }
    }
}
