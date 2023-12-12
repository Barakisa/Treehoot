namespace Treehoot.Api.Dtos
{
    public class GetPlaygroundQuizesResponse
    {
        public Dictionary<int, GetQuizResponse> HostedQuizes { get; set; }
    }
}
