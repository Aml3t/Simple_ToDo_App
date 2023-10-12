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
        public User? AssignedTo { get; set; }

    }
}
