using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;
using System.Net;
using Treehoot.Application.Data;

namespace Treehoot.Application.IServices;

public interface IQuizService
{
    Task<List<Quiz>?> GetAll();
    Task<Quiz?> GetSingle(int quizId);
    Task<Quiz?> GetSingleFull(int quizId);
    Task<PostResult> ValidatePost(Quiz quiz);
    Task<PostResult> Create(Quiz quiz);
}
