using Globomantics.Infrastructure.Data.Models;
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
            var model = input switch
            {
                Data.Models.Bug bug => MapBug(bug),
                Data.Models.Feature feature => MapFeature(feature),
                Data.Models.TodoTask task => MapTask(task),
            }

            return model;
        }

        private static object MapTask(TodoTask task)
        {
            throw new NotImplementedException();
        }

        private static object MapFeature(Feature feature)
        {
            throw new NotImplementedException();
        }

        private static object MapBug(Bug bug)
        {
            throw new NotImplementedException();
        }
    }
}
