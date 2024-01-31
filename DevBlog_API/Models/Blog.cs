using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevBlog_API.Models
{
	public class Blog
	{
		[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Category { get; set; }
		public string Content { get; set; }
		public string postImgPath { get; set; }
		public bool isFeatured { get; set; } = false;
		public int views { get; set; }
		public DateTime createdAt { get; set; } = DateTime.Now;

	}
}
