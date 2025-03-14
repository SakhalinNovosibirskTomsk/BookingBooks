﻿using CSharpFunctionalExtensions;
using Primitives;

namespace ReservationBooks.Core.Domain.Model
{
    public class Member: Entity<int>
    {
        public Result<Member, Error> Create(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return GeneralErrors.ValueIsRequired(nameof(name));

            return new Member(id, name);
        }

        private Member(int id, string name) 
        { 
            Id = id;
            Name = name;
        }

        public string Name { get; }
    }
}
