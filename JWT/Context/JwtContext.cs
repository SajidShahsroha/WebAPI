using JWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Context
{
	public class JwtContext:DbContext
	{
		public JwtContext(DbContextOptions<JwtContext> options):base(options)
		{

		}
		public DbSet<User> Users { get; set; }
		public DbSet<Employee> Employees { get; set; }
	}
}
