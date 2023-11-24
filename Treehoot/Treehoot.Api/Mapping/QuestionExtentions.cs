using Treehoot.Domain.Models;
using Treehoot.Api.Dtos;

namespace Treehoot.Api.Mapping;

public static class QuestionExtensions
{

    //GET simple response
    public static GetQuestionResponse ToResponse(this Question question)
    {
        return new GetQuestionResponse
        {
            Id = question.Id,
            Topic = question.Topic,
            QuestionText = question.QuestionText,
            StageId = question.Stage.Id
        };
    }

    public static List<GetQuestionResponse> ToResponse(this List<Question> questions)
    {
        return questions
                .Select(q => q.ToResponse())
                .ToList();
    }

    //GET full response
    public static GetQuestionFullResponse ToFullResponse(this Question question)
    {
        return new GetQuestionFullResponse
        {
            Id = question.Id,
            Topic = question.Topic,
            QuestionText = question.QuestionText,
            StageId = question.Stage.Id,
            Answers = question.Answers.ToResponse()
        };
    }

    public static List<GetQuestionFullResponse> ToFullResponse(this List<Question> questions)
    {
        return questions
                .Select(q => q.ToFullResponse())
                .ToList();
    }

}
