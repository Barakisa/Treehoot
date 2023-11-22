using System;

namespace Treehoot.Api.Dtos
{
	public class PostQuizBody
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List <PostStageBody> Stages { get; set; }
	}
}

