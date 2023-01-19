using BandIT.Models.Entities.Abstract;

namespace BandIT.Models.DTO
{
    public abstract class BandEntityDto<T> : BaseDto<T> where T : BandEntity<T>
    {
        public BandDto Band { get; init; }

        protected BandEntityDto(T entity) : base(entity)
        {
            Band = new(entity?.Band ?? new());
        }
    }
}
