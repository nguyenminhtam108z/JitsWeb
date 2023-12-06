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

		EmployeeServiceDto GetEmployee(Guid EmployeeId);

        bool AddEmployee(EmployeeServiceDto employee);

		bool DeleteEmployee(Guid EmployeeId);

		bool UpdateEmployee(EmployeeServiceDto employee);
	}
}
