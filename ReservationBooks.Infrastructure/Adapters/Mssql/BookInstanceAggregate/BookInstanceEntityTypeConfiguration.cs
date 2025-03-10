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
                .ToTable("book_instances");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever()
                .IsRequired();
            
            builder
                .Property(e => e.BookId)
                .HasColumnName("book_id")
                .IsRequired();

            builder
                .OwnsOne(entity => entity.InventoryNumber, n =>
                {
                    n.Property(i => i.Number).HasColumnName("inventory_nuber").IsRequired();
                    n.WithOwner();
                });

            builder
                .HasMany<Reservation>()
                .WithOne()
                .HasForeignKey("book_instance_id");
        }
    }
}
