using BandIT.Models.Entities.Abstract;

namespace BandIT.Models.DTO
{
    public abstract class BaseDto<T> where T : Entity<T>
    {
        public int Id { get; init; }
        public DateTime AddedTimestamp { get; init; }

        public BaseDto(T entity)
        {
            Id = entity.Id;
            AddedTimestamp = entity.AddedTimestamp;
        }
    }
}
