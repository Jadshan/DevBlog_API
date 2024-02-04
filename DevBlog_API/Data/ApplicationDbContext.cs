using DevBlog_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DevBlog_API.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Employee> Employee { get; set; }

	}
}
