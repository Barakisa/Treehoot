using System;
namespace Treehoot.Domain.DTOs
{
	public class TopicPostRequest
	{
		public string TopicName { get; set; }
		public string Question { get; set; }
		public List<AnswerPostRequest> Answers { get; set;}
	}
}

