using Globomantics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Windows.ViewModels
{
    public interface ITodoViewModel : IViewModel
    {
        IEnumerable<Todo>? AvailableParentTasks { get; set; }


    }
}
