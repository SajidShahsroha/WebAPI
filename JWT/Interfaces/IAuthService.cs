using JWT.Models;
using JWT.ReqestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Interfaces
{
	public interface IAuthService
	{
		User AddUser(User user);
		string Login(LoginRequest loginRequest);
	}
}
