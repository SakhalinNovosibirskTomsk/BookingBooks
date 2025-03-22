using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ReservationBooks.Core.Application.UseCases.Commands.Reserve
{
    public class ReserveBookInstanceCommand : IRequest<bool>
    {
        public ReserveBookInstanceCommand(int bookInstanceId, int memberId)
        {
            MemberId = memberId;
            BookInstanceId = bookInstanceId;
        }

        public int BookInstanceId { get; }

        public int MemberId { get; }

    }
}
