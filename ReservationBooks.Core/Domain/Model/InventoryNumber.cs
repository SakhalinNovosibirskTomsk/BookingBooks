using CSharpFunctionalExtensions;
using Primitives;

namespace ReservationBooks.Core.Domain.Model
{
    public class InventoryNumber: ValueObject
    {
        public static Result<InventoryNumber, Error> Create(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return GeneralErrors.ValueIsInvalid(nameof(number));

            // Здесь может быть логика проверки правильности number: длина, формат и т.д. 
            // Но не в этом сервисе.

            return new InventoryNumber(number);
        }

        private InventoryNumber(string number)
        {
            Number = number;
        }

        public string Number { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }

    }
}
