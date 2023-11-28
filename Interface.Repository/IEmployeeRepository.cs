using Entity.Repository.Models;
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
    }
}
