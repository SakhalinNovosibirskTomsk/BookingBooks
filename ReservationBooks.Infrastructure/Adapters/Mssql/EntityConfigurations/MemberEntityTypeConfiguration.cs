using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationBooks.Core.Domain.Model;

namespace ReservationBooks.Infrastructure.Adapters.Mssql.BookInstanceAggregate
{
    internal class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder
                .ToTable("Members");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
