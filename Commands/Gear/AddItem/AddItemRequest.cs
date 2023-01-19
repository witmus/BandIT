using BandIT.Models.DTO;
using BandIT.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BandIT.Commands.Gear.AddItem
{
    public class AddItemRequest : ICommand<GearItemDto>
    {
        [Required(ErrorMessage = "NO_NAME")]
        public string Name { get; init; }

        [Required(ErrorMessage = "NO_BAND_ID")]
        public int BandId { get; init; }
        public GearType GearType { get; init; }
        public int Weight { get; init; }
    }
}
