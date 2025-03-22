using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationBooks.Core.Domain.Model;

namespace ReservationBooks.Infrastructure.Adapters.Mssql.BookInstanceAggregate
{
    internal class ReservationEntityTypeConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .ToTable("Reservations");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            //builder
            //    .Property(entity => entity.MemberId)
            //    .HasColumnName("MemberId")
            //    .IsRequired();

            builder
                .HasOne(entity => entity.Member)
                .WithMany()
                .IsRequired()
                .HasForeignKey("MemberId");

            builder
                .Property(e => e.ReservationDate)
                .HasColumnName("ReservationDate")
                .IsRequired();

            builder
                .Property(e => e.EndReservationDatePlan)
                .HasColumnName("EndReservationDatePlan");

            builder
                .Property(e => e.IsActive)
                .HasColumnName("IsActive")
                .IsRequired();

        }
    }
}
