﻿using Globomantics.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Models
{
    public abstract class Todo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = default!;
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? CreatedById { get; set; } = default!;

        //public Guid? AssignedToId { get; set; } = default!;
        public virtual Todo? Parent { get; set; }
        public virtual User? CreatedBy { get; set; } = default!;
    }
}
