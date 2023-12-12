using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IPlaygroundService
{
    Task<KeyValuePair<int, Quiz>> GetSingleHostedQuiz(int code);
    Task<Dictionary<int, Quiz>> GetAllHostedQuizes();
    int AddHostedQuiz(Guid id);
    bool RemoveHostedQuiz(int code);
    bool RemoveHostedQuiz(Guid id);
}
