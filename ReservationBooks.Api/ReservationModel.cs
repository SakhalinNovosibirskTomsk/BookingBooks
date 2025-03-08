namespace ReservationBooks.Api
{
    public class ReservationModel
    {
        public int BookInstanceId { get; set; }

        public int MemberId { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime? EndReservationDatePlan { get; set; }

    }
}
