using System;
namespace Treehoot.Domain.DTOs
{
	public class AnswerPostRequest
	{
        public AnswerPostRequest(int id, string answer, bool isCorrect)
        {
            Id = id;
            Answer = answer;
            IsCorrect = isCorrect;
        }

        public int Id { get; set; }
		public string Answer { get; set; }
		public bool IsCorrect { get; set; }
	}
}

