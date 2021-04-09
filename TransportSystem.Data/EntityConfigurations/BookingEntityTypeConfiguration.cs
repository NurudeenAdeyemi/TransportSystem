using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TransportSystem.Core.Entities;

namespace TransportSystem.Data.EntityConfigurations
{
    public class BookingEntityTypeConfiguration
       : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("bookings");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.BookingNumber)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(t => t.Price)
                .HasColumnType("double")
                .IsRequired();

            builder.Property(u => u.RowVersion)
                .IsRowVersion();

        }
    }
}
