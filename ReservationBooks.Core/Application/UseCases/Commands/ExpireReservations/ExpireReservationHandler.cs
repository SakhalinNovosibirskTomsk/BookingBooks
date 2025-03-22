using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Primitives;

namespace ReservationBooks.Core.Application.UseCases.Commands.ExpireReservations
{
    public class ExpireReservationHandler : IRequestHandler<ExpireReservationCommand, bool>
    {
        //public ExpireReservationHandler(IUnitOfWork uof, IBookInstanceRepository bookInstanceRepository)
        //{
        //}
        public Task<bool> Handle(ExpireReservationCommand request, CancellationToken cancellationToken)
        {
            // 1. Получить все зарезервированные книги с истекшим плановым сроком резервации.

            // 2. Вызвать для каждой книги BookInstance.CancelReservation(...)

            throw new NotImplementedException();
        }
    }
}
