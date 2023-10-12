﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Models
{
    public class User
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Name { get; set; } = default!;

    }
}
