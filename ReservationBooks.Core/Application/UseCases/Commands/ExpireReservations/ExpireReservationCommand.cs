using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ReservationBooks.Core.Application.UseCases.Commands.ExpireReservations
{
    public class ExpireReservationCommand : IRequest<bool>
    {
    }
}
