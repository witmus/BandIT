using BandIT.Data.DAL.Abstraction;
using BandIT.Models.DTO;
using BandIT.Models.Entities;

namespace BandIT.Commands.Contacts.AddContact
{
    public class AddContactHandler : ICommandHandler<AddContactRequest, ContactDto>
    {
        private readonly IContactRepository _contactsContext;

        public AddContactHandler(IContactRepository contactsContext)
        {
            _contactsContext = contactsContext;
        }

        public async Task<ContactDto> Handle(AddContactRequest request, CancellationToken cancellationToken)
        {
            var contact = new Contact()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress,
                Description = request.Description,
                BandId = request.BandId
            };

            contact = await _contactsContext.CreateAsync(contact);
            await _contactsContext.CommitAsync();

            return new(contact);
        }
    }
}
