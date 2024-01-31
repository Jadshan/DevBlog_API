using System.ComponentModel.DataAnnotations;

namespace DevBlog_API.Models
{
	public class BlogDTO
	{
		public int Id { get; set; }

		[Required]
		[MinLength(5)]
		public string Title { get; set; }
		public string Category { get; set; }
		public string postImgPath { get; set; }
		public string Content { get; set; }
		public bool isFeatured { get; set; }
		public int views { get; set; }

	}
}
