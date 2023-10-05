﻿using System.Reflection.Metadata;

namespace Globomatics.Domain
{


    public abstract record Todo(Guid id,
        string Title,
        DateTimeOffset CreatedDate,
        User CreatedBy,
        bool IsCompleted = false,
        bool IsDeleted = false)
    {
        public Todo? Parent { get; init; }
    }
}