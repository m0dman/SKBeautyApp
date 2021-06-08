using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities;

namespace Infrastructure.Contexts.Configurations
{
    internal class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> entity)
        {
            #region Properties

            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).UseIdentityColumn();
            entity.Property(p => p.Name).IsRequired().HasMaxLength(500);
            entity.Property(p => p.Address).IsRequired().HasMaxLength(500);

            #endregion

            #region Relationships

            entity.HasMany(treat => treat.Treatments)
                .WithOne(b => b.Branch);

            #endregion
        }
    }
}
