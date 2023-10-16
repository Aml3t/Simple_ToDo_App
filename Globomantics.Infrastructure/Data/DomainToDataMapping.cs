using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data
{
    public class DomainToDataMapping
    {
        public static TTo MapTodoFromDomain<TFrom, TTo>(Domain.Todo input)
            where TFrom : Domain.Todo
            where TTo : Data.Models.Todo
        {


        }
    }
}
