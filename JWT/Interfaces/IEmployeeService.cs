using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Interfaces
{
	public interface IEmployeeService
	{
		public List<Employee> GetEmployeesDetails();
		public Employee GetEmployeeDetails(int id);
		public Employee AddEmployee(Employee employee);
		public Employee UpdateEmployee(Employee employee);
		public bool DeleteEmployee(int id);
	}
}
