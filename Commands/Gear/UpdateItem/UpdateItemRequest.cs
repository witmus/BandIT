using BandIT.Models.DTO;
using BandIT.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BandIT.Commands.Gear.UpdateItem
{
    public class UpdateItemRequest : ICommand<GearItemDto>
    {
        [Required(ErrorMessage = "NO_ID")]
        public int Id { get; init; }

        [Required(ErrorMessage = "NO_NAME")]
        public string Name { get; init; }
        public GearType GearType { get; init; }
        public int Weight { get; init; }
    }
}
