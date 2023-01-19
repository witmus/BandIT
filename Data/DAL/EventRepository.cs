using BandIT.Data.DAL.Abstraction;
using BandIT.Models.Entities;

namespace BandIT.Data.DAL
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext db, ILogger<Event> logger) : base(db, logger)
        {

        }
    }
}
