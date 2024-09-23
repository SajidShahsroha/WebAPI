using JWT.Interfaces;
using JWT.Models;
using JWT.ReqestModels;
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
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}
		
		// POST api/<AuthController>
		[HttpPost]
		public string Login([FromBody] LoginRequest loginModel)
		{
			var result = _authService.Login(loginModel);
			return result;
		}

		// PUT api/<AuthController>/5
		[HttpPost("addUser")]
		public User AddUser([FromBody] User user)
		{
			var _user = _authService.AddUser(user);
			return _user;
		}

		// DELETE api/<AuthController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
