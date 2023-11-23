using Treehoot.Domain.Models;

namespace Treehoot.Api.Dtos;

public class GetQuizFullResponse : GetQuizResponse
{
    public List<GetStageFullResponse> Stages { get; set; }
}
