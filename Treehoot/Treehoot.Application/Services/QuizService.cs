using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Application.IServices;
using Treehoot.Domain.Models;
using Treehoot.Domain.DTOs;
using System.Net;
using Treehoot.Application.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Treehoot.Application.Services;

public class QuizService : IQuizService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public QuizService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Quiz GetQuiz(int quizId)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
            return context.Quiz.Single(a => a.Id == quizId);
        }
    }

    public List<Quiz> GetQuizes() {
        try
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TreehootApiContext>();
                return context.Quiz.ToList();
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Error: {e.Message}");
        }
        
    }
    
    //broken
    public QuizFull GetQuizFull(int quizId)
    {
        return new QuizFull();
    }
    
    public async Task <HttpResponseMessage> QuizPost (QuizPostRequest quiz)
    {
        try
        {
            

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        catch
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }

}
