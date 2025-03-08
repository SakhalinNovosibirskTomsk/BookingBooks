using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ReservationBooks.Core.Application.UseCases.Reserve
{
    public class ReserveBookInstanceHandler: IRequestHandler<ReserveBookInstanceCommand, bool>
    {
        public ReserveBookInstanceHandler()
        {
            
        }
        public Task<bool> Handle(ReserveBookInstanceCommand request, CancellationToken cancellationToken)
        {
            // 1. Получить книгу по BookInstanceId
            // 2. Вызвать bookInstance.Reserve()
            throw new NotImplementedException();
        }
    }
}
