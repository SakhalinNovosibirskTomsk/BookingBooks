using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationBooks.Core.Domain.Model;

namespace ReservationBooks.Infrastructure.Adapters.Mssql.BookInstanceAggregate
{
    internal class BookInstanceStatusEntityTypeConfiguration : IEntityTypeConfiguration<BookInstanceStatus>
    {
        public void Configure(EntityTypeBuilder<BookInstanceStatus> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("BookInstanceStatuses");

            entityTypeBuilder.HasKey(entity => entity.Id);

            entityTypeBuilder
                .Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasColumnName("Id")
                .IsRequired();

            entityTypeBuilder
                .Property(entity => entity.Name)
                .HasColumnName("Name")
                .IsRequired();
        }
    }
}
