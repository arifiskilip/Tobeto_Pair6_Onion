using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
	partial class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
	{
		public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
		{
			builder.ToTable("UserOperationClaims");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.HasOne(x => x.User)
				.WithMany(x => x.UserOperationClaims)
				.HasForeignKey(x => x.UserId);

			builder.HasOne(x => x.OperationClaim)
				.WithMany(x => x.UserOperationClaims)
				.HasForeignKey(x => x.OperationClaimId);
		}
	}
}
