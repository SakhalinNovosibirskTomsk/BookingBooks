using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationBooks.Core.Domain.Model;
using ReservationBooks.Infrastructure.Adapters.Mssql.BookInstanceAggregate;

namespace ReservationBooks.Infrastructure.Adapters.Mssql
{
    public class MssqlDbContext: DbContext
    {
        public MssqlDbContext(DbContextOptions<MssqlDbContext> options) : base(options)
        {
            
        }

        public DbSet<BookInstance> BookInstances { get; set; }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookInstanceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MemberEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookInstanceStatusEntityTypeConfiguration());

            // Seed
            modelBuilder.Entity<BookInstanceStatus>(b =>
            {
                var allStatuses = BookInstanceStatus.List();
                b.HasData(allStatuses.Select(c => new { c.Id, c.Name }));
            });

        }
    }
}
