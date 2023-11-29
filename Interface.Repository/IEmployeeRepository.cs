﻿using Entity.Repository.Models;
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
        int Add(Employee employee);

        int Delete(Employee employee);

        int Update(Employee employee);
    }
}
