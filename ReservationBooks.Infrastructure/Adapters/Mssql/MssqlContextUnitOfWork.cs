using Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationBooks.Infrastructure.Adapters.Mssql
{
    public class MssqlContextUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MssqlDbContext _context;

        private bool _disposed;

        public MssqlContextUnitOfWork(MssqlDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _context.Dispose();
                _disposed = true;
            }
        }
    }
}
