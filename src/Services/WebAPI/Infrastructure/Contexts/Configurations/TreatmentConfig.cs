using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities;

namespace Infrastructure.Contexts.Configurations
{
    internal class TreatmentConfig : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> entity)
        {
            #region Properties

            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).UseIdentityColumn();
            entity.Property(t => t.Name).IsRequired().HasMaxLength(500);
            entity.Property(t => t.Price).IsRequired().HasMaxLength(500);

            #endregion

            #region Relationships

            entity.HasOne(b => b.Branch)
                .WithMany(treat => treat.Treatments);

            #endregion
        }
    }
}
