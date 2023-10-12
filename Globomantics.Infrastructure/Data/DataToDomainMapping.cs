using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data
{
    public class DataToDomainMapping
    {
        public static TTo MapTodoFromData<TFrom, TTo>(TFrom input);
    }
}
