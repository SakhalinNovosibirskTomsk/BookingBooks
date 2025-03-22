using FluentAssertions;
using ReservationBooks.Core.Domain.Model;

namespace ReservationBooks.UnitTests
{
    public class BookInstanceTests
    {
        [Fact]
        public void ReservationPlanDateShouldBeEndDayOfNextDay()
        {
            // Arrange
            var bookInstance = BookInstance.Create(1, 1, InventoryNumber.Create("X-0001").Value, BookInstanceStatus.Available);
            Member member = Member.Create(100, "Геннадий").Value;

            // Act
            var reservation = bookInstance.Reserve(member).Value;

            // Assert
            reservation.EndReservationDatePlan.Should().NotBeNull();
            reservation.EndReservationDatePlan.Value.Date.Should().BeAfter(DateTime.Now);
            reservation.EndReservationDatePlan.Value.Hour.Should().Be(18);
            reservation.EndReservationDatePlan.Value.Day.Should().Be(DateTime.Now.Day + 1);

        }

        [Fact]
        public void ReservedBookInstanceCannotBeReservedAgain()
        {
            // Arrange
            var bookInstance = BookInstance.Create(1, 1, InventoryNumber.Create("X-0001").Value, BookInstanceStatus.Available);
            Member gennadiy = Member.Create(100, "Геннадий").Value;
            Member vitalik = Member.Create(101, "Валерон").Value;

            // Act
            // "Книгу 1" пытаемся забронировать для Геннадия
            var reservation0 = bookInstance.Reserve(gennadiy);
            // Эту же "Книгу 1" пытаемся забронировать для Валерона
            var reservation1 = bookInstance.Reserve(vitalik);

            // Assert
            // Бронь для Геннадия - ОК
            reservation0.IsSuccess.Should().BeTrue();

            // Бронь для Валерона - FAIL. Нельзя забронировать забронированную книгу
            reservation1.IsFailure.Should().BeTrue();

        }
    }
}