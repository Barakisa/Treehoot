using System;
namespace Treehoot.Domain.DTOs
{
	public class QuizResult
	{
        public QuizResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
		public string Message { get; set; }
	}
}

