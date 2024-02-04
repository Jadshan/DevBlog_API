using Microsoft.AspNetCore.Mvc;
using DevBlog_API.Models;
using DevBlog_API.Data;
using DevBlog_API.Models.DTO;

namespace DevBlog_API.Controllers
{
	[Route("api/EmployAPI")]
	public class EmployeeAPIController : ControllerBase
	{
		private readonly ApplicationDbContext _db;
		public EmployeeAPIController(ApplicationDbContext db)
		{
			_db = db;
		}


		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]

		public ActionResult<IEnumerable<EmployeeDTO>> GetEmployee()
		{
			return Ok(_db.Employee.ToList());

		}


		[HttpGet("{id:int}", Name = "GetEmployee")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<EmployeeDTO> GetEmployeeById(int id)
		{
			if (id <= 0)
			{
				return BadRequest();
			}
			var employ = _db.Employee.FirstOrDefault(u => u.id == id);
			if (employ == null)
			{
				return NotFound();
			}
			return Ok(employ);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<EmployeeDTO> crateEmployee([FromBody] EmployeeDTO employDTO)
		{
			
			//if (_db.Employee.FirstOrDefault(u => u.name.ToLower() == employDTO.name.ToLower()) != null)

			//{
				//ModelState.AddModelError(employDTO.name, "title already exits");
				//return BadRequest(ModelState);
			//}
			if (employDTO == null)
			{
				return BadRequest(employDTO);
			}
			if (employDTO.id < 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			

			Employee model = new()
			{
				id = employDTO.id,
				name = employDTO.name,
				email = employDTO.email,
				phone = employDTO.phone,
				type = employDTO.type,
				address = employDTO.address,
				employeeGroup = employDTO.employeeGroup,
				status = employDTO.status,
			};
			_db.Employee.Add(model);
			_db.SaveChanges();
			return CreatedAtRoute("GetEmployee", new { Id = employDTO.id }, employDTO);
		}


		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult DeleteEmployee(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}
			var employ = _db.Employee.FirstOrDefault(u => u.id == id);
			if (employ == null)
			{
				return NotFound();
			}
			_db.Employee.Remove(employ);
			_db.SaveChanges();
			return NoContent();
		}



		[HttpPut("{id:int}", Name = "updateEmployee")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult UpdateEmployee(int id, [FromBody] EmployeeDTO updatedEmploy)
		{
			if (updatedEmploy == null || id != updatedEmploy.id)
			{
				return BadRequest();
			}

			Employee model = new()
			{
				id = updatedEmploy.id,
				name = updatedEmploy.name,
				email = updatedEmploy.email,
				phone = updatedEmploy.phone,
				type = updatedEmploy.type,
				address = updatedEmploy.address,
				employeeGroup = updatedEmploy.employeeGroup,
				status = updatedEmploy.status,
			};
			_db.Employee.Update(model);
			_db.SaveChanges();
			return NoContent();
		}

	}
}
