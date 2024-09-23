using JWT.Interfaces;
using JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;
		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}
		// GET: api/<EmployeeController>
		[HttpGet]
		public List<Employee> Get()
		{
			var employees = _employeeService.GetEmployeesDetails();
			return employees;
		}

		// GET api/<EmployeeController>/5
		[HttpGet("{id}")]
		public Employee Get(int id)
		{
			var employee = _employeeService.GetEmployeeDetails(id);
			return employee;
		}

		// POST api/<EmployeeController>
		[HttpPost]
		public Employee Post([FromBody] Employee employee)
		{
			var emp = _employeeService.AddEmployee(employee);
			return emp;
		}

		// PUT api/<EmployeeController>/5
		[HttpPut("{id}")]
		public Employee Put(int id, [FromBody] Employee employee)
		{
			var emp = _employeeService.UpdateEmployee(employee);
			return emp;
		}

		// DELETE api/<EmployeeController>/5
		[HttpDelete("{id}")]
		public bool Delete(int id)
		{
			var isDeleted = _employeeService.DeleteEmployee(id);
			return isDeleted;
		}
	}
}
