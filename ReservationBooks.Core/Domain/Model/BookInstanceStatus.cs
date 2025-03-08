using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationBooks.Core.Domain.Model
{
    public enum BookInstanceStatus
    {
        Available, CheckedOutToReadingRoom, CheckedOutToHome, WrittenOff
    }
}
