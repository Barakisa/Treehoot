using Treehoot.Domain.Models;
using Treehoot.Domain.DTOs;
using Microsoft.CodeAnalysis.CSharp;

namespace Treehoot.Api.Maping;

public static class AnswerExtensions
{
    public static AnswerDto ToResponse(this Answer answer)
    {
        return new AnswerDto
        {
            Id = answer.Id,
            QuestionId = answer.Question.Id,
            IsCorrect = answer.IsCorrect,
            Text = answer.Text
        };
    }

    public static List<AnswerDto> ToResponse(this List<Answer> answers)
    {
        return answers.Select(answer => answer.ToResponse()).ToList();
    }

}
