using System.Text.Json;
using Treehoot.Application.Helpers;
using Treehoot.Application.Services.IServices;
using Treehoot.Domain.Models;

namespace Treehoot.Application.Services;

public class QuestionService : IQuestionService
{
    private string fakeDbPath = "FakeDb/QuestionsTable.json";

    public Question GetQuestion(int questionId)
    {
        return DataLoader.GetEntity<Question>(fakeDbPath, questionId);
    }

    public List<Question> GetStageQuestions(int stageId) {

        
        return new List<Question>();
    }

    public QuestionFull GetQuestionFull(int questionId)
    {
        return new QuestionFull();
    }

}
