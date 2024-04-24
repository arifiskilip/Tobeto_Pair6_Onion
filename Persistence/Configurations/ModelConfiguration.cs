using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
	public class ModelConfiguration : IEntityTypeConfiguration<Model>
	{
		public void Configure(EntityTypeBuilder<Model> builder)
		{
			builder.ToTable("Models");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
		}
	}
}
