using TicketFlowApi.Data;
using Microsoft.EntityFrameworkCore;
using TicketFlowApi.DTOs.Response;
using TicketFlowApi.Repositories.Interfaces;

namespace TicketFlowApi.Repositories;

public class CalledRepository : ICalledRepository
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public CalledRepository(IConfiguration configuration, IDbContextFactory<AppDbContext> contextFactory)
    {
        _configuration = configuration;
        _contextFactory = contextFactory;
        _context = _contextFactory.CreateDbContext();
    }

    public async Task<CalledDetailsDto?> FindCalled(int Id, int UserId)
    {        
        var calleds = await _context.Calleds
                .Where(c => c.UserId == UserId && c.Id == Id)
                .Select(c => new CalledDetailsDto
                {
                    AreaName = c.CallMetadata!.Area!.Name,
                    CategoryName = c.CallMetadata.Category!.Name,
                    SubcategoryName = c.CallMetadata.Subcategory!.Name,
                    CalledSubject = c.Subject,
                    CalledDescription = c.Description,
                    SuggestionAI = c.CallMetadata!.SuggestionAI!,
                    DateOpen = c.CallMetadata.DateOpen,
                    DateClosed = c.CallMetadata.DateClosed,
                    AssignedTo = c.CallMetadata.AssignedTo,
                    ReasonForClosing = c.CallMetadata.ReasonForClosing,
                    Step = c.CallMetadata.Step.GetDescription()
                })
                .FirstOrDefaultAsync();

        return calleds;
    }
    
    public async Task<List<CalledsList>> GetMyCalleds(int userId)
    {
        var calleds = await _context.Calleds
                .Where(c => c.UserId == userId)
                .Select(c => new CalledsList
                {
                    AreaName = c.CallMetadata!.Area!.Name,
                    CategoryName = c.CallMetadata.Category!.Name,
                    SubcategoryName = c.CallMetadata.Subcategory!.Name,
                    CalledSubject = c.Subject,
                    DateOpen = c.CallMetadata.DateOpen,
                    DateClosed = c.CallMetadata.DateClosed,
                    Step = c.CallMetadata.Step.GetDescription()
                })
                .ToListAsync();

        return calleds;
    }
}
