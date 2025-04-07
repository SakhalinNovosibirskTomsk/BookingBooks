using Microsoft.EntityFrameworkCore;
using ReservationBooks.Core.Domain.Model;
using ReservationBooks.Infrastructure.Adapters.Mssql;
using ReservationBooks.Infrastructure.Adapters.Mssql.Repositories;

namespace ReservationBooks.IntegrationTests
{
    public class BookInstanceTests
    {
        private const string ConnectionString =
            "data source=DESKTOP-84LKP9A\\SQLEXPRESS;initial catalog=ReservationBooks;user id=sa;password=dslhf;TrustServerCertificate=True";
        [Fact]
        public async Task ReservationTest()
        {
            DbContextOptionsBuilder<MssqlDbContext> builder = new DbContextOptionsBuilder<MssqlDbContext>();
            builder.UseSqlServer(ConnectionString);

            MssqlDbContext context = new MssqlDbContext(builder.Options);

            MssqlContextUnitOfWork uof = new MssqlContextUnitOfWork(context);

            BookInstanceRepository repository = new BookInstanceRepository(context);

            BookInstance bi = BookInstance.Create(1, 100, InventoryNumber.Create("AAAA-0000").Value, BookInstanceStatus.Available);
            await repository.AddAsync(bi);

            var member = context.Members.First();
            
            bi.Reserve(member);

            await uof.SaveChangesAsync();

        }

        [Fact]
        public async Task ReservationTest2()
        {
            DbContextOptionsBuilder<MssqlDbContext> builder = new DbContextOptionsBuilder<MssqlDbContext>();
            builder.UseSqlServer(ConnectionString);

            MssqlDbContext context = new MssqlDbContext(builder.Options);

            MssqlContextUnitOfWork uof = new MssqlContextUnitOfWork(context);

            BookInstanceRepository repository = new BookInstanceRepository(context);

            BookInstance? bi = await repository.GetById(1);

            var member = context.Members.First();

            bi.Reserve(member);

            await uof.SaveChangesAsync();

        }
    }
}