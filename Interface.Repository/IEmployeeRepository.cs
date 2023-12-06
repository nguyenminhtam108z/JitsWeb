using Entity.Repository.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();

        Employee Get(Guid EmployeeId);

        int Add(Employee employee);

        int Delete(Guid EmployeeId);

        int Update(Employee employee);
    }
}
