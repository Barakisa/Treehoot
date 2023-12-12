using System;
namespace Treehoot.Api.Dtos
{
	public class PostAnswerRequest
	{
		public string Answer { get; set; }
		public bool IsCorrect { get; set; }
	}
}

