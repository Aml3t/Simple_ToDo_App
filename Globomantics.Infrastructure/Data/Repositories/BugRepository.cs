﻿using Globomantics.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Infrastructure.Data.Repositories
{
    public class BugRepository : TodoRepository<Bug>
    {
        public BugRepository(GlobomanticsDbContext context) : base(context) { }

        public override async Task AddAsync(Bug bug)
        {
            var existingBug = await Context.Bugs.FirstOrDefaultAsync(
                b => b.Id == bug.Id
            );

            var user = await Context.Users.FirstOrDefaultAsync(
                u => u.Id == bug.CreatedBy.Id
            );

            user ??= new() { Id = bug.CreatedBy.Id, Name = bug.CreatedBy.Name };

            if (existingBug is not null)
            {
                await UpdateAsync(bug, existingBug, user);
            }
            else
            {
                await CreateAsync(bug, user);
            }

        }

        private Task CreateAsync(Bug bug, Models.User user)
        {
            throw new NotImplementedException();
        }

        private Task UpdateAsync(Bug bug, Models.Bug existingBug, Models.User user)
        {
            throw new NotImplementedException();
        }

        public override Task<Bug> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}