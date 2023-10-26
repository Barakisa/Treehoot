using System;
namespace Treehoot.Domain.DTOs
{
	public class QuizPostRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List <StagePostRequest> Stages { get; set; }
	}
}

