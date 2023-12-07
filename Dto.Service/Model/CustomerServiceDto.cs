using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Service.Model
{
	public class CustomerServiceDto
	{
		public Guid CustomerId { get; set; }

		public string? CustomerName { get; set; }

		public int? Sex { get; set; }

		public int? Age { get; set; }

		public string? Address { get; set; }

		public string? Phone { get; set; }

		public string? Email { get; set; }
	}
}
