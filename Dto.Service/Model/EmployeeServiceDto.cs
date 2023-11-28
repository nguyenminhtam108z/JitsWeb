using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Service.Model
{
	public class EmployeeServiceDto
	{
		public Guid EmployeeId { get; set; }

		public string Name { get; set; } = null!;

		public DateTime? BirthDate { get; set; }

		public string? Address { get; set; }

		public string? Phone { get; set; }

		public string? Email { get; set; }

		public string? ContactType { get; set; }

		public byte[]? Photo { get; set; }

		public decimal? Salary { get; set; }

		public byte? Status { get; set; }
	}
}
