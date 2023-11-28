using Entity.Repository;
using Entity.Repository.Models;
using Interface.Repository;

namespace Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly JitsStoreContext _context;

        public EmployeeRepository(JitsStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
    }
}