using Treehoot.Api.Dtos;
using Treehoot.Domain.Models;

namespace Treehoot.Api.Maping;

public static class StageExtensions
{
    //GET simple response
    public static GetStageResponse ToResponse(this Stage Stage)
    {
        return new GetStageResponse
        {
            Id = Stage.Id,
            Name = Stage.Name,
            QuizId = Stage.Quiz.Id
        };
    }

    public static List<GetStageResponse> ToResponse(this List<Stage> Questions)
    {
        return Questions
                .Select(s => s.ToResponse())
                .ToList();
    }

    //GET full response
    public static GetStageFullResponse ToFullResponse(this Stage Stage)
    {
        return new GetStageFullResponse
        {
            Id = Stage.Id,
            Name = Stage.Name,
            QuizId = Stage.Quiz.Id,
            Questions = Stage.Questions.ToFullResponse()
        };
    }

    public static List<GetStageFullResponse> ToFullResponse(this List<Stage> Stages)
    {
        return Stages
                .Select(s => s.ToFullResponse())
                .ToList();
    }

}
