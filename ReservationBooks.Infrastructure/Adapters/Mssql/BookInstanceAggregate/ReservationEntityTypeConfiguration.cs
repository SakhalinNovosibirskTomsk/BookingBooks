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
                .ToTable("reservations");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .HasOne(entity => entity.Member)
                .WithMany()
                .IsRequired()
                .HasForeignKey("member_id");

            builder
                .Property(e => e.ReservationDate)
                .HasColumnName("reservation_date")
                .IsRequired();

            builder
                .Property(e => e.EndReservationDatePlan)
                .HasColumnName("end_reservation_date_plan");

            builder
                .Property(e => e.EndReservationDatePlan)
                .HasColumnName("end_reservation_date_plan");

        }
    }
}
