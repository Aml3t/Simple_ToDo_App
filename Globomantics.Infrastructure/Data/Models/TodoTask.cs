using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Models
{
    public class TodoTask : Todo
    {
        public DateTimeOffset DueDate { get; init; }


    }
}
