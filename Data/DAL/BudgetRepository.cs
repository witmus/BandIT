using BandIT.Data.DAL.Abstraction;
using BandIT.Models.Entities;

namespace BandIT.Data.DAL
{
    public class BudgetRepository : BaseRepository<BudgetPosition>, IBudgetRepository
    {
        public BudgetRepository(ApplicationDbContext db, ILogger<BudgetPosition> logger) : base(db, logger) { }
    }
}
