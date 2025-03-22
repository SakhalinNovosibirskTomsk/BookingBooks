using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ReservationBooks.Core.Application.Ports;
using ReservationBooks.Core.Application.UseCases.Exceptions;
using ReservationBooks.Core.Domain.Model;

namespace ReservationBooks.Core.Application.UseCases.Commands.Reserve
{
    public class ReserveBookInstanceHandler : IRequestHandler<ReserveBookInstanceCommand, bool>
    {
        private readonly IBookInstanceRepository _repository;

        public ReserveBookInstanceHandler(IBookInstanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ReserveBookInstanceCommand request, CancellationToken cancellationToken)
        {
            BookInstance? bookInstance = await _repository.GetById(request.BookInstanceId);
            if (bookInstance == null)
            {
                throw new BookInstanceNotFoundException(request.BookInstanceId);
            }

            Member? member = await _repository.GetMemberById(request.MemberId);

            if (member == null)
            {
                throw new MemberNotFoundException(request.BookInstanceId);
            }

            // Зарезервировать книгу.
            var reservation = bookInstance.Reserve(member);

            return reservation.IsSuccess;
        }
    }
}
