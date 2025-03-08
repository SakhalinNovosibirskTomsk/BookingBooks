using Microsoft.AspNetCore.Mvc;

namespace ReservationBooks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookReservationController : ControllerBase
    {
        private readonly ILogger<BookReservationController> _logger;

        public BookReservationController(ILogger<BookReservationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserReservation")]
        public IEnumerable<ReservationModel> GetUserReservations(int userId)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "GetBookReservation")]
        public ReservationModel GetBookReservation(int bookInstanceId)
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public IAsyncResult ReserveBookInstance(int bookInstanceId, int userId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IAsyncResult ReserveBook(int bookId, int userId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IAsyncResult CheckedOut(int bookInstanceId, bool toReadingRoom)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IAsyncResult Returned(int bookInstanceId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IAsyncResult (int bookInstanceId)
        {
            throw new NotImplementedException();
        }

    }
}
