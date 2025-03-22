using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationBooks.Core.Application.UseCases.Exceptions
{
    public class BookInstanceNotFoundException: ReservationBookApplicationBaseException
    {
        private readonly int _bookInstanceId;

        public BookInstanceNotFoundException(int bookInstanceId)
        {
            _bookInstanceId = bookInstanceId;
        }

        public override string Message => $"Book Instance with Id {_bookInstanceId} not found";
    }
}
