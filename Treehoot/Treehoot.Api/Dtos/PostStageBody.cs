using System;
namespace Treehoot.Api.Dtos
{
	public class PostStageBody
	{	public string Name { get; set; }
		public List<PostQuestionBody> Questions { get; set; }
	}
}

