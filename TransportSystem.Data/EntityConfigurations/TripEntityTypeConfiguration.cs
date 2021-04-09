using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TransportSystem.Core.Entities;

namespace TransportSystem.Data.EntityConfigurations
{
    public class TripEntityTypeConfiguration
       : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("trips");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.TakeOffPoint)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(t => t.Destination)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(t => t.DepatureTime)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(t => t.ArrivalTime)
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(u => u.RowVersion)
                .IsRowVersion();

            builder.HasMany(b => b.Bookings)
                .WithOne(t => t.Trip)
                .HasForeignKey(t => t.TripId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
