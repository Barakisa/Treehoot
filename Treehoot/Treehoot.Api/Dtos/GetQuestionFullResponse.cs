using Treehoot.Domain.Models;

namespace Treehoot.Api.Dtos;

public class GetQuestionFullResponse : GetQuestionResponse
{
    public List<GetAnswerResponse> Answers { get; set; }
}
