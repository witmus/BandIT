using BandIT.Data.DAL.Abstraction;
using BandIT.Models.Entities;

namespace BandIT.Data.DAL
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext db, ILogger<Contact> logger) : base(db, logger)
        {

        }
    }
}
