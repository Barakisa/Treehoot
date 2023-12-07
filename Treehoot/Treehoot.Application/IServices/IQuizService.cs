using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IQuizService
{
    Task<List<Quiz>?> GetAll();
    Task<Quiz?> GetSingle(Guid quizId);
    Task<Quiz?> GetSingleFull(Guid quizId);
    Task<PostResult> ValidatePost(Quiz quiz);
    Task<PostResult> Create(Quiz quiz);
}
