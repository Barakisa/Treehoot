using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Treehoot.Api.Dtos
{
    public class PostUserLoginResponse
    {
        public bool Success { get; set; }
        public string? Username { get; set; }
        public string? Message { get; set; }
    }
}
