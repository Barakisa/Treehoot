using Treehoot.Domain.Models;
using Treehoot.Api.Dtos;

namespace Treehoot.Api.Maping;

public static class QuestionExtensions
{
    //GET simple response
    public static GetQuestionResponse ToResponse(this Question Question)
    {
        return new GetQuestionResponse
        {
            Id = Question.Id,
            Topic = Question.Topic,
            QuestionText = Question.QuestionText,
            StageId = Question.Stage.Id
        };
    }

    public static List<GetQuestionResponse> ToResponse(this List<Question> Questions)
    {
        return Questions
                .Select(q => q.ToResponse())
                .ToList();
    }

    //GET full response
    public static GetQuestionFullResponse ToFullResponse(this Question Question)
    {
        return new GetQuestionFullResponse
        {
            Id = Question.Id,
            Topic = Question.Topic,
            QuestionText = Question.QuestionText,
            StageId = Question.Stage.Id,
            Answers = Question.Answers.ToResponse()
        };
    }

    public static List<GetQuestionFullResponse> ToFullResponse(this List<Question> Questions)
    {
        return Questions
                .Select(q => q.ToFullResponse())
                .ToList();
    }

}
