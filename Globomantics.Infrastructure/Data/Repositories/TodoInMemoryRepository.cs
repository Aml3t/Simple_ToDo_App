using Globomantics.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repositories
{
    public class TodoInMemoryRepository<T> : IRepository<T>
        where T : Todo
    {
        public ConcurrentDictionary<Guid, T> Items { get; } = new();

        public Task AddAsync(T item)
        {
            Items.TryAdd(item.id, item);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<T>> AllAsync()
        {
            var items = Items.Values.ToArray();

            return Task.FromResult<IEnumerable<T>>(items);
        }

        public Task<T> FindByAsync(string value)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

