using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;
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
        protected GlobomanticsDbContext Context { get; }
        public TodoRepository(GlobomanticsDbContext context)
        {
            Context = context;
        }

        public abstract Task AddAsync(T item);

        public abstract Task<T> GetAsync(Guid id);

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await Context.TodoTasks.Where(t => !t.IsDeleted)
                .Include(t => t.CreatedBy)
                .Include(t => t.Parent)
                .Select(x => DataToDomainMapping.MapTodoFromData<Data.Models.TodoTask, T>(x))
                .ToArrayAsync();
        }

        public virtual async Task<T> FindByAsync(string title)
        {
            var task = await Context.TodoTasks
                .SingleAsync(t => title == t.Title);

            return DataToDomainMapping.MapTodoFromData<Data.Models.TodoTask, T>(task); 
        }

        public virtual async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        protected async Task SetParentAsync(Data.Models.Todo toBeAdded, Todo item)
        {
            Data.Models.TodoTask? existingParent = null;

            if (item.Parent is not null)
            {
                existingParent = await Context.TodoTasks.FirstOrDefaultAsync(
                    i => i.Id == item.Parent.Id
                    );
            }

            if (existingParent is not null)
            {
                toBeAdded.Parent = existingParent;
            }
            else if (item.Parent is not null)
            {
                var parentToAdd =
                    DomainToDataMapping
                    .MapTodoFromDomain<TodoTask, Data.Models.TodoTask>(item.Parent);
                toBeAdded.Parent = parentToAdd;
                await Context.AddAsync(parentToAdd);
            }
        }
    }
}
