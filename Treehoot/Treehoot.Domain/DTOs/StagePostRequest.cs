using System;
namespace Treehoot.Domain.DTOs
{
	public class StagePostRequest
	{	public string Name { get; set; }
		public List<TopicPostRequest> Topics { get; set; }
	}
}

