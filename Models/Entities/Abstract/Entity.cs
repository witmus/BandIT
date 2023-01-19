using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BandIT.Models.Entities.Abstract
{
    public abstract class Entity<T> where T : Entity<T>
    {
        [Key]
        public int Id { get; set; }

        public DateTime AddedTimestamp { get; set; } = DateTime.UtcNow;

        public virtual void Update(T entity)
        {

        }
    }
}
