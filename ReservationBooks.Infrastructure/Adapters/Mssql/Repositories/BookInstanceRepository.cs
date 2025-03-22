using ReservationBooks.Core.Application.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationBooks.Core.Domain.Model;
using System.Diagnostics.Metrics;

namespace ReservationBooks.Infrastructure.Adapters.Mssql.Repositories
{
    public class BookInstanceRepository: IBookInstanceRepository
    {
        private readonly MssqlDbContext _context;

        public BookInstanceRepository(MssqlDbContext context)
        {
            _context = context;
        }

        public async Task<BookInstance?> GetById(int id)
        {
            BookInstance? bookInstance = await _context.BookInstances
                .Include(bi => bi.Reservations)
                .Include(bi => bi.Status)
                .FirstOrDefaultAsync(bi => bi.Id == id);

            return bookInstance;
        }

        public async Task<Member?> GetMemberById(int id)
        {
            Member? member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);
            return member;
        }

        public async Task AddAsync(BookInstance bookInstance)
        {
            if (bookInstance == null)
                throw new ArgumentNullException(nameof(bookInstance));

            if (bookInstance.Status is not null)
                _context.Attach(bookInstance.Status);

            await _context.AddAsync(bookInstance);
        }
    }
}
