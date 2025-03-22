using ReservationBooks.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationBooks.Core.Application.UseCases.Exceptions
{
    public class MemberNotFoundException : ReservationBookApplicationBaseException
    {
        private readonly int _memberId;

        public MemberNotFoundException(int memberId)
        {
            _memberId = memberId;
        }

        public override string Message => $"Memeber with Id {_memberId} not found";
    }
}
