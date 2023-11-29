using Dto.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Service
{
	public interface IEmployeeService
	{
		IEnumerable<EmployeeServiceDto> GetAllEmployee();
		bool AddEmployee(EmployeeServiceDto employee);
	}
}
