using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IQuestionService
{
    Task<Question?> GetSingle(int questionId);
    Task<List<Question>?> GetStageQuestions(int stageId);
    Task<Question?> GetSingleFull(int questionId);
}
