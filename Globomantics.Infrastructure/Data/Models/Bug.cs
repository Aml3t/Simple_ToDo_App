using Globomantics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Models
{
    public class Bug : TodoTask
    {
        public string Description { get; set; } = default!;
        public Severity Severity { get; set; }
        public string AffectedVersion { get; set; } = string.Empty;
        public int AffectedUsers { get; set; }
        public Guid? AssignedToId { get; set; } = default!;
        public virtual User? AssignedTo { get; set; } = default!;
        public virtual ICollection<Image> Images { get; set; } = default!;
    }
}
