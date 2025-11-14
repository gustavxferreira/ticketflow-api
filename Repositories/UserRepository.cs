using TicketFlowApi.Data;
using Microsoft.EntityFrameworkCore;
using TicketFlowApi.DTOs.Response;
using TicketFlowApi.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TicketFlowApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public UserRepository(IConfiguration configuration, IDbContextFactory<AppDbContext> contextFactory)
    {
        _configuration = configuration;
        _contextFactory = contextFactory;
        _context = _contextFactory.CreateDbContext();
    }

    public async Task<UserAuthenticatedDTO?> FindUser(string email, string password)
    {
        var user = await _context.Users
            .Where(u => u.Email == email && u.Password == password)
            .Select(user => new UserAuthenticatedDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Username,
                Role = "admin"
            })
            .FirstOrDefaultAsync();

        if (user == null) return null;

        user.Token = GenerateToken(user.Email, user.Role, user.Id);

        return user;
    }

    private string GenerateToken(string email, string role, int id)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
