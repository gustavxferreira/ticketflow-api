using TicketFlowApi.Services.Interfaces;
using TicketFlowApi.Data;
using TicketFlowApi.Models;
using Microsoft.EntityFrameworkCore;
using TicketFlowApi.Repositories.Interfaces;
using TicketFlowApi.DTOs.Response;

namespace TicketFlowApi.Services;

public class CalledService : ICalledService
{
    private readonly AppDbContext _context;
    private readonly IAIService _aiService;
    private readonly IDbContextFactory<AppDbContext> _contextFactory;
    private readonly ICalledRepository _calledRepository;
    private readonly IUserService _userService;

    public CalledService(IDbContextFactory<AppDbContext> contextFactory, IAIService aiService, ICalledRepository calledRepository, IUserService userService)
    {
        _contextFactory = contextFactory;
        _aiService = aiService;
        _context = _contextFactory.CreateDbContext();
        _calledRepository = calledRepository;
        _userService = userService;
    }

    public async Task<int>  CreateCalledAsync(CalledCreateDTO dto)
    {
        int userId = _userService.GetAuthId();

        var called = new Called
        {
            UserId = userId,
            Subject = dto.Subject,
            Description = dto.Description,
            CallMetadata = new CallMetadata
            {
                AreaId = dto.AreaId,
                CategoryId = dto.CategoryId,
                SubcategoryId = dto.SubCategoryId,
                Priority = dto.Priority,
                EvidencePath = dto.EvidencePath,
                SuggestionAI = null
            }
        };

        _context.Calleds.Add(called);
        await _context.SaveChangesAsync();

        _ = Task.Run(async () =>
        {
            try
            {
                string suggestionAI = await _aiService.Prompt(
                    $"Sugira uma solução para o seguinte problema: {dto.Description}"
                );

                await using var scopedContext = await _contextFactory.CreateDbContextAsync();

                var existingCalled = await scopedContext.Calleds
                    .Include(c => c.CallMetadata)
                    .FirstOrDefaultAsync(c => c.Id == called.Id);

                if (existingCalled != null)
                {
                    existingCalled.CallMetadata!.SuggestionAI = suggestionAI;
                    scopedContext.Update(existingCalled);
                    await scopedContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar sugestão AI: {ex.Message}");
            }
        });
        
        return called.Id;
    }

    public async Task<CalledDetailsDto?> CalledById(int id, int userId)
    {
        return await _calledRepository.FindCalled(id, userId);
    }

    public async Task<List<CalledsList>> GetMyCalleds(int currentUserId)
    {
        List<CalledsList> calleds = await _calledRepository.GetMyCalleds(currentUserId);

        return calleds;
    }

}
