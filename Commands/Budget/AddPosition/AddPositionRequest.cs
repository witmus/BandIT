using BandIT.Models.DTO;
using BandIT.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BandIT.Commands.Budget.AddPosition
{
    public class AddPositionRequest : ICommand<BudgetPositionDto>
    {
        [Required(ErrorMessage = "NO_NAME")]
        public string Name { get; init; }

        [Required(ErrorMessage = "NO_AMOUNT")]
        public float Amount { get; init; }

        [Required(ErrorMessage = "NO_BAND_ID")]
        public int BandId { get; init; }
        public DateTime Date { get; init; } = DateTime.Now;
        public PositionType PositionType { get; init; }
        public string? Description { get; init; }
        public int? EventId { get; init; }
    }
}
