using Treehoot.Domain.Models;
using Treehoot.Domain.DTOs;
using Microsoft.CodeAnalysis.CSharp;

namespace Treehoot.Api.Maping;

public static class AnswerMaper
{
    public static AnswerDto ToResponse(this Answer answer)
    {
        
        return new AnswerDto
        {
            Id = answer.Id,
            QuestionId = answer.QuestionId,
            IsCorrect = answer.IsCorrect,
            Text = answer.Text
        };
    }

    public static List<AnswerDto> ToResponse(this List<Answer> answers)
    {
        return answers.Select(answer => answer.ToResponse()).ToList();
    }

    public static Answer ToModel(this AnswerDto answerDto)
    {
        return new Answer
        {
            Id = answerDto.Id,
            QuestionId = answerDto.QuestionId,
            IsCorrect = answerDto.IsCorrect,
            Text = answerDto.Text
        };
    }

}
