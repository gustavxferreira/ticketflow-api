using TicketFlowApi.Services.Interfaces;
using TicketFlowApi.Data;
using TicketFlowApi.Models;
using Microsoft.EntityFrameworkCore;
using TicketFlowApi.DTOs.Response;

namespace TicketFlowApi.Services;

public class CategoriesService : ICategoriesService
{
    private readonly AppDbContext _context;

    public CategoriesService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AreaDTO>> GetAreasWithCategoriesAsync()
    {
        return await _context.Areas
            .Select(a => new AreaDTO
            {
                Id = a.Id,
                Name = a.Name,
                Categories = a.Categories != null
                    ? a.Categories.Select(c => new CategoryDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        // CreatedAt = c.CreatedAt,
                        Subcategories = c.Subcategories != null
                            ? c.Subcategories.Select(s => new SubcategoryDTO
                            {
                                Id = s.Id,
                                Name = s.Name
                            }).ToList()
                            : new List<SubcategoryDTO>()
                    }).ToList()
                    : new List<CategoryDTO>()
            })
            .ToListAsync();
    }
}
