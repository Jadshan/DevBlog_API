using DevBlog_API.Data;
using DevBlog_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DevBlog_API.Controllers
{
	//[Route("api/[controller]")]
	[Route("api/BlogAPI")]
	//[ApiController]
	public class BlogAPIController : ControllerBase
	{
		private readonly ApplicationDbContext _db;
		public BlogAPIController(ApplicationDbContext db) {
		_db = db;
		}


		///////////////////////////////////////////////////////////////////////////
		/*public ILogger<BlogAPIController> _Logger { get; }

		public BlogAPIController(ILogger<BlogAPIController> logger)
        {
			_Logger = logger;
		}*/
		////////////////////////////////////////////////////////////////////////////

        [HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]

		public ActionResult<IEnumerable<BlogDTO>> GetBlogs()
		{
			//_Logger.LogInformation("Getting all blogs");
			return Ok(_db.Blogs.ToList());

			//return Ok(blogData.blogs);
		}


		[HttpGet("{id:int}", Name = "GetBlog")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		/*[ProducesResponseType(200, Type= typeof(Blog))]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]*/
		public ActionResult<BlogDTO> GetBlogById(int id)
		{
			if (id <= 0)
			{
				//_Logger.LogInformation($"Error with Id {id}");
				return BadRequest();
			}
			//var blog = blogData.blogs.FirstOrDefault(u => u.Id == id);
			var blog = _db.Blogs.FirstOrDefault(u => u.Id == id);
			if (blog == null)
			{
				return NotFound();
			}
			return Ok(blog);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<BlogDTO> crateBlog([FromBody] BlogDTO blogDTO)
		{
			/*if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}*/
			//if (blogData.blogs.FirstOrDefault(u => u.Title.ToLower() == blogDTO.Title.ToLower()) != null)
			if (_db.Blogs.FirstOrDefault(u => u.Title.ToLower() == blogDTO.Title.ToLower()) != null)

			{
				ModelState.AddModelError(blogDTO.Title, "title already exits");
				return BadRequest(ModelState);
			}
			if (blogDTO == null)
			{
				return BadRequest(blogDTO);
			}
			if (blogDTO.Id < 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			//blogDTO.Id = blogData.blogs.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
			//blogData.blogs.Add(blogDTO);

			Blog model = new()
			{
				Title = blogDTO.Title,
				PermaLink = blogDTO.PermaLink,
				except = blogDTO.except,
				Category = blogDTO.Category,
				postImgPath = blogDTO.postImgPath,
				Content = blogDTO.Content
			};
			_db.Blogs.Add(model);
			_db.SaveChanges();

			//return Ok(blog);
			return CreatedAtRoute("GetBlog", new { id = blogDTO.Id }, blogDTO);
		}


		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]	
		public ActionResult DeleteBlog(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}
			//var blog = blogData.blogs.FirstOrDefault(u => u.Id == id);
			var blog = _db.Blogs.FirstOrDefault(u => u.Id == id);
			if (blog == null)
			{
				return NotFound();
			}
			//blogData.blogs.Remove(blog);
			_db.Blogs.Remove(blog);
			_db.SaveChanges();
			return NoContent();
		}



		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult UpdateBlog(int id, [FromBody] BlogDTO updateBlog)
		{
			if (updateBlog == null || id != updateBlog.Id)
			{
				return BadRequest();
			}
			//var blog = blogData.blogs.FirstOrDefault(u => u.Id==id);
		/*	if (blog == null)
			{
				return NotFound();
			}*/

			/*blog.Title = updateBlog.Title;
			blog.PermaLink = updateBlog.PermaLink;
			blog.Category = updateBlog.Category;
			blog.Content = updateBlog.Content;*/

			Blog model = new()
			{
				Title = updateBlog.Title,
				PermaLink = updateBlog.PermaLink,
				except = updateBlog.except,
				Category = updateBlog.Category,
				postImgPath = updateBlog.postImgPath,
				Content = updateBlog.Content
			};
			_db.Blogs.Update(model);
			_db.SaveChanges();
			return NoContent();
		}

/*		[HttpPatch("{id:int}/updateParial")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]

		public ActionResult UpdateParialBlog(int id, [FromBody] JsonPatchDocument<BlogDTO> patchDocument)
		{
			if(patchDocument == null || id <= 0) 
			{ 
			return BadRequest();
			}
			var existingBlog = blogData.blogs.FirstOrDefault(u => u.Id == id);
			if (existingBlog == null)
			{
				return NotFound();
			}
			patchDocument.ApplyTo(existingBlog, ModelState);
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return NoContent(); 
		}*/
	}

}
