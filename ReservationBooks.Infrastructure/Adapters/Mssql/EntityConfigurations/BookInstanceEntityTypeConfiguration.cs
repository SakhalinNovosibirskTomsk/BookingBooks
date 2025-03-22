using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationBooks.Core.Domain.Model;

namespace ReservationBooks.Infrastructure.Adapters.Mssql.BookInstanceAggregate
{
    internal class BookInstanceEntityTypeConfiguration : IEntityTypeConfiguration<BookInstance>
    {
        public void Configure(EntityTypeBuilder<BookInstance> builder)
        {
            builder
                .ToTable("BookInstances");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever()
                .IsRequired();
            
            builder
                .Property(e => e.BookId)
                .HasColumnName("BookId")
                .IsRequired();

            builder
                .OwnsOne(entity => entity.InventoryNumber, n =>
                {
                    n.Property(i => i.Number)
                        .HasColumnName("InventoryNumber")
                        .HasMaxLength(50)
                        .IsRequired();
                    n.WithOwner();
                });

            builder
                .HasMany(c => c.Reservations)
                .WithOne()
                .HasForeignKey("BookInstanceId");
        }
    }
}
