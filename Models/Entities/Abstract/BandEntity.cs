using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BandIT.Models.Entities.Abstract
{
    public class BandEntity<T> : Entity<T> where T : BandEntity<T>
    {
        public int? BandId { get; set; }

        [ForeignKey("BandId")]
        public virtual Band? Band { get; set; }

        public override void Update(T entity)
        {
            base.Update(entity);
        }
    }
}
