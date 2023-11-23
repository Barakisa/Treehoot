using System;
namespace Treehoot.Api.Dtos
{
	public class PostAnswerBody
	{
        public int Id { get; set; }
		public string Answer { get; set; }
		public bool IsCorrect { get; set; }
	}
}

