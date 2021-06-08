using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace WebAPI.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Branch> Branches { get; set; }
        DbSet<Treatment> Treatments { get; set; }
        DbSet<Booking> Bookings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Entry(object entity);
    }
}
