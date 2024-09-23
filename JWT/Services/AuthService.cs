using JWT.Context;
using JWT.Interfaces;
using JWT.Models;
using JWT.ReqestModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Services
{
	public class AuthService : IAuthService
	{
		private readonly JwtContext _jwtContext;
		private readonly IConfiguration _configuration;
		public AuthService(JwtContext jwtContext,IConfiguration configuration)
		{
			_jwtContext = jwtContext;
			_configuration = configuration;
		}
		public User AddUser(User user)
		{
			var addedUser = _jwtContext.Users.Add(user);
			_jwtContext.SaveChanges();
			return addedUser.Entity;
		}

		public string Login(LoginRequest loginRequest)
		{
			if (loginRequest.Username != null && loginRequest.Password != null)
			{
				var user = _jwtContext.Users.SingleOrDefault(s => s.Name == loginRequest.Username && s.Password == loginRequest.Password);
				if (user != null)
				{
					var claims = new[] { new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]), new Claim("Id",user.Id.ToString()), new Claim("UserName",user.Name.ToString()), new Claim("Email", user.Email.ToString()) };
					var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
					var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
					var token = new JwtSecurityToken(
						_configuration["Jwt:Issuer"],
						_configuration["Jwt:Audience"],
						claims,
						expires:DateTime.UtcNow.AddMinutes(10),
						signingCredentials:signIn
						);

					var jwtToken= new JwtSecurityTokenHandler().WriteToken(token);
					return jwtToken;
				}
				else
				{
					throw new Exception("User is not valid");
				}
			}
			else
			{
				throw new Exception("Creds is not valid");
			}
		}
	}
}
