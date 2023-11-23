using System;
namespace Treehoot.Api.Dtos
{
	public class PostQuestionBody
	{
		public string TopicName { get; set; }
		public string Question { get; set; }
		public List<PostAnswerBody> Answers { get; set;}
	}
}

