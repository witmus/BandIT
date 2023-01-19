using BandIT.Models.DTO;
using BandIT.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BandIT.Commands.Budget.UpdatePosition
{
    public class UpdatePositionRequest : ICommand<BudgetPositionDto>
    {
        [Required(ErrorMessage = "NO_ID")]
        public int Id { get; init; }

        [Required(ErrorMessage = "NO_NAME")]
        public string Name { get; init; } = string.Empty;

        [Required(ErrorMessage = "NO_AMOUNT")]
        public float Amount { get; init; }
        public DateTime Date { get; init; }
        public PositionType PositionType { get; init; }
        public string? Description { get; init; }
        public int? EventId { get; init; }
    }
}
