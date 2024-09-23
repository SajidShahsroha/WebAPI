using JWT.Context;
using JWT.Interfaces;
using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly JwtContext _jwtContext;
		public EmployeeService(JwtContext jwtContext)
		{
			_jwtContext = jwtContext;

		}
		public Employee AddEmployee(Employee employee)
		{

			var emp = _jwtContext.Employees.Add(employee);
			_jwtContext.SaveChanges();
			return emp.Entity;
		}

		public bool DeleteEmployee(int id)
		{
			try
			{
				var emp = _jwtContext.Employees.SingleOrDefault(s => s.Id == id);
				if (emp == null)
				{
					throw new Exception("User not found");
				}
				else
				{
					_jwtContext.Employees.Remove(emp);
					_jwtContext.SaveChanges();
					return true;
				}
			}
			catch (Exception)
			{

				return false;
			}
			
		}

		public Employee GetEmployeeDetails(int id)
		{
			var emp = _jwtContext.Employees.SingleOrDefault(s => s.Id == id);
			return emp;
		}

		public List<Employee> GetEmployeesDetails()
		{
			var emp = _jwtContext.Employees.ToList();
			return emp;
		}

		public Employee UpdateEmployee(Employee employee)
		{
			var emp = _jwtContext.Employees.Update(employee);
			_jwtContext.SaveChanges();
			return emp.Entity;
		}
	}
}
