using Core.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
	public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
	{
		public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
		{
			//builder.ToTable("Customers");
			//builder.HasKey(x => x.Id);
			//builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
			builder.Property(x => x.TaxNumber).IsRequired().HasMaxLength(100);
			builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(100);
			builder.HasBaseType<Customer>();

		}
	}
}
