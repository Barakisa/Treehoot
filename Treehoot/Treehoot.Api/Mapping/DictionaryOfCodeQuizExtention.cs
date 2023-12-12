using Treehoot.Api.Dtos;
using Treehoot.Domain.Models;

namespace Treehoot.Api.Mapping
{
    public static class DictionaryOfCodeQuizExtention
    {
        public static GetPlaygroundQuizesResponse ToResponse(this Dictionary<int, Quiz> hostedQuizes)
        {
            var response = new GetPlaygroundQuizesResponse()
            {
                HostedQuizes = new Dictionary<int, GetQuizResponse>()
            };
            foreach (var quiz in hostedQuizes)
            {
                response.HostedQuizes.Add(quiz.Key, quiz.Value.ToResponse());
            }

            return response;
        }
    }
}
