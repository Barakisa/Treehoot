using System;
namespace Treehoot.Api.Dtos
{
	public class PostStageRequest
	{	public string Name { get; set; }
		public List<PostQuestionRequest> Topics { get; set; }
	}
}

