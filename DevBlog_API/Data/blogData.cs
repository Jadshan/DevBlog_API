using DevBlog_API.Models;

namespace DevBlog_API.Data
{
	public class blogData
	{
		public static List<BlogDTO> blogs = new List<BlogDTO>
		{
			new BlogDTO{Id=1, Title="blog1", Category="Angular", Content="dfdfdfdfdf"},
			new BlogDTO{Id=2, Title="blog2", Category="dptNet", Content="dfdfdfdfdgfdfdf"}
		};
	}
}
