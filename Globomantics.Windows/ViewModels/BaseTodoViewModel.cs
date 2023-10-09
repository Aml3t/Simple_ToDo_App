using CommunityToolkit.Mvvm.ComponentModel;
using Globomantics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Windows.ViewModels
{
    public abstract class BaseTodoViewModel<T> : ObservableObject where T : Todo
    {
    }
}
