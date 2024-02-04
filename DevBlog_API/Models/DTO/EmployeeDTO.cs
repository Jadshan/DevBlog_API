using System.ComponentModel.DataAnnotations;

namespace DevBlog_API.Models.DTO
{
	public class EmployeeDTO
	{
		public int id { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string phone { get; set; }
		public string type { get; set; }
		public string address { get; set; }
		public string employeeGroup { get; set; }
		public bool status { get; set; }
	}
}
