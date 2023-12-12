using System;

namespace Treehoot.Api.Dtos
{
	public class PostQuizRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List <PostStageRequest> Stages { get; set; }
	}
}

