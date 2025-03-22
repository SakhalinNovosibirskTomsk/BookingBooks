using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Primitives;

namespace ReservationBooks.Core.Domain.Model
{
    /// <summary>
    /// Представляет класс Экземпляра Книги
    /// </summary>
    public class BookInstance: Aggregate<int>
    {
        public static BookInstance Create(int id, int bookId, InventoryNumber inventoryNumber, BookInstanceStatus status)
        {
            return new BookInstance(id, bookId, inventoryNumber, status);
        }

        private BookInstance() { }
        
        private BookInstance(int id, int bookId, InventoryNumber inventoryNumber, BookInstanceStatus status)
        {
            Id = id;
            BookId = bookId;
            InventoryNumber = inventoryNumber;
            Status = status;
            
            Reservations = new List<Reservation>();
        }

        /// <summary>
        /// Инвентарный номер Экземпляра Книги.
        /// </summary>
        public InventoryNumber InventoryNumber { get; }

        /// <summary>
        /// Илентификатор Книги.
        /// </summary>
        public int BookId { get; }

        /// <summary>
        /// Статус Экземпляра Книги.
        /// </summary>
        public BookInstanceStatus Status { get; private set; }

        
        /// <summary>
        /// Список бронирований Экземпляра Книги.
        /// </summary>
        public ICollection<Reservation> Reservations { get; }


        /// <summary>
        /// Reserves the book for the specified user 
        /// </summary>
        public Result<Reservation, Error> Reserve(Member member)
        {
            if (member == null)
                return GeneralErrors.ValueIsRequired(nameof(member));

            // 1a. Проверить, можно ли зарезервировать книгу вообще...
            if (Reservations.Any(r => r.IsActive))
                return Errors.BookInstanceIsReserved();

            if (Status == BookInstanceStatus.CheckedOutToHome)
                return Errors.BookInstanceIsReserved();

            if (Status == BookInstanceStatus.WrittenOff)
                return Errors.BookInstanceIsWrittenOff();

            // 1b. ... для данного читателя в частности.
            // Пока нет БЛ, но тут можно анализировать какие-то характеристики читателя и книги и, например, не выдавать разгильдяю ценную книгу.

            // 2. Создать объект Reservation, добавить в коллекцию.
            //    #БЛ: Если книга в читальном зале - то бронирование начинается завтра утром.
            var startReservation = (Status == BookInstanceStatus.CheckedOutToReadingRoom) ? DateTime.Today.AddDays(1).AddHours(8) : DateTime.Now;
            //    #БЛ: "Плановая дата окончания бронирования конец следующего дня (в 18:00)". 
            var endReservationDatePlan = DateTime.Today.AddDays(1).AddHours(18);

            var reservation = Reservation.Create(member, startReservation, endReservationDatePlan);

            if (reservation.IsFailure)
                return reservation.Error;

            Reservations.Add(reservation.Value);
            
            return reservation;
        }

        /// <summary>
        /// Cancels active reservation.
        /// </summary>
        public void CancelReservation()
        {
            // 1. Найти актуальны объект Reservation.
            var reservation = Reservations.FirstOrDefault(r => r.IsActive);
            
            if (reservation == null)
                return;

            // 2. Отменить его.

            reservation.Cancel();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CheckOut(bool toReadingRoom)
        {
            
            Status = toReadingRoom 
                ? BookInstanceStatus.CheckedOutToReadingRoom 
                : BookInstanceStatus.CheckedOutToHome;
            
        }

        public void Return()
        {
            Status = BookInstanceStatus.Available;
        }


        public void WriteOff()
        {
            Status = BookInstanceStatus.WrittenOff;
        }

        /// <summary>
        /// Ошибки, которые может возвращать сущность
        /// </summary>
        public static class Errors
        {
            public static Error BookInstanceIsReserved()
            {
                return new Error($"reservation.cannot.start.in.past",
                    "Экземпляр книги уже забронирован.");
            }

            public static Error BookInstanceIsCheckedOutToHome()
            {
                return new Error($"book.instance.is.checked.out",
                    "Экземпляр книги выдан на руки.");
            }

            public static Error BookInstanceIsWrittenOff()
            {
                return new Error($"book.instance.is.written.off",
                    "Экземпляр книги списан.");
            }

        }
    }
}
