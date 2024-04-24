
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
	public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
	{
		public void Configure(EntityTypeBuilder<OperationClaim> builder)
		{
			builder.ToTable("OperationClaims");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
		}
	}
}
