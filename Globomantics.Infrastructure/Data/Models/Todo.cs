using System;
using System.Collections.Generic;
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

    }
}
