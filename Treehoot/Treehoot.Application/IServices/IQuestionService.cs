using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.IServices;

public interface IQuestionService
{
    Task<Question?> GetQuestion(int questionId);
    Task<List<Question>?> GetStageQuestions(int stageId);
    Task<Question?> GetQuestionFull(int questionId);
}
