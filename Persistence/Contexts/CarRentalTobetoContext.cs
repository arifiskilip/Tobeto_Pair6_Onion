using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Contexts
{
	public class CarRentalTobetoContext : DbContext
	{
		public CarRentalTobetoContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
		public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
		public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
		//public DbSet<Customer> Customers { get; set; }
		public DbSet<Core.Entities.OperationClaim> OperationClaims { get; set; }
        public DbSet<Core.Entities.UserOperationClaim> UserOperationClaims { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
}
