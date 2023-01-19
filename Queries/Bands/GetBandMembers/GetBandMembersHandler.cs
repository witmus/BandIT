using BandIT.Data;
using BandIT.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace BandIT.Queries.Bands.GetBandMembers
{
    public class GetBandMembersHandler : IQueryHandler<GetBandMembersRequest, List<UserDto>>
    {
        private readonly ApplicationDbContext _db;
        public GetBandMembersHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<UserDto>> Handle(GetBandMembersRequest request, CancellationToken cancellationToken)
        {
            var users = await _db
                .Users.Where(u => u.BandId == request.BandId)
                .ToListAsync();

            return users
                .Select(u => new UserDto(u))
                .ToList();
        }
    }
}
