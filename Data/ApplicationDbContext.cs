using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BandIT.Models.Entities;

namespace BandIT.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<BudgetPosition> BudgetPositions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<GearItem> GearItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
