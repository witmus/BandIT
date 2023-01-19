using BandIT.Models.Entities;
using BandIT.Models.Enums;

namespace BandIT.Models.DTO
{
    public class BudgetPositionDto : BandEntityDto<BudgetPosition>
    {
        public string Name { get; set; } = string.Empty;
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public PositionType PositionType { get; set; }
        public string? Description { get; set; }
        public EventDto? Event { get; set; }

        public BudgetPositionDto(BudgetPosition entity) : base(entity)
        {
            Name = entity.Name;
            Amount = entity.Amount;
            Date = entity.Date;
            PositionType = entity.PositionType;
            Description = entity.Description;

            if(entity.Event is not null)
            {
                Event = new(entity.Event);
            }
        }
    }
}
