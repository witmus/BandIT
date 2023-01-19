using BandIT.Models.DTO;

namespace BandIT.Queries.Bands.GetBandMembers
{
    public class GetBandMembersRequest : IQuery<List<UserDto>>
    {
        public int BandId { get; init; }
    }
}
