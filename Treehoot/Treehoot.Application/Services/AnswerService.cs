using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Treehoot.Application.Data;
using Treehoot.Application.Helpers;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class AnswerService : IAnswerService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public AnswerService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Answer GetAnswer(int answerId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return context.Answer.Single(a => a.Id == answerId);
        }
    }

    public List<Answer> GetQuestionAnswers(int questionId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return context.Answer.Where(a => a.Question.Id == questionId).ToList();
        }
    }
}
