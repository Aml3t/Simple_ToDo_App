using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Models
{
    public class Image
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ImageData { get; set; } = default!;
    }
}
