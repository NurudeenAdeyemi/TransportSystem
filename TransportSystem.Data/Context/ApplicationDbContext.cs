
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransportSystem.Core.Entities;
using TransportSystem.Data.Extensions;

namespace TransportSystem.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations<ApplicationDbContext>();
            modelBuilder.ConfigureDeletableEntities();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            this.AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        private const string IsDeletedProperty = "IsDeleted";
       
        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[IsDeletedProperty] = false;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues[IsDeletedProperty] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[IsDeletedProperty] = true;
                        break;
                }
            }
        }


        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Trip> Trips { get; set; }
    }
}
