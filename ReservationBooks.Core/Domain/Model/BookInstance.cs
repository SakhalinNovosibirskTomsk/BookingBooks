using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primitives;

namespace ReservationBooks.Core.Domain.Model
{
    /// <summary>
    /// Представляет класс Экземпляра Книги
    /// </summary>
    public class BookInstance: Aggregate<int>
    {
        public BookInstance Create(int id, int bookId, InventoryNumber inventoryNumber)
        {
            return new BookInstance(id, bookId, inventoryNumber);
        }

        private BookInstance()
        { }

        private BookInstance(int id, int bookId, InventoryNumber inventoryNumber)
        {
            Id = id;
            BookId = bookId;
            InventoryNumber = inventoryNumber;
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
        public IReadOnlyList<Reservation> Reservations { get; }

        /// <summary>
        /// Reserves the book for the specified user 
        /// </summary>
        public bool Reserve(Member member)
        {
            // 0. Проверить, можно ли зарезервировать книгу вообще и для данного читателя в частности.
            // 1. Создать объект Reservation, добавить в коллекцию.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cancels active reservation.
        /// </summary>
        public void CancelReservation()
        {
            // 1. Найти актуальны объект Reservation.
            // 2. Отменить его.
        }

        /// <summary>
        /// 
        /// </summary>
        public void BookCheckedOut(bool toReadingRoom)
        {
            
            Status = toReadingRoom ? BookInstanceStatus.CheckedOutToReadingRoom : BookInstanceStatus.CheckedOutToHome;
            
        }

        public void BookReturned()
        {
            Status = BookInstanceStatus.Available;
        }


        public void BookWrittenOff()
        {
            Status = BookInstanceStatus.WrittenOff;
        }

    }
}
