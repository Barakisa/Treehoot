using System;
namespace Treehoot.Api.Dtos
{
	public class PostQuestionRequest
	{
		public string TopicName { get; set; }
		public string Question { get; set; }
		public List<PostAnswerRequest> Answers { get; set;}
	}
}

