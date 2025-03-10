using Microsoft.AspNetCore.Mvc;

namespace ReservationBooks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly ILogger<ReservationsController> _logger;

        public ReservationsController(ILogger<ReservationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("member/{memberId}")]
        public IEnumerable<ReservationModel> GetUserReservations(int memberId)
        {
            yield return new ReservationModel
            {
                BookInstanceId = 1,
                ReservationDate = new DateTime(2025, 2, 25),
                EndReservationDatePlan = null,
                MemberId = memberId
            };

            yield return new ReservationModel
            {
                BookInstanceId = 21,
                ReservationDate = new DateTime(2025, 2, 28),
                EndReservationDatePlan = new DateTime(2025, 3, 1),
                MemberId = memberId
            };

        }

        [HttpGet]
        [Route("bookInstance/{bookInstanceId}")]
        public ReservationModel GetBookReservation(int bookInstanceId)
        {
            throw new NotImplementedException();
        }

        //[ApiExplorerSettings(IgnoreApi = true)]
        //[HttpPost]
        //public IAsyncResult ReserveBookInstance(int bookInstanceId, int userId)
        //{
        //    throw new NotImplementedException();
        //}

        //[ApiExplorerSettings(IgnoreApi = true)]
        //[HttpPost]
        //public IAsyncResult ReserveBook(int bookId, int userId)
        //{
        //    throw new NotImplementedException();
        //}

        //[ApiExplorerSettings(IgnoreApi = true)]
        //[HttpPost]
        //public IAsyncResult CheckedOut(int bookInstanceId, bool toReadingRoom)
        //{
        //    throw new NotImplementedException();
        //}

        //[ApiExplorerSettings(IgnoreApi = true)]
        //[HttpPost]
        //public IAsyncResult Returned(int bookInstanceId)
        //{
        //    throw new NotImplementedException();
        //}

        //[ApiExplorerSettings(IgnoreApi = true)]
        //[HttpPost]
        //public IAsyncResult WrittenOff(int bookInstanceId)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
