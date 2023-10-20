﻿using Globomantics.Domain;
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

        public async Task<IEnumerable<User>> AllAsync()
        {
            return await Context.Users.Select
                (x => DataToDomainMapping.MapUser(x))
                .ToArrayAsync();
        }

        public async Task<User> FindByAsync(string name)
        {
            var user = await Context.Users.SingleAsync(
                user => user.Name == name);

            return DataToDomainMapping.MapUser(user);
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
