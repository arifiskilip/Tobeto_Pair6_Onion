using Core.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
	public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
	{
		public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
		{
			//builder.ToTable("Customers");
			//builder.HasKey(x => x.Id);
			//builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
			builder.Property(x => x.IdentityNumber).IsRequired().HasMaxLength(50);
			builder.HasBaseType<Customer>();
		}
	}
}
