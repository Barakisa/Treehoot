using Treehoot.Domain.Models;
using Treehoot.Api.Dtos;

namespace Treehoot.Api.Mapping;

public static class QuizExtensions
{
    //GET simple response
    public static GetQuizResponse ToResponse(this Quiz Quiz)
    {
        return new GetQuizResponse
        {
            Id = Quiz.Id,
            Name = Quiz.Name,
            Description = Quiz.Description
        };
    }

    public static List<GetQuizResponse> ToResponse(this List<Quiz> Quizzes)
    {
        return Quizzes
                .Select(q => q.ToResponse())
                .ToList();
    }

    //GET full response
    public static GetQuizFullResponse ToFullResponse(this Quiz Quiz)
    {
        return new GetQuizFullResponse
        {
            Id = Quiz.Id,
            Name = Quiz.Name,
            Description = Quiz.Description,
            Stages = Quiz.Stages.ToFullResponse()
        };
    }

    public static List<GetQuizFullResponse> ToFullResponse(this List<Quiz> Quizs)
    {
        return Quizs
                .Select(q => q.ToFullResponse())
                .ToList();
    }
}
