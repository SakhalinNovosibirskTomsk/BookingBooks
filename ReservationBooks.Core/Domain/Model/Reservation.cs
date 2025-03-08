using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace ReservationBooks.Core.Domain.Model
{
    public class Reservation: Entity<int>
    {
        public Member Member { get; }

        public DateTime ReservationDate { get; }

        public DateTime? EndReservationDatePlan { get; }

        public bool IsCancelled { get; }

        public void Cancel()
        {

        }

    }
}
