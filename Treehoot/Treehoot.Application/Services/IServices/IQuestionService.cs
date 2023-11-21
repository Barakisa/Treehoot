using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services.IServices;

public interface IQuestionService
{
    Question GetQuestion(int questionId);
    List<Question> GetStageQuestions(int stageId);
    QuestionFull GetQuestionFull(int questionId);
}
