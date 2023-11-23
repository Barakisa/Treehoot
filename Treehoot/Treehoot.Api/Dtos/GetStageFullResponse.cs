using Treehoot.Domain.Models;

namespace Treehoot.Api.Dtos;

public class GetStageFullResponse : GetStageResponse
{
    public List<GetQuestionFullResponse> Questions { get; set; }
}
