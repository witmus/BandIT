using BandIT.Data;
using BandIT.Models.DTO;
using BandIT.Models.Entities;
using BandIT.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings;

namespace BandIT.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public AuthController(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _configuration = configuration;
        }

        
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(UserDto), 200)]
        [Route("user")]
        public async Task<IActionResult> GetUserInfoAsync()
        {
            var userName = GetUserNameFromToken();
            var user = await _userManager.FindByNameAsync(userName);
            
            return Ok(new UserDto(user));
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), 200)]
        [Route("users/{bandId}")]
        public async Task<IActionResult> GetUsersListAsync(int bandId)
        {
            var users = (await _userManager.Users
                .Where(u => u.BandId == bandId)
                .ToListAsync())
                .Select(u => new UserDto(u));

            return Ok(users);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            var userName = Encoding.UTF8.GetString(Convert.FromBase64String(dto.UserName));
            var password = Encoding.UTF8.GetString(Convert.FromBase64String(dto.Password));

            var user = await _userManager.FindByNameAsync(userName);

            if(user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.UserName),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach(var role in userRoles)
                {
                    authClaims.Add(new(ClaimTypes.Role, role));
                }

                var token = GenerateToken(authClaims);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto dto)
        {
            if ((await _userManager.FindByEmailAsync(dto.Email)) != null)
                return BadRequest("EMAIL_TAKEN");
            if ((await _userManager.FindByNameAsync(dto.UserName)) != null)
                return BadRequest("USERNAME_TAKEN");

            Band band;
            if(dto.Role == UserRole.BandMember)
            {
                band = _db.Bands.FirstOrDefault(b => b.AccessCode == dto.AccessCode);
                if (band == null)
                {
                    return BadRequest("INVALID_CODE");
                }
            }
            else
            {
                band = new()
                {
                    Name = dto.AccessCode,
                    TaxIdentificationNumber = dto.BandTIN,
                    AccessCode = dto.AccessCode,
                };
            }

            var user = new User
            {
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Role = (UserRole)dto.Role,
                Band = band,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(new StatusMessageDto("ERROR", "UserCreationFailed"));

            await _userManager.AddToRoleAsync(user, dto.Role.ToString());

            return Ok(new StatusMessageDto("OK", "UserCreationSuccess"));
        }

        [Authorize]
        [HttpPost]
        [Route("password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordDto dto)
        {
            var username = GetUserNameFromToken();
            var user = await _userManager.FindByNameAsync(username);

            var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
            
            if(result.Succeeded)
                return Ok(new StatusMessageDto("OK", "PasswordChangeSuccess"));

            return BadRequest(result.Errors);
        }

        [Authorize]
        [HttpPatch]
        [ProducesResponseType(typeof(UserDto), 200)]
        [Route("user/{userId}")]
        public async Task<IActionResult> ChangeUserRoleAsync(string userId, [FromQuery] UserRole newRole, [FromQuery] UserRole oldRole)
        {
            var user = await _userManager
                .FindByIdAsync(userId);

            await _userManager.AddToRoleAsync(user, newRole.ToString());
            await _userManager.RemoveFromRoleAsync(user, oldRole.ToString());

            user.Role = newRole;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok(new UserDto(user));

            return BadRequest(result.Errors);
        }

        //[HttpPost]
        //[Route("init")]
        //public async Task<IActionResult> InitializeApplication()
        //{
        //    if((await _userManager.FindByNameAsync("admin")) == null)
        //    {
        //        foreach(var role in Enum.GetNames(typeof(UserRole)))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole(role));
        //        }

        //        var defaultBand = new Band
        //        {
        //            Name = "Default band",
        //            TaxIdentificationNumber = "1234567890"
        //        };

        //        var admin = new User
        //        {
        //            UserName = "admin",
        //            FirstName = "admin",
        //            LastName = "admin",
        //            Email = @"admin@admin.pl",
        //            SecurityStamp = Guid.NewGuid().ToString(),
        //            Band = defaultBand
        //        };

        //        var result = await _userManager.CreateAsync(admin, "admin");

        //        if (!result.Succeeded)
        //            return BadRequest(new StatusMessageDto("ERROR", "AdminCreationFailed"));

        //        await _userManager.AddToRoleAsync(admin, UserRole.BandManager.ToString());

        //        return Ok(new StatusMessageDto("SUCCESS", "AdminCreationSuccess"));
        //    }

        //    return Ok(new StatusMessageDto("WARN", "AdminAlreadyExists"));
        //}

        private JwtSecurityToken GenerateToken(IEnumerable<Claim> claims)
        {
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new(authKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        private string GetUserNameFromToken()
        {
            var token = Request
                .Headers["Authorization"]
                .ToString()
                .Split(' ')[1];

            var decodedToken = new JwtSecurityTokenHandler()
                .ReadJwtToken(token);

            return decodedToken
                .Claims.First(c => c.Type == ClaimTypes.Name).Value;
        }
    }
}
