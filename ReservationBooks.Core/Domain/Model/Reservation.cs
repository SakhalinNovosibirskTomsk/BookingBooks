﻿using CSharpFunctionalExtensions;
using Primitives;

namespace ReservationBooks.Core.Domain.Model
{
    public class Reservation : Entity<int>
    {
        internal static Result<Reservation, Error> Create(Member member, DateTime reservationDate,
            DateTime? endReservationDatePlan)
        {
            //// Нельзя начать резервирование вчерашним числом.
            //if (reservationDate < DateTime.Today)
            //    return Errors.ReservationCannotStartInPast();

            return new Reservation(member, reservationDate, endReservationDatePlan, true);
        }

        private Reservation()
        {
        }

        private Reservation(Member member, DateTime reservationDate, DateTime? endReservationDatePlan, bool isActive)
        {
            Member = member;
            ReservationDate = reservationDate;
            EndReservationDatePlan = endReservationDatePlan;
            IsActive = isActive;
        }

        public Member Member { get; }

        public DateTime ReservationDate { get; }

        public DateTime? EndReservationDatePlan { get; }

        public bool IsActive { get; private set; }

        public void Cancel()
        {
            IsActive = false;
        }

        ///// <summary>
        ///// Ошибки, которые может возвращать сущность
        ///// </summary>
        //public static class Errors
        //{
        //    public static Error ReservationCannotStartInPast()
        //    {
        //        return new Error($"reservation.cannot.start.in.past",
        //            "Бронирование экземпляра книги не может начинаться в прошлом.");
        //    }
        //}
    }
}
