using System.ComponentModel.DataAnnotations;

namespace DevBlog_API.Models
{
	public class BlogDTO
	{
		public int Id { get; set; }

		[Required]
		[MinLength(5)]
		public string Title { get; set; }
		public string PermaLink { get; set; }
		public string Category { get; set; }
		public string Content { get; set; }

		
		

	}
}
