﻿using Dto.Service.Model;
using Entity.Repository.Models;
using Interface.Repository;
using Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _employeeRepository;
		public EmployeeService(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public bool AddEmployee(EmployeeServiceDto employee)
		{
			Employee employeeAdd = new Employee()
			{
				EmployeeId = Guid.NewGuid(),
				Address = employee.Address,
				BirthDate = employee.BirthDate,
				ContactType = employee.ContactType,
				Email = employee.Email,
				Name = employee.Name,
				Phone = employee.Phone,
				Salary = employee.Salary,
				Status = employee.Status,
			};
			var check = _employeeRepository.Add(employeeAdd);
			if(check != 1)
			{
				return false;
			}
			return true;
		}

		public IEnumerable<EmployeeServiceDto> GetAllEmployee()
		{
			var result = new List<EmployeeServiceDto>();
			var listEmployee = _employeeRepository.GetAll();
			if (listEmployee.Any())
			{
				foreach(var employee in listEmployee)
				{
					EmployeeServiceDto employeeServiceDto = new EmployeeServiceDto()
					{
						Email = employee.Email,
						Address = employee.Address,
						BirthDate = employee.BirthDate,
						ContactType = employee.ContactType,
						EmployeeId = employee.EmployeeId,
						Name = employee.Name,
						Phone = employee.Phone,
						Salary = employee.Salary,
						Status = employee.Status,
					};
					result.Add(employeeServiceDto);
				} 
			}
			return result;
		}
	}
}
