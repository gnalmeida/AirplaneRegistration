using Airplane.Data.Extensions;
using Airplane.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Airplane.Data.Context
{
	public class AirplaneContext : DbContext
	{
		public DbSet<Domain.Entities.Airplane> Airplane { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.AddConfiguration(new AirplaneMap());

			base.OnModelCreating(modelBuilder);
		}

		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
			{
				if (entry.State == EntityState.Added)
				{
					entry.Property("Created").CurrentValue = DateTime.Now;
				}
			}

			return base.SaveChanges();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
		}
	}

}
