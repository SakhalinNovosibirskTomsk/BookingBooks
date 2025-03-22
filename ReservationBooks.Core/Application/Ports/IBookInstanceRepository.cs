using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationBooks.Core.Domain.Model;

namespace ReservationBooks.Core.Application.Ports
{
    public interface IBookInstanceRepository
    {
        Task<BookInstance?> GetById(int id);

        Task<Member?> GetMemberById(int id);

        Task AddAsync(BookInstance bookInstance);
    }
}
