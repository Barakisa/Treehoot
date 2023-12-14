using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Treehoot.Api.Dtos
{
    public class PostUserRegisterResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
