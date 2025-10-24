using TicketFlowApi.DTOs;
using TicketFlowApi.Services.Interfaces;
using TicketFlowApi.Data;
using TicketFlowApi.Models;

namespace TicketFlowApi.Services;

public class CalledService : ICalledService
{
    private readonly AppDbContext _context;

    public CalledService(AppDbContext context)
    {
        _context = context;
    }

    // public async Task<bool> ValidateCategoryAsync(int categoryId)
    // {
    //     return await _context.Categories.AnyAsync(c => c.Id == categoryId);
    // }

    public async Task CreateCalledAsync(CalledCreateDTO dto)
    {
        var called = new Called
        {
            UserId = 1,
            Subject = dto.Subject,
            Description = dto.Description,
            CallMetadata = new CallMetadata
            {
                AreaId = dto.AreaId,
                CategoryId = dto.CategoryId,
                SubcategoryId = dto.SubCategoryId,
                Priority = dto.Priority,
                EvidencePath = dto.EvidencePath,
            }
        };

        _context.Calleds.Add(called);
        await _context.SaveChangesAsync();
    }
}
