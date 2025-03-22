using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Primitives;

namespace ReservationBooks.Core.Domain.Model
{
    /// <summary>
    ///     Статус
    /// </summary>
    public class BookInstanceStatus : Entity<int>
    {
        public static readonly BookInstanceStatus Available = new(1, nameof(Available));
        public static readonly BookInstanceStatus CheckedOutToReadingRoom = new(2, nameof(CheckedOutToReadingRoom));
        public static readonly BookInstanceStatus CheckedOutToHome = new(3, nameof(CheckedOutToHome));
        public static readonly BookInstanceStatus WrittenOff = new(4, nameof(WrittenOff));

        private BookInstanceStatus()
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        private BookInstanceStatus(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Список всех значений списка
        /// </summary>
        /// <returns>Значения списка</returns>
        public static IEnumerable<BookInstanceStatus> List()
        {
            yield return Available;
            yield return CheckedOutToReadingRoom;
            yield return CheckedOutToHome;
            yield return WrittenOff;
        }

        /// <summary>
        /// Получить статус по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Статус</returns>
        public static Result<BookInstanceStatus, Error> FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
            if (state == null) return Errors.StatusIsWrong();
            return state;
        }

        /// <summary>
        /// Получить статус по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Статус</returns>
        public static Result<BookInstanceStatus, Error> FromId(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
            if (state == null) return Errors.StatusIsWrong();
            return state;
        }

        /// <summary>
        /// Ошибки, которые может возвращать сущность
        /// </summary>
        [ExcludeFromCodeCoverage]
        public static class Errors
        {
            public static Error StatusIsWrong()
            {
                return new Error($"{nameof(BookInstanceStatus).ToLowerInvariant()}.is.wrong",
                    $"Не верное значение. Допустимые значения: {nameof(BookInstanceStatus).ToLowerInvariant()}: {string.Join(",", List().Select(s => s.Name))}");
            }
        }

    }
}
