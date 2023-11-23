using System;

namespace Treehoot.Domain.Models
{
    public class PostResult
    {
        public PostResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

