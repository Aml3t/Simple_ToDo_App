using Globomantics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repositories
{
    public abstract class TodoRepository<T> : IRepository<T>
        where T : TodoTask
    {
        private GlobomanticsDbContext Context { get; }
        public TodoRepository(GlobomanticsDbContext context)
        {
            Context = context;
        }

        public abstract Task AddAsync(T item);
    }
}
