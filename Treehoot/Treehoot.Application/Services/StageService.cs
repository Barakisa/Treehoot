using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Treehoot.Application.Data;
using Treehoot.Application.Exceptions;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class StageService : IStageService
{

    private readonly TreehootApiContext _treehootApiContext;

    public StageService(TreehootApiContext treehootApiContext)
    {
        _treehootApiContext = treehootApiContext;
    }

    public async Task<Stage?> GetSingle(int stageId)
    {
        return await _treehootApiContext.Stage
                        .Include(s => s.Quiz)
                        .SingleOrDefaultAsync(a => a.Id == stageId);
    }

    public async Task<List<Stage>?> GetQuizStages(int quizId)
    {
        var quiz = await _treehootApiContext.Quiz.FindAsync(quizId);
        if (quiz == null)
        {
            throw new NotFoundException("Quiz", quizId);
        }
        var stages = await _treehootApiContext.Stage
                    .Include(s => s.Quiz)
                    .Where(a => a.Quiz.Id == quizId).ToListAsync();

        return stages;
    }

    public async Task<Stage?> GetSingleFull(int stageId)
    {
        return await _treehootApiContext.Stage
                        .Include(s => s.Questions)
                            .ThenInclude(q => q.Answers)
                        .Include(s => s.Quiz)
                        .SingleOrDefaultAsync(s => s.Id == stageId);
    }
}
