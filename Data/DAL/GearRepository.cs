using BandIT.Data.DAL.Abstraction;
using BandIT.Models.Entities;

namespace BandIT.Data.DAL
{
    public class GearRepository : BaseRepository<GearItem>, IGearRepository
    {
        public GearRepository(ApplicationDbContext db, ILogger<GearItem> logger) : base(db, logger)
        {

        }
    }
}
