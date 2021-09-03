using Microsoft.EntityFrameworkCore;

using PizzeriaDAL.Entities;

using System;

namespace PizzeriaDAL
{
	public class PizzeriaContext : DbContext
	{
		public DbSet<Plat> Plats { get; set; }
		public DbSet<Categorie> Categories { get; set; }
		public PizzeriaContext(DbContextOptions options) : base(options)
		{

		}
	}
}
