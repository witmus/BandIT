using BandIT.Models.Entities.Abstract;
using BandIT.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BandIT.Models.Entities
{
    public class BudgetPosition : BandEntity<BudgetPosition>
    {
        [MaxLength(50)]
        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public PositionType PositionType { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [ForeignKey("EventId")]
        public virtual Event? Event { get; set; }
        public int? EventId { get; set; }

        public override void Update(BudgetPosition entity)
        {
            base.Update(entity);

            Name = entity.Name;
            Amount = entity.Amount;
            Date = entity.Date;
            PositionType = entity.PositionType;
            Description = entity.Description;
            EventId = entity.EventId;
        }
    }
}
