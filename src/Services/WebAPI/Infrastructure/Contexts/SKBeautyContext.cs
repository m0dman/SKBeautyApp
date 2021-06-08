using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Contexts.Configurations;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Common.Interfaces;
using WebAPI.Domain;
using WebAPI.Domain.Entities;

namespace WebAPI.Infrastructure.Data.Contexts
{
    public class SKBeautyContext : DbContext, IApplicationDbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public SKBeautyContext()
        {
        }

        public SKBeautyContext(DbContextOptions<SKBeautyContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BranchConfig());
            modelBuilder.ApplyConfiguration(new TreatmentConfig());
            modelBuilder.ApplyConfiguration(new BookingConfig());
        }
    }
}
