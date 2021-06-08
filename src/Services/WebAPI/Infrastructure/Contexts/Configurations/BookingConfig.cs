using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities;

namespace Infrastructure.Contexts.Configurations
{
    internal class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> entity)
        {
            #region Properties

            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).UseIdentityColumn();
            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(500);
            entity.Property(p => p.Surname).IsRequired().HasMaxLength(500);
            entity.Property(p => p.Address).IsRequired().HasMaxLength(500);
            entity.Property(p => p.TelephoneNumber).IsRequired().HasMaxLength(500);
            entity.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(500);
            entity.Property(p => p.Email).IsRequired().HasMaxLength(500);
            entity.Property(p => p.Date).HasColumnName("date");

            #endregion

            #region Relationships



            #endregion
        }
    }
}
