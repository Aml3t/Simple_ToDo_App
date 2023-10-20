using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly GlobomanticsDbContext Context;

        public UserRepository(GlobomanticsDbContext context)
        {
            Context = context;
        }

        public async Task AddAsync(User user)
        {
            var existingUser = await Context.Users.SingleOrDefaultAsync(
                u => u.Id == user.Id);

            if (existingUser is null)
            {
                var userToAdd = DomainToDataMapping.MapUser(user);

                await Context.Users.AddAsync(userToAdd);
            }
            else
            {
                existingUser.Name = user.Name;

                Context.Users.Update(existingUser);
            }
        }

        public Task<IEnumerable<User>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByAsync(string value)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
