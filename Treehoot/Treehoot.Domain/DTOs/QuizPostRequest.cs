using System;
using System.ComponentModel.DataAnnotations;

namespace Treehoot.Domain.DTOs
{
	public class QuizPostRequest
	{
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public List <StagePostRequest> Stages { get; set; }
	}
}

