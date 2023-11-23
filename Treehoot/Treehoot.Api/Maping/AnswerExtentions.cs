using Treehoot.Domain.Models;
using Treehoot.Api.Dtos;

namespace Treehoot.Api.Maping;

public static class AnswerExtensions
{
    //GET simple response
    public static GetAnswerResponse ToResponse(this Answer answer)
    {
        return new GetAnswerResponse
        {
            Id = answer.Id,
            QuestionId = answer.Question.Id,
            IsCorrect = answer.IsCorrect,
            Text = answer.Text
        };
    }

    public static List<GetAnswerResponse> ToResponse(this List<Answer> answers)
    {
        return answers.Select(answer => answer.ToResponse()).ToList();
    }

}
