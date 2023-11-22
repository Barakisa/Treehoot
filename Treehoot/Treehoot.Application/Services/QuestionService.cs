using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Treehoot.Application.Data;
using Treehoot.Application.Helpers;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class QuestionService : IQuestionService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public QuestionService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Question GetQuestion(int questionId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return context.Question.Single(a => a.Id == questionId);
        }
    }

    public List<Question> GetStageQuestions(int stageId) 
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return context.Question.Where(a => a.Stage.Id == stageId).ToList();
        }
    }

    public async Task<Question> GetQuestionFull(int questionId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            var a = await context.Question.Include(q => q.Answers).FirstOrDefaultAsync(q => q.Id == questionId);

            return a;

        }
    }

}
