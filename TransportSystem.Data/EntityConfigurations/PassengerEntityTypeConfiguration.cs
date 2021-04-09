using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TransportSystem.Core.Entities;

namespace TransportSystem.Data.EntityConfigurations
{
    public class PassengerEntityTypeConfiguration
         : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable("passengers");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.FirstName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnType("varchar(50)")
                .IsRequired();


            builder.Property(c => c.Email)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(c => c.Address)
               .HasColumnType("varchar(250)")
               .IsRequired();

            builder.Property(c => c.NextOfKin)
              .HasColumnType("varchar(250)");

            builder.Property(c => c.PhoneNumber)
                .HasColumnType("varchar(50)");


            builder.Property(u => u.PasswordHash)
                .HasColumnType("varchar(750)")
                .IsRequired();

            builder.Property(u => u.HashSalt)
                .HasColumnType("varchar(700)")
                .IsRequired();

            builder.Property(u => u.RowVersion)
                .IsRowVersion();

            builder.HasMany(u => u.Bookings)
                .WithOne(ur => ur.Passenger)
                .HasForeignKey(ur => ur.PassengerId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
